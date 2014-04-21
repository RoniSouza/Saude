using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Data;


namespace Negocios
{
    public class PacienteNegocio
    {
        //instancia = criar um novo objeto baseado em um modelo
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();

        public string Inserir(Paciente paciente)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@Nome", paciente.Nome);
                acessoDadosSqlServer.AdicionarParametros("@Endereco", paciente.Endereco);
                acessoDadosSqlServer.AdicionarParametros("@Numero", paciente.Numero);
                acessoDadosSqlServer.AdicionarParametros("@Bairro", paciente.Bairro);
                acessoDadosSqlServer.AdicionarParametros("@Cidade", paciente.Cidade);
                acessoDadosSqlServer.AdicionarParametros("@Estado", paciente.Estado);
                acessoDadosSqlServer.AdicionarParametros("@CEP", paciente.CEP);
                acessoDadosSqlServer.AdicionarParametros("@RG", paciente.RG);
                acessoDadosSqlServer.AdicionarParametros("@OrgaoEmissor", paciente.OrgaoEmissor);
                acessoDadosSqlServer.AdicionarParametros("@UF", paciente.UF);
                acessoDadosSqlServer.AdicionarParametros("@Naturalidade", paciente.Naturalidade);
                acessoDadosSqlServer.AdicionarParametros("@Nacionalidade", paciente.Nacionalidade);
                acessoDadosSqlServer.AdicionarParametros("@CorRaca", paciente.CorRaca);
                acessoDadosSqlServer.AdicionarParametros("@CPF", paciente.CPF);
                acessoDadosSqlServer.AdicionarParametros("@Sexo", paciente.Sexo);
                acessoDadosSqlServer.AdicionarParametros("@Leito", paciente.Leito);
                acessoDadosSqlServer.AdicionarParametros("@TelefoneFixo", paciente.TelefoneFixo);
                acessoDadosSqlServer.AdicionarParametros("@TelefoneCelular", paciente.TelefoneCelular);
                acessoDadosSqlServer.AdicionarParametros("@DataNascimento", paciente.DataNascimento);
                acessoDadosSqlServer.AdicionarParametros("@Email", paciente.Email);
                acessoDadosSqlServer.AdicionarParametros("@Responsavel", paciente.Responsavel);
                acessoDadosSqlServer.AdicionarParametros("@RGResponsavel", paciente.RGResponsavel);
                acessoDadosSqlServer.AdicionarParametros("@TelefoneResponsavel", paciente.TelefoneResponsavel);
                acessoDadosSqlServer.AdicionarParametros("@Pai", paciente.Pai);
                acessoDadosSqlServer.AdicionarParametros("@Mae", paciente.Mae);
                acessoDadosSqlServer.AdicionarParametros("@Convenio", paciente.Convenio);
                acessoDadosSqlServer.AdicionarParametros("@NumeroInscricao", paciente.NumeroInscricao);
                acessoDadosSqlServer.AdicionarParametros("@ValidadeCartao", paciente.ValidadeCartao);
                acessoDadosSqlServer.AdicionarParametros("@TipoPlano", paciente.TipoPlano);
                acessoDadosSqlServer.AdicionarParametros("@Usuario", paciente.CadastradoPor);

                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPacienteInserir").ToString();

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        public string Alterar(Paciente paciente)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdPaciente", paciente.IdPessoa);
                acessoDadosSqlServer.AdicionarParametros("@Nome", paciente.Nome);
                acessoDadosSqlServer.AdicionarParametros("@Endereco", paciente.Endereco);
                acessoDadosSqlServer.AdicionarParametros("@Numero", paciente.Numero);
                acessoDadosSqlServer.AdicionarParametros("@Bairro", paciente.Bairro);
                acessoDadosSqlServer.AdicionarParametros("@Cidade", paciente.Cidade);
                acessoDadosSqlServer.AdicionarParametros("@Estado", paciente.Estado);
                acessoDadosSqlServer.AdicionarParametros("@CEP", paciente.CEP);
                acessoDadosSqlServer.AdicionarParametros("@RG", paciente.RG);
                acessoDadosSqlServer.AdicionarParametros("@OrgaoEmissor", paciente.OrgaoEmissor);
                acessoDadosSqlServer.AdicionarParametros("@UF", paciente.UF);
                acessoDadosSqlServer.AdicionarParametros("@Naturalidade", paciente.Naturalidade);
                acessoDadosSqlServer.AdicionarParametros("@Nacionalidade", paciente.Nacionalidade);
                acessoDadosSqlServer.AdicionarParametros("@CorRaca", paciente.CorRaca);
                acessoDadosSqlServer.AdicionarParametros("@CPF", paciente.CPF);
                acessoDadosSqlServer.AdicionarParametros("@Sexo", paciente.Sexo);
                acessoDadosSqlServer.AdicionarParametros("@Leito", paciente.Leito);
                acessoDadosSqlServer.AdicionarParametros("@TelefoneFixo", paciente.TelefoneFixo);
                acessoDadosSqlServer.AdicionarParametros("@TelefoneCelular", paciente.TelefoneCelular);
                acessoDadosSqlServer.AdicionarParametros("@DataNascimento", paciente.DataNascimento);
                acessoDadosSqlServer.AdicionarParametros("@Email", paciente.Email);
                acessoDadosSqlServer.AdicionarParametros("@Responsavel", paciente.Responsavel);
                acessoDadosSqlServer.AdicionarParametros("@RGResponsavel", paciente.RGResponsavel);
                acessoDadosSqlServer.AdicionarParametros("@TelefoneResponsavel", paciente.TelefoneResponsavel);
                acessoDadosSqlServer.AdicionarParametros("@Pai", paciente.Pai);
                acessoDadosSqlServer.AdicionarParametros("@Mae", paciente.Mae);
                acessoDadosSqlServer.AdicionarParametros("@Convenio", paciente.Convenio);
                acessoDadosSqlServer.AdicionarParametros("@NumeroInscricao", paciente.NumeroInscricao);
                acessoDadosSqlServer.AdicionarParametros("@ValidadeCartao", paciente.ValidadeCartao);
                acessoDadosSqlServer.AdicionarParametros("@TipoPlano", paciente.TipoPlano);
                acessoDadosSqlServer.AdicionarParametros("@Usuario", paciente.CadastradoPor);

                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPacienteAlterar").ToString();

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        public string Excluir(Paciente paciente)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdPaciente", paciente.IdPessoa);
                acessoDadosSqlServer.AdicionarParametros("@Usuario", paciente.CadastradoPor);
      
                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPacienteExcluir").ToString();
            }
            catch (Exception exception)
            {

                return exception.Message;
            }

        }

        public PacienteColecao ConsultaPorNome(string nome)
        {
            try
            {
                PacienteColecao pacienteColecao = new PacienteColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@Nome", nome);
                DataTable datatablePaciente = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPacientePesquisarPorNome");

                foreach (DataRow linha in datatablePaciente.Rows)
                {
                    Paciente paciente = new Paciente();

                    paciente.IdPessoa = Convert.ToInt32(linha["IdPaciente"]);
                    paciente.Nome = Convert.ToString(linha["Nome"]);
                    paciente.Endereco = Convert.ToString(linha["Endereco"]);
                    paciente.Numero = Convert.ToString(linha["Numero"]);
                    paciente.Bairro = Convert.ToString(linha["Bairro"]);
                    paciente.Cidade = Convert.ToString(linha["Cidade"]);
                    paciente.Estado = Convert.ToString(linha["Estado"]);
                    paciente.CEP = Convert.ToString(linha["CEP"]);
                    paciente.RG = Convert.ToString(linha["RG"]);
                    paciente.OrgaoEmissor = Convert.ToString(linha["OrgaoEmissor"]);
                    paciente.UF = Convert.ToString(linha["UF"]);
                    paciente.Naturalidade = Convert.ToString(linha["Naturalidade"]);
                    paciente.Nacionalidade = Convert.ToString(linha["Nacionalidade"]);
                    paciente.CorRaca = Convert.ToString(linha["CorRaca"]);
                    paciente.Sexo = Convert.ToString(linha["Sexo"]);
                    paciente.Leito = Convert.ToString(linha["Leito"]);
                    paciente.CPF = Convert.ToString(linha["CPF"]);
                    paciente.TelefoneFixo = Convert.ToString(linha["TelefoneFixo"]);
                    paciente.TelefoneCelular = Convert.ToString(linha["TelefoneCelular"]);
                    paciente.DataNascimento = Convert.ToDateTime(linha["DataNascimento"]);
                    paciente.Email = Convert.ToString(linha["Email"]);
                    paciente.Responsavel = Convert.ToString(linha["Responsavel"]);
                    paciente.RGResponsavel = Convert.ToString(linha["RGResponsavel"]);
                    paciente.TelefoneResponsavel = Convert.ToString(linha["TelefoneResponsavel"]);
                    paciente.Pai = Convert.ToString(linha["Pai"]);
                    paciente.Mae = Convert.ToString(linha["Mae"]);
                   // paciente.QRCode = (byte[])linha["QRCode"];
                    paciente.Convenio = Convert.ToString(linha["Convenio"]);
                    paciente.NumeroInscricao = Convert.ToString(linha["NumeroInscricao"]);
                    paciente.ValidadeCartao = Convert.ToString(linha["ValidadeCartao"]);
                    paciente.TipoPlano = Convert.ToString(linha["TipoPlano"]);
                    paciente.DataCadastro = Convert.ToDateTime(linha["DataCadastro"]);
                    paciente.CadastradoPor = Convert.ToString(linha["Usuario"]);
                    paciente.DataModificacao = Convert.ToDateTime(linha["DataModificacao"]);

                    pacienteColecao.Add(paciente);
                }
                return pacienteColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar o paciente por nome. Detalhes " + ex.Message);
            }
        }
        public PacienteColecao ConsultaPorId(int idcliente)
        {
            try
            {
                PacienteColecao pacienteColecao = new PacienteColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdPaciente", idcliente);
                DataTable datatablePaciente = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPacientePesquisarPorId");

                foreach (DataRow linha in datatablePaciente.Rows)
                {
                    Paciente paciente = new Paciente();

                    paciente.IdPessoa = Convert.ToInt32(linha["IdPaciente"]);
                    paciente.Nome = Convert.ToString(linha["Nome"]);
                    paciente.Endereco = Convert.ToString(linha["Endereco"]);
                    paciente.Numero = Convert.ToString(linha["Numero"]);
                    paciente.Bairro = Convert.ToString(linha["Bairro"]);
                    paciente.Cidade = Convert.ToString(linha["Cidade"]);
                    paciente.Estado = Convert.ToString(linha["Estado"]);
                    paciente.CEP = Convert.ToString(linha["CEP"]);
                    paciente.RG = Convert.ToString(linha["RG"]);
                    paciente.OrgaoEmissor = Convert.ToString(linha["OrgaoEmissor"]);
                    paciente.UF = Convert.ToString(linha["UF"]);
                    paciente.Naturalidade = Convert.ToString(linha["Naturalidade"]);
                    paciente.Nacionalidade = Convert.ToString(linha["Nacionalidade"]);
                    paciente.CorRaca = Convert.ToString(linha["CorRaca"]);
                    paciente.Sexo = Convert.ToString(linha["Sexo"]);
                    paciente.Leito = Convert.ToString(linha["Leito"]);
                    paciente.CPF = Convert.ToString(linha["CPF"]);
                    paciente.TelefoneFixo = Convert.ToString(linha["TelefoneFixo"]);
                    paciente.TelefoneCelular = Convert.ToString(linha["TelefoneCelular"]);
                    paciente.DataNascimento = Convert.ToDateTime(linha["DataNascimento"]);
                    paciente.Email = Convert.ToString(linha["Email"]);
                    paciente.Responsavel = Convert.ToString(linha["Responsavel"]);
                    paciente.RGResponsavel = Convert.ToString(linha["RGResponsavel"]);
                    paciente.TelefoneResponsavel = Convert.ToString(linha["TelefoneResponsavel"]);
                    paciente.Pai = Convert.ToString(linha["Pai"]);
                    paciente.Mae = Convert.ToString(linha["Mae"]);
                    paciente.Convenio = Convert.ToString(linha["Convenio"]);
                    paciente.NumeroInscricao = Convert.ToString(linha["NumeroInscricao"]);
                    paciente.ValidadeCartao = Convert.ToString(linha["ValidadeCartao"]);
                    paciente.TipoPlano = Convert.ToString(linha["TipoPlano"]);
                    paciente.DataCadastro = Convert.ToDateTime(linha["DataCadastro"]);
                    paciente.CadastradoPor = Convert.ToString(linha["Usuario"]);
                    paciente.DataModificacao = Convert.ToDateTime(linha["DataModificacao"]);


                    pacienteColecao.Add(paciente);
                }
                return pacienteColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar o paciente por código. Detalhes " + ex.Message);
            }
        }
        public string AlterarQRCode(Paciente paciente)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdPaciente", paciente.IdPessoa);
                acessoDadosSqlServer.AdicionarParametros("@QRCode", paciente.QRCode);

                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPacienteAlterarQRCode").ToString();

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
    }
}
