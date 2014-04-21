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

namespace Web.Produtos
{
    public partial class Estoque : System.Web.UI.Page
    {
        private string retorno;
        private string idproduto;
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();
        Produto produto = new Produto();
        protected void Page_Load(object sender, EventArgs e)
        {
            idproduto = Request.QueryString["id"];

            if (!Page.IsPostBack)
            {
                AtualizarGridProdutos();  
            }
        }

        private void AtualizarGridProdutos()
        {
            ProdutoNegocio produtoNegocio = new ProdutoNegocio();
            ProdutoColecao produtoColecao = new ProdutoColecao();
            produtoColecao = produtoNegocio.ConsultaPorId(idproduto);
            GridViewProdutos.DataSource = produtoColecao;
            GridViewProdutos.DataBind();

        }

        protected void Entrada(object sender, EventArgs e)
        {
            if (IsValid)
            {


                produto.IdProduto = Convert.ToInt32(idproduto);
                produto.Quantidade = Convert.ToInt32(TextBoxQuantidade.Text);
                produto.CadastradoPor = HttpContext.Current.User.Identity.Name;

                try
                {
                    ProdutoNegocio produtoNegocio = new ProdutoNegocio();
                    retorno = produtoNegocio.Entrada(produto);
                    string message = "Registro cadastrado com sucesso!";
                    Response.Write("<script>alert('" + message + "')</script>");
                    AtualizarGridProdutos();
                }
                catch (Exception)
                {
                    ErrorMessage.Text = retorno.ToString();
                    ErrorMessage.Visible = true;
                }
            }
        }
        protected void Saida(object sender, EventArgs e)
        {
            if (IsValid)
            {
                produto.IdProduto = Convert.ToInt32(idproduto);
                produto.Quantidade = Convert.ToInt32(TextBoxQuantidade.Text);
                produto.CadastradoPor = HttpContext.Current.User.Identity.Name;

                try
                {
                    ProdutoNegocio produtoNegocio = new ProdutoNegocio();
                    retorno = produtoNegocio.Saida(produto);
                    string message = "Registro cadastrado com sucesso!";
                    Response.Write("<script>alert('" + message + "')</script>");
                    AtualizarGridProdutos();

                }
                catch (Exception)
                {
                    ErrorMessage.Text = retorno.ToString();
                    ErrorMessage.Visible = true;
                }
            }
           
        }
        protected void Voltar(object sender, EventArgs e)
        {
            Response.Redirect("~/Produtos/Visualizar.aspx?id=" + idproduto);
        }
    }
}