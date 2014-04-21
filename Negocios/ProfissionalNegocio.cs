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
    public class ProfissionalNegocio
    {
        //instancia = criar um novo objeto baseado em um modelo
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();

        public string Inserir(Profissional profissional)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@Nome", profissional.Nome);
                acessoDadosSqlServer.AdicionarParametros("@Endereco", profissional.Endereco);
                acessoDadosSqlServer.AdicionarParametros("@Numero", profissional.Numero);
                acessoDadosSqlServer.AdicionarParametros("@Bairro", profissional.Bairro);
                acessoDadosSqlServer.AdicionarParametros("@Cidade", profissional.Cidade);
                acessoDadosSqlServer.AdicionarParametros("@Estado", profissional.Estado);
                acessoDadosSqlServer.AdicionarParametros("@CEP", profissional.CEP);
                acessoDadosSqlServer.AdicionarParametros("@Cargo", profissional.Cargo);
                acessoDadosSqlServer.AdicionarParametros("@RG", profissional.RG);
                acessoDadosSqlServer.AdicionarParametros("@OrgaoEmissor", profissional.OrgaoEmissor);
                acessoDadosSqlServer.AdicionarParametros("@UF", profissional.UF);
                acessoDadosSqlServer.AdicionarParametros("@Naturalidade", profissional.Naturalidade);
                acessoDadosSqlServer.AdicionarParametros("@Nacionalidade", profissional.Nacionalidade);
                acessoDadosSqlServer.AdicionarParametros("@ConselhoClasse", profissional.Cargo);
                acessoDadosSqlServer.AdicionarParametros("@NumeroRegistro", profissional.NumeroRegistro);
                acessoDadosSqlServer.AdicionarParametros("@UFRegistro", profissional.UFRegistro);
                acessoDadosSqlServer.AdicionarParametros("@CPF", profissional.CPF);
                acessoDadosSqlServer.AdicionarParametros("@TelefoneFixo", profissional.TelefoneFixo);
                acessoDadosSqlServer.AdicionarParametros("@TelefoneCelular", profissional.TelefoneCelular);
                acessoDadosSqlServer.AdicionarParametros("@DataNascimento", profissional.DataNascimento);
                acessoDadosSqlServer.AdicionarParametros("@Email", profissional.Email);
                acessoDadosSqlServer.AdicionarParametros("@DataAdmissao", profissional.DataAdmissao);
                acessoDadosSqlServer.AdicionarParametros("@Usuario", profissional.CadastradoPor);
                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspProfissionalInserir").ToString();

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        public string Alterar(Profissional profissional)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdProfissional", profissional.IdPessoa);
                acessoDadosSqlServer.AdicionarParametros("@Nome", profissional.Nome);
                acessoDadosSqlServer.AdicionarParametros("@Endereco", profissional.Endereco);
                acessoDadosSqlServer.AdicionarParametros("@Numero", profissional.Numero);
                acessoDadosSqlServer.AdicionarParametros("@Bairro", profissional.Bairro);
                acessoDadosSqlServer.AdicionarParametros("@Cidade", profissional.Cidade);
                acessoDadosSqlServer.AdicionarParametros("@Estado", profissional.Estado);
                acessoDadosSqlServer.AdicionarParametros("@CEP", profissional.CEP);
                acessoDadosSqlServer.AdicionarParametros("@Cargo", profissional.Cargo);
                acessoDadosSqlServer.AdicionarParametros("@RG", profissional.RG);
                acessoDadosSqlServer.AdicionarParametros("@OrgaoEmissor", profissional.OrgaoEmissor);
                acessoDadosSqlServer.AdicionarParametros("@UF", profissional.UF);
                acessoDadosSqlServer.AdicionarParametros("@Naturalidade", profissional.Naturalidade);
                acessoDadosSqlServer.AdicionarParametros("@Nacionalidade", profissional.Nacionalidade);
                acessoDadosSqlServer.AdicionarParametros("@ConselhoClasse", profissional.Cargo);
                acessoDadosSqlServer.AdicionarParametros("@NumeroRegistro", profissional.NumeroRegistro);
                acessoDadosSqlServer.AdicionarParametros("@UFRegistro", profissional.UFRegistro);
                acessoDadosSqlServer.AdicionarParametros("@CPF", profissional.CPF);
                acessoDadosSqlServer.AdicionarParametros("@TelefoneFixo", profissional.TelefoneFixo);
                acessoDadosSqlServer.AdicionarParametros("@TelefoneCelular", profissional.TelefoneCelular);
                acessoDadosSqlServer.AdicionarParametros("@DataNascimento", profissional.DataNascimento);
                acessoDadosSqlServer.AdicionarParametros("@Email", profissional.Email);
                acessoDadosSqlServer.AdicionarParametros("@DataAdmissao", profissional.DataAdmissao);
                acessoDadosSqlServer.AdicionarParametros("@Usuario", profissional.CadastradoPor);

                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspProfissionalAlterar").ToString();

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        public string Excluir(Profissional profissional)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdProfissional", profissional.IdPessoa);
                acessoDadosSqlServer.AdicionarParametros("@Usuario", profissional.CadastradoPor);
                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspProfissionalExcluir").ToString();
            }
            catch (Exception exception)
            {

                return exception.Message;
            }

        }

        public ProfissionalColecao ConsultaPorNome(string nome)
        {
            try
            {
                ProfissionalColecao profissionalColecao = new ProfissionalColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@Nome", nome);
                DataTable datatableProfissional = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspProfissionalPesquisarPorNome");

                foreach (DataRow linha in datatableProfissional.Rows)
                {
                    Profissional profissional = new Profissional();

                    profissional.IdPessoa = Convert.ToInt32(linha["IdProfissional"]);
                    profissional.Nome = Convert.ToString(linha["Nome"]);
                    profissional.Endereco = Convert.ToString(linha["Endereco"]);
                    profissional.Bairro = Convert.ToString(linha["Bairro"]);
                    profissional.Numero = Convert.ToString(linha["Numero"]);
                    profissional.Cidade = Convert.ToString(linha["Cidade"]);
                    profissional.Estado = Convert.ToString(linha["Estado"]);
                    profissional.CEP = Convert.ToString(linha["CEP"]);
                    profissional.Cargo = Convert.ToString(linha["Cargo"]);
                    profissional.RG = Convert.ToString(linha["RG"]);
                    profissional.OrgaoEmissor = Convert.ToString(linha["OrgaoEmissor"]);
                    profissional.UF= Convert.ToString(linha["UF"]);
                    profissional.Naturalidade = Convert.ToString(linha["Naturalidade"]);
                    profissional.Nacionalidade = Convert.ToString(linha["Nacionalidade"]);
                    profissional.ConselhoClasse = Convert.ToString(linha["ConselhoClasse"]);
                    profissional.NumeroRegistro = Convert.ToString(linha["NumeroRegistro"]);
                    profissional.UFRegistro = Convert.ToString(linha["UFRegistro"]);
                    profissional.CPF = Convert.ToString(linha["CPF"]);
                    profissional.TelefoneFixo = Convert.ToString(linha["TelefoneFixo"]);
                    profissional.TelefoneCelular = Convert.ToString(linha["TelefoneCelular"]);
                    profissional.DataNascimento = Convert.ToDateTime(linha["DataNascimento"]);
                    profissional.Email = Convert.ToString(linha["Email"]);
                    profissional.DataAdmissao = Convert.ToDateTime(linha["DataAdmissao"]);
                    profissional.DataCadastro = Convert.ToDateTime(linha["DataCadastro"]);
                    profissional.CadastradoPor = Convert.ToString(linha["Usuario"]);
                    profissional.DataModificacao = Convert.ToDateTime(linha["DataModificacao"]);


                    profissionalColecao.Add(profissional);
                }
                return profissionalColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar o médico por nome. Detalhes " + ex.Message);
            }
        }
        public ProfissionalColecao ConsultaPorId(int idpessoa)
        {
            try
            {
                ProfissionalColecao profissionalColecao = new ProfissionalColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdProfissional", idpessoa);
                DataTable datatableProfissional = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspProfissionalPesquisarPorId");

                foreach (DataRow linha in datatableProfissional.Rows)
                {
                    Profissional profissional = new Profissional();

                    profissional.IdPessoa = Convert.ToInt32(linha["IdProfissional"]);
                    profissional.Nome = Convert.ToString(linha["Nome"]);
                    profissional.Endereco = Convert.ToString(linha["Endereco"]);
                    profissional.Numero = Convert.ToString(linha["Numero"]);
                    profissional.Bairro = Convert.ToString(linha["Bairro"]);
                    profissional.Cidade = Convert.ToString(linha["Cidade"]);
                    profissional.Estado = Convert.ToString(linha["Estado"]);
                    profissional.CEP = Convert.ToString(linha["CEP"]);
                    profissional.Cargo = Convert.ToString(linha["Cargo"]);
                    profissional.RG = Convert.ToString(linha["RG"]);
                    profissional.OrgaoEmissor = Convert.ToString(linha["OrgaoEmissor"]);
                    profissional.UF = Convert.ToString(linha["UF"]);
                    profissional.Naturalidade = Convert.ToString(linha["Naturalidade"]);
                    profissional.Nacionalidade = Convert.ToString(linha["Nacionalidade"]);
                    profissional.ConselhoClasse = Convert.ToString(linha["ConselhoClasse"]);
                    profissional.NumeroRegistro = Convert.ToString(linha["NumeroRegistro"]);
                    profissional.UFRegistro = Convert.ToString(linha["UFRegistro"]);
                    profissional.CPF = Convert.ToString(linha["CPF"]);
                    profissional.TelefoneFixo = Convert.ToString(linha["TelefoneFixo"]);
                    profissional.TelefoneCelular = Convert.ToString(linha["TelefoneCelular"]);
                    profissional.DataNascimento = Convert.ToDateTime(linha["DataNascimento"]);
                    profissional.Email = Convert.ToString(linha["Email"]);
                    profissional.DataAdmissao = Convert.ToDateTime(linha["DataAdmissao"]);
                    profissional.DataCadastro = Convert.ToDateTime(linha["DataCadastro"]);
                    profissional.CadastradoPor = Convert.ToString(linha["Usuario"]);
                    profissional.DataModificacao = Convert.ToDateTime(linha["DataModificacao"]);


                    profissionalColecao.Add(profissional);
                }
                return profissionalColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar o paciente por código. Detalhes " + ex.Message);
            }
        }
    }
}
