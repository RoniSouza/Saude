using Negocios;
using ObjetoTransferencia;
using System;
using System.Web;

namespace Web.Prontuarios
{
    public partial class EvolucaoMedica : System.Web.UI.Page
    {
        private string idpaciente;
        EvolucaoMedicaClass evolucaoMedicaClass = new EvolucaoMedicaClass();
        EvolucaoMedicaNegocio evolucaoMedicaNegocio = new EvolucaoMedicaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            idpaciente = Request.QueryString["id"];
            AtualizarGridEvolucaoMedica();
        }
        protected void Inserir(object sender, EventArgs e)
        {
            if (TextBoxEvolucaoMedica.Text != "")
            {
                evolucaoMedicaClass.IdPessoa = Convert.ToInt32(idpaciente);
                evolucaoMedicaClass.EvolucaoMedica = TextBoxEvolucaoMedica.Text;
                evolucaoMedicaClass.Observacoes = TextBoxObservacoes.Text;
                evolucaoMedicaClass.CadastradoPor = HttpContext.Current.User.Identity.Name;


                try
                {
                    evolucaoMedicaNegocio.Inserir(evolucaoMedicaClass);
                    string message = "Evolução Médica inserida com sucesso!";
                    Response.Write("<script>alert('" + message + "')</script>");
                    AtualizarGridEvolucaoMedica();
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

        protected void GridViewEvolucaoMedica_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            GridViewEvolucaoMedica.PageIndex = e.NewPageIndex;
            AtualizarGridEvolucaoMedica();
        }
    }
}