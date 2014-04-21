using Negocios;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Produtos
{
    public partial class Adicionar : System.Web.UI.Page
    {
        private string retorno;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Inserir(object sender, EventArgs e)
        {
            DateTime dataFabricacao = Convert.ToDateTime(TextBoxDataFabricacao.Text);
            DateTime dataValidade = Convert.ToDateTime(TextBoxDataFabricacao.Text);

            if (dataFabricacao < dataValidade)
            {
              
                Produto produto = new Produto();

                produto.Nome = TextBoxNome.Text;
                produto.Descricao = TextBoxDescricao.Text;
                produto.Fabricante = TextBoxFabricante.Text;
                produto.Preco = Convert.ToDecimal(TextBoxPreco.Text);
                produto.Lote = TextBoxLote.Text;
                produto.DataFabricacao = Convert.ToDateTime(TextBoxDataFabricacao.Text);
                produto.DataValidade = Convert.ToDateTime(TextBoxDataValidade.Text);
                produto.CadastradoPor = HttpContext.Current.User.Identity.Name;

                try
                {
                    ProdutoNegocio produtoNegocio = new ProdutoNegocio();
                    produtoNegocio.Inserir(produto);
                    string message = "Produto cadastrado com sucesso!";
                    Response.Write("<script>alert('" + message + "')</script>");
                }
                catch (Exception)
                {
                    ErrorMessage.Text = retorno.ToString();
                    ErrorMessage.Visible = true;

                }
            }
            else
            {
                string message = "Data de Fabricação não pode ser maior que a Data de Validade!";
                Response.Write("<script>alert('" + message + "')</script>");
            }
        }
    }
}