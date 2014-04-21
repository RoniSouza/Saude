using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Data;

namespace Negocios
{
    public class FuncionarioNegocio
    {
        //instancia = criar um novo objeto baseado em um modelo
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();

        public string Inserir(Funcionario funcionario)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@Nome", funcionario.Nome);
                acessoDadosSqlServer.AdicionarParametros("@Endereco", funcionario.Endereco);
                acessoDadosSqlServer.AdicionarParametros("@Numero", funcionario.Numero);
                acessoDadosSqlServer.AdicionarParametros("@Bairro", funcionario.Bairro);
                acessoDadosSqlServer.AdicionarParametros("@Cidade", funcionario.Cidade);
                acessoDadosSqlServer.AdicionarParametros("@Estado", funcionario.Estado);
                acessoDadosSqlServer.AdicionarParametros("@CEP", funcionario.CEP);
                acessoDadosSqlServer.AdicionarParametros("@Cargo", funcionario.Cargo);
                acessoDadosSqlServer.AdicionarParametros("@RG", funcionario.RG);
                acessoDadosSqlServer.AdicionarParametros("@OrgaoEmissor", funcionario.OrgaoEmissor);
                acessoDadosSqlServer.AdicionarParametros("@UF", funcionario.UF);
                acessoDadosSqlServer.AdicionarParametros("@Naturalidade", funcionario.Naturalidade);
                acessoDadosSqlServer.AdicionarParametros("@Nacionalidade", funcionario.Nacionalidade);
                acessoDadosSqlServer.AdicionarParametros("@CPF", funcionario.CPF);
                acessoDadosSqlServer.AdicionarParametros("@TelefoneFixo", funcionario.TelefoneFixo);
                acessoDadosSqlServer.AdicionarParametros("@TelefoneCelular", funcionario.TelefoneCelular);
                acessoDadosSqlServer.AdicionarParametros("@DataNascimento", funcionario.DataNascimento);
                acessoDadosSqlServer.AdicionarParametros("@Email", funcionario.Email);
                acessoDadosSqlServer.AdicionarParametros("@DataAdmissao", funcionario.DataAdmissao);
                acessoDadosSqlServer.AdicionarParametros("@Usuario", funcionario.CadastradoPor);

                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspFuncionarioInserir").ToString();

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        public string Alterar(Funcionario funcionario)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdFuncionario", funcionario.IdPessoa);
                acessoDadosSqlServer.AdicionarParametros("@Nome", funcionario.Nome);
                acessoDadosSqlServer.AdicionarParametros("@Endereco", funcionario.Endereco);
                acessoDadosSqlServer.AdicionarParametros("@Numero", funcionario.Numero);
                acessoDadosSqlServer.AdicionarParametros("@Bairro", funcionario.Bairro);
                acessoDadosSqlServer.AdicionarParametros("@Cidade", funcionario.Cidade);
                acessoDadosSqlServer.AdicionarParametros("@Estado", funcionario.Estado);
                acessoDadosSqlServer.AdicionarParametros("@CEP", funcionario.CEP);
                acessoDadosSqlServer.AdicionarParametros("@Cargo", funcionario.Cargo);
                acessoDadosSqlServer.AdicionarParametros("@RG", funcionario.RG);
                acessoDadosSqlServer.AdicionarParametros("@OrgaoEmissor", funcionario.OrgaoEmissor);
                acessoDadosSqlServer.AdicionarParametros("@UF", funcionario.UF);
                acessoDadosSqlServer.AdicionarParametros("@Naturalidade", funcionario.Naturalidade);
                acessoDadosSqlServer.AdicionarParametros("@Nacionalidade", funcionario.Nacionalidade);
                acessoDadosSqlServer.AdicionarParametros("@CPF", funcionario.CPF);
                acessoDadosSqlServer.AdicionarParametros("@TelefoneFixo", funcionario.TelefoneFixo);
                acessoDadosSqlServer.AdicionarParametros("@TelefoneCelular", funcionario.TelefoneCelular);
                acessoDadosSqlServer.AdicionarParametros("@DataNascimento", funcionario.DataNascimento);
                acessoDadosSqlServer.AdicionarParametros("@Email", funcionario.Email);
                acessoDadosSqlServer.AdicionarParametros("@DataAdmissao", funcionario.DataAdmissao);
                acessoDadosSqlServer.AdicionarParametros("@Usuario", funcionario.CadastradoPor);

                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspFuncionarioAlterar").ToString();

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        public string Excluir(Funcionario funcionario)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdFuncionario", funcionario.IdPessoa);
                acessoDadosSqlServer.AdicionarParametros("@Usuario", funcionario.CadastradoPor);

                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspFuncionarioExcluir").ToString();
            }
            catch (Exception exception)
            {

                return exception.Message;
            }

        }

        public FuncionarioColecao ConsultaPorNome(string nome)
        {
            try
            {
                FuncionarioColecao funcionarioColecao = new FuncionarioColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@Nome", nome);
                DataTable datatableFuncionario = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspFuncionarioPesquisarPorNome");

                foreach (DataRow linha in datatableFuncionario.Rows)
                {
                    Funcionario funcionario = new Funcionario();

                    funcionario.IdPessoa = Convert.ToInt32(linha["IdFuncionario"]);
                    funcionario.Nome = Convert.ToString(linha["Nome"]);
                    funcionario.Endereco = Convert.ToString(linha["Endereco"]);
                    funcionario.Numero = Convert.ToString(linha["Numero"]);
                    funcionario.Bairro = Convert.ToString(linha["Bairro"]);
                    funcionario.Cidade = Convert.ToString(linha["Cidade"]);
                    funcionario.Estado = Convert.ToString(linha["Estado"]);
                    funcionario.CEP = Convert.ToString(linha["CEP"]);
                    funcionario.Cargo = Convert.ToString(linha["Cargo"]);
                    funcionario.RG = Convert.ToString(linha["RG"]);
                    funcionario.OrgaoEmissor = Convert.ToString(linha["OrgaoEmissor"]);
                    funcionario.UF = Convert.ToString(linha["UF"]);
                    funcionario.Naturalidade = Convert.ToString(linha["Naturalidade"]);
                    funcionario.Nacionalidade = Convert.ToString(linha["Nacionalidade"]);
                    funcionario.CPF = Convert.ToString(linha["CPF"]);
                    funcionario.TelefoneFixo = Convert.ToString(linha["TelefoneFixo"]);
                    funcionario.TelefoneCelular = Convert.ToString(linha["TelefoneCelular"]);
                    funcionario.DataNascimento = Convert.ToDateTime(linha["DataNascimento"]);
                    funcionario.Email = Convert.ToString(linha["Email"]);
                    funcionario.DataAdmissao = Convert.ToDateTime(linha["DataAdmissao"]);
                    funcionario.DataCadastro = Convert.ToDateTime(linha["DataCadastro"]);
                    funcionario.CadastradoPor = Convert.ToString(linha["Usuario"]);
                    funcionario.DataModificacao = Convert.ToDateTime(linha["DataModificacao"]);

                    funcionarioColecao.Add(funcionario);
                }
                return funcionarioColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar o funcionário por nome. Detalhes " + ex.Message);
            }
        }
        public FuncionarioColecao ConsultaPorId(int idfunc)
        {
            try
            {
                FuncionarioColecao funcionarioColecao = new FuncionarioColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdFuncionario", idfunc);
                DataTable datatableFuncionario = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspFuncionarioPesquisarPorId");

                foreach (DataRow linha in datatableFuncionario.Rows)
                {
                    Funcionario funcionario = new Funcionario();

                    funcionario.IdPessoa = Convert.ToInt32(linha["IdFuncionario"]);
                    funcionario.Nome = Convert.ToString(linha["Nome"]);
                    funcionario.Endereco = Convert.ToString(linha["Endereco"]);
                    funcionario.Numero = Convert.ToString(linha["Numero"]);
                    funcionario.Bairro = Convert.ToString(linha["Bairro"]);
                    funcionario.Cidade = Convert.ToString(linha["Cidade"]);
                    funcionario.Estado = Convert.ToString(linha["Estado"]);
                    funcionario.CEP = Convert.ToString(linha["CEP"]);
                    funcionario.Cargo = Convert.ToString(linha["Cargo"]);
                    funcionario.RG = Convert.ToString(linha["RG"]);
                    funcionario.OrgaoEmissor = Convert.ToString(linha["OrgaoEmissor"]);
                    funcionario.UF = Convert.ToString(linha["UF"]);
                    funcionario.Naturalidade = Convert.ToString(linha["Naturalidade"]);
                    funcionario.Nacionalidade = Convert.ToString(linha["Nacionalidade"]);
                    funcionario.CPF = Convert.ToString(linha["CPF"]);
                    funcionario.TelefoneFixo = Convert.ToString(linha["TelefoneFixo"]);
                    funcionario.TelefoneCelular = Convert.ToString(linha["TelefoneCelular"]);
                    funcionario.DataNascimento = Convert.ToDateTime(linha["DataNascimento"]);
                    funcionario.Email = Convert.ToString(linha["Email"]);
                    funcionario.DataAdmissao = Convert.ToDateTime(linha["DataAdmissao"]);
                    funcionario.DataCadastro = Convert.ToDateTime(linha["DataCadastro"]);
                    funcionario.CadastradoPor = Convert.ToString(linha["Usuario"]);
                    funcionario.DataModificacao = Convert.ToDateTime(linha["DataModificacao"]);

                    funcionarioColecao.Add(funcionario);
                }
                return funcionarioColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar o funcionário por código. Detalhes " + ex.Message);
            }
        }
    }
}
