using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class ProdutoNegocio
    {
        //instancia = criar um novo objeto baseado em um modelo
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();

        public string Inserir(Produto produto)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@Nome", produto.Nome);
                acessoDadosSqlServer.AdicionarParametros("@Descricao", produto.Descricao);
                acessoDadosSqlServer.AdicionarParametros("@Fabricante", produto.Fabricante);
                acessoDadosSqlServer.AdicionarParametros("@Preco", produto.Preco);
                acessoDadosSqlServer.AdicionarParametros("@Lote", produto.Lote);
                acessoDadosSqlServer.AdicionarParametros("@DataFabricacao", produto.DataFabricacao);
                acessoDadosSqlServer.AdicionarParametros("@DataValidade", produto.DataValidade);
                acessoDadosSqlServer.AdicionarParametros("@Usuario", produto.CadastradoPor);

                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspProdutoInserir").ToString();

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        public string Alterar(Produto produto)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdProduto", produto.IdProduto);
                acessoDadosSqlServer.AdicionarParametros("@Nome", produto.Nome);
                acessoDadosSqlServer.AdicionarParametros("@Descricao", produto.Descricao);
                acessoDadosSqlServer.AdicionarParametros("@Fabricante", produto.Fabricante);
                acessoDadosSqlServer.AdicionarParametros("@Preco", produto.Preco);
                acessoDadosSqlServer.AdicionarParametros("@Lote", produto.Lote);
                acessoDadosSqlServer.AdicionarParametros("@DataFabricacao", produto.DataFabricacao);
                acessoDadosSqlServer.AdicionarParametros("@DataValidade", produto.DataValidade);
                acessoDadosSqlServer.AdicionarParametros("@Usuario", produto.CadastradoPor);

                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspProdutoAlterar").ToString();

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        public string Excluir(Produto produto)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdProduto", produto.IdProduto);
                acessoDadosSqlServer.AdicionarParametros("@Usuario", produto.CadastradoPor);

                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspProdutoExcluir").ToString();
            }
            catch (Exception exception)
            {
               return exception.Message;
            }
        }

        public ProdutoColecao ConsultaPorNome(string nome)
        {
            try
            {
                ProdutoColecao produtoColecao = new ProdutoColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@Nome", nome);
                DataTable datatableProduto = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspProdutoPesquisarPorNome");

                foreach (DataRow linha in datatableProduto.Rows)
                {
                    Produto produto = new Produto();

                    produto.IdProduto = Convert.ToInt32(linha["IdProduto"]);
                    produto.Nome = Convert.ToString(linha["Nome"]);
                    produto.Descricao = Convert.ToString(linha["Descricao"]);
                    produto.Fabricante = Convert.ToString(linha["Fabricante"]);
                    produto.Preco = Convert.ToDecimal(linha["Preco"]);
                    produto.Lote = Convert.ToString(linha["Lote"]);
                    produto.DataFabricacao = Convert.ToDateTime(linha["DataFabricacao"]);
                    produto.DataValidade = Convert.ToDateTime(linha["DataValidade"]);
                    produto.Quantidade = Convert.ToInt32(linha["Quantidade"]);
                    produto.DataCadastro = Convert.ToDateTime(linha["DataCadastro"]);
                    produto.CadastradoPor = Convert.ToString(linha["Usuario"]);
                    produto.DataModificacao = Convert.ToDateTime(linha["DataModificacao"]);


                    produtoColecao.Add(produto);
                }
                return produtoColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar o produto por nome. Detalhes " + ex.Message);
            }
        }
        public ProdutoColecao ConsultaPorId(string idproduto)
        {
            try
            {
                ProdutoColecao produtoColecao = new ProdutoColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdProduto", idproduto);
                DataTable datatableProduto = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspProdutoPesquisarPorId");

                foreach (DataRow linha in datatableProduto.Rows)
                {
                    Produto produto = new Produto();

                    produto.IdProduto = Convert.ToInt32(linha["IdProduto"]);
                    produto.Nome = Convert.ToString(linha["Nome"]);
                    produto.Descricao = Convert.ToString(linha["Descricao"]);
                    produto.Fabricante = Convert.ToString(linha["Fabricante"]);
                    produto.Preco = Convert.ToDecimal(linha["Preco"]);
                    produto.Lote = Convert.ToString(linha["Lote"]);
                    produto.DataFabricacao = Convert.ToDateTime(linha["DataFabricacao"]);
                    produto.DataValidade = Convert.ToDateTime(linha["DataValidade"]);
                    produto.Quantidade = Convert.ToInt32(linha["Quantidade"]);
                    produto.DataCadastro = Convert.ToDateTime(linha["DataCadastro"]);
                    produto.CadastradoPor = Convert.ToString(linha["Usuario"]);
                    produto.DataModificacao = Convert.ToDateTime(linha["DataModificacao"]);

                    produtoColecao.Add(produto);
                }
                return produtoColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar o produto por código. Detalhes " + ex.Message);
            }
        }
        public string Entrada(Produto produto)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdProduto", produto.IdProduto);
                acessoDadosSqlServer.AdicionarParametros("@Quantidade", produto.Quantidade);
                acessoDadosSqlServer.AdicionarParametros("@Usuario", produto.CadastradoPor);

                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspProdutoEstoqueEntrada").ToString();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Saida(Produto produto)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdProduto", produto.IdProduto);
                acessoDadosSqlServer.AdicionarParametros("@Quantidade", produto.Quantidade);
                acessoDadosSqlServer.AdicionarParametros("@Usuario", produto.CadastradoPor);

                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspProdutoEstoqueSaida").ToString();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
