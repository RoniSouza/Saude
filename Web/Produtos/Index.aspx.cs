using Negocios;
using ObjetoTransferencia;
using System;

namespace Web.Produtos
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        private void AtualizarGrid()
        {
            ProdutoNegocio produtoNegocio = new ProdutoNegocio();
            ProdutoColecao produtoColecao = new ProdutoColecao();

            try
            {
                if (rbtNome.Checked == true)
                {
                    produtoColecao = produtoNegocio.ConsultaPorNome(TextBoxPesquisar.Text);
                }
                else
                {
                    produtoColecao = produtoNegocio.ConsultaPorId(TextBoxPesquisar.Text);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
                ErrorMessage.Visible = true;
            }
            GridViewProdutos.DataSource = produtoColecao;
            GridViewProdutos.DataBind();
        }
        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            AtualizarGrid();
        }
    }
}