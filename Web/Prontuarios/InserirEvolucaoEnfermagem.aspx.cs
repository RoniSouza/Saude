using Negocios;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Prontuarios
{
    public partial class EvolucaoEnfermagem : System.Web.UI.Page
    {
        private string idpaciente;
        EvolucaoEnfermagemNegocio evolucaoEnfermagemNegocio = new EvolucaoEnfermagemNegocio();
        EvolucaoEnfermagemClass evolucaoEnfermagemClass = new EvolucaoEnfermagemClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            idpaciente = Request.QueryString["id"];
            AtualizarGridEvolucaoEnfermagem();
        }
        protected void Inserir(object sender, EventArgs e)
        {
            if (TextBoxFrequenciaCardiaca.Text != "")
            {
                evolucaoEnfermagemClass.IdPessoa = Convert.ToInt32(idpaciente);
                evolucaoEnfermagemClass.FrequenciaCardiaca = TextBoxFrequenciaCardiaca.Text;
                evolucaoEnfermagemClass.PressaoArterial = TextBoxPressaoArterial.Text;
                evolucaoEnfermagemClass.Respiracao = TextBoxRespiracao.Text;
                evolucaoEnfermagemClass.Temperatura = TextBoxTemperatura.Text;
                evolucaoEnfermagemClass.Observacoes = TextBoxObservacoes.Text;
                evolucaoEnfermagemClass.CadastradoPor = HttpContext.Current.User.Identity.Name;

                try
                {
                    evolucaoEnfermagemNegocio.Inserir(evolucaoEnfermagemClass);
                    string message = "Evolução de Enfermagem inserida com sucesso!";
                    Response.Write("<script>alert('" + message + "')</script>");
                    AtualizarGridEvolucaoEnfermagem();
                }
                catch (Exception ex)
                {
                    ErrorMessage.Text = ex.Message;
                    ErrorMessage.Visible = true;
                }
            }
            else
            {
                string message = "Preencha os campos!";
                Response.Write("<script>alert('" + message + "')</script>");
            }
        }
        private void AtualizarGridEvolucaoEnfermagem()
        {
            EvolucaoEnfermagemNegocio EvolucaoEnfermagemNegocio = new EvolucaoEnfermagemNegocio();
            EvolucaoEnfermagemColecao evolucaoEnfermagemColecao = new EvolucaoEnfermagemColecao();
            evolucaoEnfermagemColecao = EvolucaoEnfermagemNegocio.ConsultaPorId(idpaciente);
            GridViewEvolucaoEnfermagem.DataSource = evolucaoEnfermagemColecao;
            GridViewEvolucaoEnfermagem.DataBind();
        }
        protected void Voltar(object sender, EventArgs e)
        {
            Response.Redirect("~/Prontuarios/Index.aspx?id=" + idpaciente);
       }
         protected void GridViewEvolucaoEnfermagem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEvolucaoEnfermagem.PageIndex = e.NewPageIndex;
            AtualizarGridEvolucaoEnfermagem();
        }
    }
}