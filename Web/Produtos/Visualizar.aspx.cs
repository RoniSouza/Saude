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
    public partial class Visualizar : System.Web.UI.Page
    {
        private string retorno;
        private string idproduto;
        Produto produto = new Produto();
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();
        private DateTime data;
        private decimal valor;
        ProdutoNegocio produtoNegocio = new ProdutoNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            idproduto = Request.QueryString["id"];
            if (!Page.IsPostBack)
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdProduto", idproduto);
                DataTable datatableProduto = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspProdutoPesquisarPorId");

                foreach (DataRow linha in datatableProduto.Rows)
                {
                    TextBoxCodigo.Text = Convert.ToString(linha["IdProduto"]);
                    TextBoxNome.Text = Convert.ToString(linha["Nome"]);
                    TextBoxDescricao.Text = Convert.ToString(linha["Descricao"]);
                    TextBoxFabricante.Text = Convert.ToString(linha["Fabricante"]);
                    valor = Convert.ToDecimal(linha["Preco"]);
                    TextBoxPreco.Text = string.Format("{0:0.00}", valor); //valor.ToString("{0:0.00}");
                    TextBoxLote.Text = Convert.ToString(linha["Lote"]);
                    data = Convert.ToDateTime(linha["DataFabricacao"]);
                    TextBoxDataFabricacao.Text = data.ToString("MM/yyyy");
                    data = Convert.ToDateTime(linha["DataValidade"]);
                    TextBoxDataValidade.Text = data.ToString("MM/yyyy");
                    TextBoxQuantidade.Text = Convert.ToString(linha["Quantidade"]);
                    data = Convert.ToDateTime(linha["DataCadastro"]);
                    TextBoxDataCadastro.Text = data.ToString("dd/MM/yyyy HH:mm");
                    TextBoxCadastradoPor.Text = Convert.ToString(linha["Usuario"]);
                    data = Convert.ToDateTime(linha["DataModificacao"]);
                    TextBoxDataModificacao.Text = data.ToString("dd/MM/yyyy HH:mm");
                }
            }
        }
        protected void Alterar(object sender, EventArgs e)
        {
            produto.IdProduto = Convert.ToInt32(idproduto);
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
                retorno = produtoNegocio.Alterar(produto);
                Response.Write("<script>alert('Produto Alterado com sucesso!')</script>");
            }
            catch (Exception)
            {
                ErrorMessage.Text = retorno.ToString();
                ErrorMessage.Visible = true;
            }
        }
        protected void Excluir(object sender, EventArgs e)
        {
            try
            {
                retorno = produtoNegocio.Excluir(produto);
                Response.Write("<script>alert('Produto excluído com sucesso!')</script>");
            }
            catch (Exception)
            {
                ErrorMessage.Text = retorno.ToString();
                ErrorMessage.Visible = true;
            }
        }
        protected void Estoque(object sender, EventArgs e)
        {
            Response.Redirect("~/Produtos/Estoque.aspx?id=" + idproduto);
        }

        protected void Voltar(object sender, EventArgs e)
        {
            Response.Redirect("~/Produtos/Index.aspx");
        }
    }
}