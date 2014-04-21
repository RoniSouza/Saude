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

namespace Web.Mobile
{
    public partial class VisualizarPrescricaoEnfermagem : System.Web.UI.Page
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
                AtualizarGridPrescricaoEnfermagemAFazer();
                AtualizarGridPrescricaoEnfermagemRealizadas();
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

            foreach (GridViewRow row in GridViewPrescricaoEnfermagemAFazer.Rows)
            {
                CheckBox chk = row.FindControl("CheckBoxTarefa") as CheckBox;
                var horario1 = row.FindControl("lblHorario") as Label;
                DateTime horario = Convert.ToDateTime(horario1.Text);
                DateTime HoraAtual = DateTime.Now;

                if (horario.Hour > HoraAtual.Hour || horario.Date > HoraAtual.Date)
                    chk.Enabled = false;
            }
        }
        private void AtualizarGridPrescricaoEnfermagemRealizadas()
        {
            PrescricaoEnfermagemNegocio prescricaoEnfermagemNegocio = new PrescricaoEnfermagemNegocio();
            PrescricaoEnfermagemColecao prescricaoEnfermagemColecao = new PrescricaoEnfermagemColecao();
            prescricaoEnfermagemColecao = prescricaoEnfermagemNegocio.ConsultarPrescricoesEnfermagemRealizadas(idpaciente);
            GridViewPrescricaoEnfermagemRealizadas.DataSource = prescricaoEnfermagemColecao;
            GridViewPrescricaoEnfermagemRealizadas.DataBind();
        }
        private void AtualizarGridPrescricaoEnfermagemAFazer()
        {
            PrescricaoEnfermagemNegocio prescricaoEnfermagemNegocio = new PrescricaoEnfermagemNegocio();
            PrescricaoEnfermagemColecao prescricaoEnfermagemColecao = new PrescricaoEnfermagemColecao();
            prescricaoEnfermagemColecao = prescricaoEnfermagemNegocio.ConsultarPrescricoesEnfermagemAFazer(idpaciente);
            GridViewPrescricaoEnfermagemAFazer.DataSource = prescricaoEnfermagemColecao;
            GridViewPrescricaoEnfermagemAFazer.DataBind();
        }
        protected void GridViewPrescricaoEnfermagemAFazer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewPrescricaoEnfermagemAFazer.PageIndex = e.NewPageIndex;
            AtualizarGridPrescricaoEnfermagemAFazer();
        }
        protected void GridViewPrescricaoEnfermagemRealizadas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewPrescricaoEnfermagemRealizadas.PageIndex = e.NewPageIndex;
            AtualizarGridPrescricaoEnfermagemRealizadas();
        }
        protected void MarcarTarefa_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewPrescricaoEnfermagemAFazer.Rows)
            {
                PrescricaoEnfermagem prescricaoEnfermagem = new PrescricaoEnfermagem();
                PrescricaoEnfermagemNegocio prescricaoEnfermagemNegocio = new PrescricaoEnfermagemNegocio();
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
                        prescricaoEnfermagem.IdPrescricaoEnfermagem = Convert.ToInt32(lblid.Text);
                        prescricaoEnfermagem.TarefaRealizada = true;
                        prescricaoEnfermagem.HoraRealizacaoTarefa = Convert.ToString(textbox.Text);
                        prescricaoEnfermagem.NomeEnfermeiro = HttpContext.Current.User.Identity.Name;
                        try
                        {
                            prescricaoEnfermagemNegocio.MarcarTarefaRealizada(prescricaoEnfermagem);
                            string message = "Tarefa marcada como realizada!";
                            Response.Write("<script>alert('" + message + "')</script>");
                            AtualizarGridPrescricaoEnfermagemAFazer();
                            AtualizarGridPrescricaoEnfermagemRealizadas();
                        }
                        catch (Exception)
                        {
                            ErrorMessage.Text = retorno.ToString(); ;
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
        protected void VisualizarPrescricaoMedica(object sender, EventArgs e)
        {
            Response.Redirect("~/Mobile/VisualizarPrescricaoMedica.aspx?id=" + idpaciente);
        }
    }
}