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
    public partial class VisualizarEvolucaoMedica : System.Web.UI.Page
    {
        private string idpaciente;
        protected void Page_Load(object sender, EventArgs e)
        {
            idpaciente = Request.QueryString["id"];
            AtualizarGridEvolucaoMedica();
        }
        private void AtualizarGridEvolucaoMedica()
        {
            EvolucaoMedicaNegocio evolucaoMedicaNegocio = new EvolucaoMedicaNegocio();
            EvolucaoMedicaColecao evolucaoMedicaColecao = new EvolucaoMedicaColecao();
            evolucaoMedicaColecao = evolucaoMedicaNegocio.ConsultaPorId(idpaciente);
            GridViewEvolucaoMedica.DataSource = evolucaoMedicaColecao;
            GridViewEvolucaoMedica.DataBind();
        }
        protected void Voltar(object sender, EventArgs e)
        {
            Response.Redirect("~/Prontuarios/Index.aspx?id=" + idpaciente);
        }
        protected void GridViewEvolucaoMedica_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEvolucaoMedica.PageIndex = e.NewPageIndex;
            AtualizarGridEvolucaoMedica();
        }
    }
}