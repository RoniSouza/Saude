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
    public partial class InserirPrescricaoMedica : System.Web.UI.Page
    {
        PrescricaoMedica prescricaoMedica = new PrescricaoMedica();
        PrescricaoMedicaNegocio prescricaoMedicaNegocio = new PrescricaoMedicaNegocio();
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();
        Paciente paciente = new Paciente();
        private string idpaciente;

        protected void Page_Load(object sender, EventArgs e)
        {
            idpaciente = Request.QueryString["id"];
            AtualizarGridPrescricaoMedica();

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
        private void AtualizarGridPrescricaoMedica()
        {
            PrescricaoMedicaNegocio prescricaoMedicaNegocio = new PrescricaoMedicaNegocio();
            PrescricaoMedicaColecao prescricaoMedicaColecao = new PrescricaoMedicaColecao();
            prescricaoMedicaColecao = prescricaoMedicaNegocio.ConsultarPrescricoes(idpaciente);
            GridViewPrescricaoMedica.DataSource = prescricaoMedicaColecao;
            GridViewPrescricaoMedica.DataBind();
        }

        protected void Inserir(object sender, EventArgs e)
        {
            if (TextBoxDescricao.Text != "" && TextBoxQtdDias.Text != "" && DropDownListHora.Text != "" && TextBoxHoraInicial.Text != "")
            {
                DateTime DataAtual = DateTime.Now;
                DateTime DataDigitada = Convert.ToDateTime(TextBoxHoraInicial.Text);

                int QtdDias = Convert.ToInt32(TextBoxQtdDias.Text);

                if (DataAtual.Hour < DataDigitada.Hour || DataAtual.Minute < DataDigitada.Minute)
                {

                    int Intervalo = Convert.ToInt32(DropDownListHora.Text);
                    string horaInicial = TextBoxHoraInicial.Text;
                    int QtdDoses = (QtdDias * 24) / Intervalo;

                    prescricaoMedica.IdPessoa = Convert.ToInt32(idpaciente);
                    if (rbtDadosVitais.Checked == true)
                        prescricaoMedica.Tipo = "Dados Vitais";
                    else if (rbtMedicacao.Checked == true)
                        prescricaoMedica.Tipo = "Medicação";
                    else if (rbtCuidados.Checked == true)
                        prescricaoMedica.Tipo = "Cuidados";
                    prescricaoMedica.Descricao = TextBoxDescricao.Text;
                    prescricaoMedica.QtdDias = Convert.ToInt32(TextBoxQtdDias.Text);
                    prescricaoMedica.Horario = Convert.ToDateTime(horaInicial);
                    prescricaoMedica.NomeMedico = HttpContext.Current.User.Identity.Name;

                    try
                    {
                        prescricaoMedicaNegocio.Inserir(prescricaoMedica);
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage.Text = ex.Message;
                        ErrorMessage.Visible = true;
                    }

                    for (int i = 0; i < QtdDoses - 1; i++)
                    {

                        TimeSpan HoraIncremento = new TimeSpan(0, Intervalo, 0, 0);
                        DateTime UltimaHora = DateTime.Parse(horaInicial);
                        DateTime HoraFinal = UltimaHora.Add(HoraIncremento);
                        horaInicial = HoraFinal.ToString();

                        prescricaoMedica.IdPessoa = Convert.ToInt32(idpaciente);
                        if (rbtDadosVitais.Checked == true)
                            prescricaoMedica.Tipo = "Dados Vitais";
                        else if (rbtMedicacao.Checked == true)
                            prescricaoMedica.Tipo = "Medicação";
                        else if (rbtCuidados.Checked == true)
                            prescricaoMedica.Tipo = "Cuidados";
                        prescricaoMedica.Descricao = TextBoxDescricao.Text;
                        prescricaoMedica.QtdDias = Convert.ToInt32(TextBoxQtdDias.Text);
                        prescricaoMedica.Horario = Convert.ToDateTime(horaInicial);
                        prescricaoMedica.NomeMedico = HttpContext.Current.User.Identity.Name;

                        try
                        {
                            prescricaoMedicaNegocio.Inserir(prescricaoMedica);
                            string message = "Prescrição Médica inserida com sucesso!";
                            Response.Write("<script>alert('" + message + "')</script>");
                            AtualizarGridPrescricaoMedica();
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage.Text = ex.Message;
                            ErrorMessage.Visible = true;
                        }
                    }
                }
                else
                {
                    string message = "A hora digitada não pode ser menor que a hora atual!";
                    Response.Write("<script>alert('" + message + "')</script>");
                }
            }
            else
            {
                string message = "Preencha os campos!";
                Response.Write("<script>alert('" + message + "')</script>");
            }


        }
        protected void Voltar(object sender, EventArgs e)
        {
            Response.Redirect("~/Prontuarios/Index.aspx?id=" + idpaciente);
        }

        protected void GridViewPrescricaoMedica_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            GridViewPrescricaoMedica.PageIndex = e.NewPageIndex;
            AtualizarGridPrescricaoMedica();
        }

    }
}