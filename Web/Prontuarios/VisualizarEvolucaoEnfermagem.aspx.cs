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
    public partial class VisualizarEvolucaoEnfermagem : System.Web.UI.Page
    {
        private string idpaciente;
        protected void Page_Load(object sender, EventArgs e)
        {
            idpaciente = Request.QueryString["id"];
            AtualizarGridEvolucaoEnfermagem();
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