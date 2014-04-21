using Negocios;
using ObjetoTransferencia;
using System;

namespace Web.Funcionarios
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        private void AtualizarGrid()
        {
            FuncionarioNegocio funcionarioNegocio = new FuncionarioNegocio();
            FuncionarioColecao funcionarioColecao = new FuncionarioColecao();

            try
            {
                if (rbtNome.Checked == true)
                {
                    funcionarioColecao = funcionarioNegocio.ConsultaPorNome(TextBoxPesquisar.Text);

                }
                else
                {
                    funcionarioColecao = funcionarioNegocio.ConsultaPorId(Convert.ToInt32(TextBoxPesquisar.Text));
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
                ErrorMessage.Visible = true;
            }
            GridViewFuncionarios.DataSource = funcionarioColecao;
            GridViewFuncionarios.DataBind();
        }
        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            AtualizarGrid();
        }
        protected void GridViewFuncionarios_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            GridViewFuncionarios.PageIndex = e.NewPageIndex;
            AtualizarGrid();
        }
    }
}