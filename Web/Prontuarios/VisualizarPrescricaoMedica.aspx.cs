using AcessoBancoDados;
using Negocios;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Prontuarios
{
    public partial class VisualizarPrescricaoMedica : System.Web.UI.Page
    {
        private string idpaciente;
        PacienteColecao pacienteColecao = new PacienteColecao();
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();
        Paciente paciente = new Paciente();
        private string message;
        private string retorno;
        protected void Page_Load(object sender, EventArgs e)
        {
            idpaciente = Request.QueryString["id"];
            if (!Page.IsPostBack)
            {
                AtualizarGridPrescricaoMedicaAFazer();
                AtualizarGridPrescricaoMedicaRealizadas();

                foreach (GridViewRow row in GridViewPrescricaoMedica.Rows)
                {
                    CheckBox chk = row.FindControl("CheckBoxTarefa") as CheckBox;
                    var horario1 = row.FindControl("lblHorario") as Label;
                    DateTime horario = Convert.ToDateTime(horario1.Text);
                    DateTime HoraAtual = DateTime.Now;

                    if (horario.Hour > HoraAtual.Hour || horario.Date > HoraAtual.Date)
                        chk.Enabled = false;
                }
            }
            acessoDadosSqlServer.LimparParametros();
            acessoDadosSqlServer.AdicionarParametros("@IdPaciente", idpaciente);
            DataTable datatablePaciente = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPacientePesquisarPorId");

            foreach (DataRow linha in datatablePaciente.Rows)
            {
                paciente.Nome = Convert.ToString(linha["Nome"]);
                paciente.Leito = Convert.ToString(linha["Leito"]);
            }
            nome.Text = paciente.Nome;
            leito.Text = paciente.Leito;

           
           
        }
        private void AtualizarGridPrescricaoMedicaRealizadas()
        {
            PrescricaoMedicaNegocio prescricaoMedicaNegocio = new PrescricaoMedicaNegocio();
            PrescricaoMedicaColecao prescricaoMedicaColecao = new PrescricaoMedicaColecao();
            prescricaoMedicaColecao = prescricaoMedicaNegocio.ConsultarPrescricoesMedicasRealizadas(idpaciente);
            GridViewPrescricaoMedicaRealizadas.DataSource = prescricaoMedicaColecao;
            GridViewPrescricaoMedicaRealizadas.DataBind();

        }
        private void AtualizarGridPrescricaoMedicaAFazer()
        {
            PrescricaoMedicaNegocio prescricaoMedicaNegocio = new PrescricaoMedicaNegocio();
            PrescricaoMedicaColecao prescricaoMedicaColecao = new PrescricaoMedicaColecao();
            prescricaoMedicaColecao = prescricaoMedicaNegocio.ConsultarPrescricoesMedicasAFazer(idpaciente);
            GridViewPrescricaoMedica.DataSource = prescricaoMedicaColecao;
            GridViewPrescricaoMedica.DataBind();

        }
        protected void Voltar(object sender, EventArgs e)
        {
            Response.Redirect("~/Prontuarios/Index.aspx?id=" + idpaciente);
        }

        protected void GridViewPrescricaoMedica_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewPrescricaoMedica.PageIndex = e.NewPageIndex;
            AtualizarGridPrescricaoMedicaAFazer();
        }
        protected void GridViewPrescricaoMedicaRealizadas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewPrescricaoMedicaRealizadas.PageIndex = e.NewPageIndex;
            AtualizarGridPrescricaoMedicaRealizadas();
        }
        protected void MarcarTarefa_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewPrescricaoMedica.Rows)
            {
                PrescricaoMedica prescricaoMedica = new PrescricaoMedica();
                PrescricaoMedicaNegocio prescricaoMedicaNegocio = new PrescricaoMedicaNegocio();
                var chk = row.FindControl("CheckBoxTarefa") as CheckBox;

                if (chk.Checked)
                {
                    var lblhorario = row.FindControl("lblHorario") as Label;
                    var lblid = row.FindControl("lblIdPrescricao") as Label;
                    var textbox = row.FindControl("TextBoxHoraRealizacao") as TextBox;

                    DateTime HorarioMarcado = Convert.ToDateTime(lblhorario.Text); ;
                    DateTime DataDigitada = Convert.ToDateTime(textbox.Text);

                    if (HorarioMarcado.Hour < DataDigitada.Hour || HorarioMarcado.Minute < DataDigitada.Minute)
                    {

                        prescricaoMedica.IdPrescricaoMedica = Convert.ToInt32(lblid.Text);
                        prescricaoMedica.TarefaRealizada = true;
                        prescricaoMedica.HoraRealizacaoTarefa = Convert.ToString(textbox.Text);
                        prescricaoMedica.NomeEnfermeiro = HttpContext.Current.User.Identity.Name;
                        try
                        {
                            prescricaoMedicaNegocio.MarcarTarefaRealizada(prescricaoMedica);
                            message = "Tarefa marcada como realizada!";
                            Response.Write("<script>alert('" + message + "')</script>");
                            AtualizarGridPrescricaoMedicaAFazer();
                            AtualizarGridPrescricaoMedicaRealizadas();
                        }
                        catch (Exception)
                        {
                            ErrorMessage.Text = retorno.ToString();
                            ErrorMessage.Visible = true;
                        }
                    }
                    else
                    {
                        message = "A hora digitada não pode ser menor que o horário marcado!";
                        Response.Write("<script>alert('" + message + "')</script>");
                    }

                }
            }
        }

    }

}
