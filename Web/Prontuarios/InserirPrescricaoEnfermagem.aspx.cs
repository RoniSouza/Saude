using Negocios;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AcessoBancoDados;
using System.Data;

namespace Web.Prontuarios
{
    public partial class InserirPrescricaoEnfermagem : System.Web.UI.Page
    {
        PrescricaoEnfermagem prescricaoEnfermagem = new PrescricaoEnfermagem();
        PrescricaoEnfermagemNegocio prescricaoEnfermagemNegocio = new PrescricaoEnfermagemNegocio();
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();
        Paciente paciente = new Paciente();
        private string idpaciente;
        private string retorno;
        protected void Page_Load(object sender, EventArgs e)
        {
            idpaciente = Request.QueryString["id"];
            AtualizarGridPrescricaoEnfermagem();

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
        private void AtualizarGridPrescricaoEnfermagem()
        {
            PrescricaoEnfermagemNegocio prescricaoEnfermagemNegocio = new PrescricaoEnfermagemNegocio();
            PrescricaoEnfermagemColecao prescricaoEnfermagemColecao = new PrescricaoEnfermagemColecao();
            prescricaoEnfermagemColecao = prescricaoEnfermagemNegocio.ConsultarPrescricoes(idpaciente);
            GridViewPrescricaoEnfermagem.DataSource = prescricaoEnfermagemColecao;
            GridViewPrescricaoEnfermagem.DataBind();
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

                    prescricaoEnfermagem.IdPessoa = Convert.ToInt32(idpaciente);
                    if (rbtDadosVitais.Checked == true)
                        prescricaoEnfermagem.Tipo = "Dados Vitais";
                    else if (rbtCuidados.Checked == true)
                        prescricaoEnfermagem.Tipo = "Cuidados";
                    prescricaoEnfermagem.Descricao = TextBoxDescricao.Text;
                    prescricaoEnfermagem.QtdDias = Convert.ToInt32(TextBoxQtdDias.Text);
                    prescricaoEnfermagem.Horario = Convert.ToDateTime(horaInicial);
                    prescricaoEnfermagem.NomeEnfermeiro = HttpContext.Current.User.Identity.Name;

                    try
                    {
                        prescricaoEnfermagemNegocio.Inserir(prescricaoEnfermagem);
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

                        prescricaoEnfermagem.IdPessoa = Convert.ToInt32(idpaciente);
                        if (rbtDadosVitais.Checked == true)
                            prescricaoEnfermagem.Tipo = "Dados Vitais";
                        else if (rbtCuidados.Checked == true)
                            prescricaoEnfermagem.Tipo = "Cuidados";
                        prescricaoEnfermagem.Descricao = TextBoxDescricao.Text;
                        prescricaoEnfermagem.QtdDias = Convert.ToInt32(TextBoxQtdDias.Text);
                        prescricaoEnfermagem.Horario = Convert.ToDateTime(horaInicial);
                        prescricaoEnfermagem.NomeEnfermeiro = HttpContext.Current.User.Identity.Name;

                        try
                        {
                            prescricaoEnfermagemNegocio.Inserir(prescricaoEnfermagem);
                            string message = "Prescrição Médica inserida com sucesso!";
                            Response.Write("<script>alert('" + message + "')</script>");
                            AtualizarGridPrescricaoEnfermagem();
                        }
                        catch (Exception)
                        {
                            ErrorMessage.Text = retorno.ToString();
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

        protected void GridViewPrescricaoEnfermagem_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            GridViewPrescricaoEnfermagem.PageIndex = e.NewPageIndex;
            AtualizarGridPrescricaoEnfermagem();
        }
    }
}