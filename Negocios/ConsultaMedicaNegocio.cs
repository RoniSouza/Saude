using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Data;

namespace Negocios
{
    public class ConsultaMedicaNegocio
    {
        //instancia = criar um novo objeto baseado em um modelo
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();

        public string Inserir(ConsultaMedica consultaMedica)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@NomeMedico", consultaMedica.NomeMedico);
                acessoDadosSqlServer.AdicionarParametros("@NomePaciente", consultaMedica.NomePaciente);
                acessoDadosSqlServer.AdicionarParametros("@Data", consultaMedica.Data);
                acessoDadosSqlServer.AdicionarParametros("@Hora", consultaMedica.Hora);
                acessoDadosSqlServer.AdicionarParametros("@TipoConsulta", consultaMedica.TipoConsulta);
                acessoDadosSqlServer.AdicionarParametros("@Observacoes", consultaMedica.Observacoes);
                acessoDadosSqlServer.AdicionarParametros("@Usuario", consultaMedica.CadastradoPor);

                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspConsultaMedicaInserir").ToString();

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        public string Alterar(ConsultaMedica consultaMedica)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdConsultaMedica", consultaMedica.IdConsulta);
                acessoDadosSqlServer.AdicionarParametros("@NomeMedico", consultaMedica.NomeMedico);
                acessoDadosSqlServer.AdicionarParametros("@NomePaciente", consultaMedica.NomePaciente);
                acessoDadosSqlServer.AdicionarParametros("@Data", consultaMedica.Data);
                acessoDadosSqlServer.AdicionarParametros("@Hora", consultaMedica.Hora);
                acessoDadosSqlServer.AdicionarParametros("@TipoConsulta", consultaMedica.TipoConsulta);
                acessoDadosSqlServer.AdicionarParametros("@Observacoes", consultaMedica.Observacoes);
                acessoDadosSqlServer.AdicionarParametros("@Usuario", consultaMedica.CadastradoPor);

                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspConsultaMedicaAlterar").ToString();

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public string Excluir(ConsultaMedica consultamedica, string usuario)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdConsultaMedica", consultamedica.IdConsulta);
                acessoDadosSqlServer.AdicionarParametros("@Usuario", usuario);

                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspConsultaMedicaExcluir").ToString();
            }
            catch (Exception exception)
            {

                return exception.Message;
            }

        }

        public ConsultaMedicaColecao ConsultaPorPaciente(string paciente)
        {
            try
            {
                ConsultaMedicaColecao consultaMedicaColecao = new ConsultaMedicaColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@NomePaciente", paciente);
                DataTable datatableConsultaMedica = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspConsultaMedicaPesquisarPaciente");

                foreach (DataRow linha in datatableConsultaMedica.Rows)
                {
                    ConsultaMedica consultaMedica = new ConsultaMedica();

                    consultaMedica.IdConsulta = Convert.ToInt32(linha["IdConsultaMedica"]);
                    consultaMedica.NomeMedico = Convert.ToString(linha["NomeMedico"]);
                    consultaMedica.NomePaciente = Convert.ToString(linha["NomePaciente"]);
                    consultaMedica.Data = Convert.ToDateTime(linha["Data"]);
                    consultaMedica.Hora = Convert.ToString(linha["Hora"]);
                    consultaMedica.TipoConsulta = Convert.ToString(linha["TipoConsulta"]);
                    consultaMedica.DataCadastro = Convert.ToDateTime(linha["DataCadastro"]);
                    consultaMedica.CadastradoPor = Convert.ToString(linha["Usuario"]);
                    consultaMedica.DataModificacao = Convert.ToDateTime(linha["DataModificacao"]);


                    consultaMedicaColecao.Add(consultaMedica);
                }
                return consultaMedicaColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar o nome. Detalhes " + ex.Message);
            }
        }
        public ConsultaMedicaColecao ConsultaPorMedico(string medico)
        {
            try
            {
                ConsultaMedicaColecao consultaMedicaColecao = new ConsultaMedicaColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@NomeMedico", medico);
                DataTable datatableConsultaMedica = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspConsultaMedicaPesquisarMedico");

                foreach (DataRow linha in datatableConsultaMedica.Rows)
                {
                    ConsultaMedica consultaMedica = new ConsultaMedica();

                    consultaMedica.IdConsulta = Convert.ToInt32(linha["IdConsultaMedica"]);
                    consultaMedica.NomeMedico = Convert.ToString(linha["NomeMedico"]);
                    consultaMedica.NomePaciente = Convert.ToString(linha["NomePaciente"]);
                    consultaMedica.Data = Convert.ToDateTime(linha["Data"]);
                    consultaMedica.Hora = Convert.ToString(linha["Hora"]);
                    consultaMedica.TipoConsulta = Convert.ToString(linha["TipoConsulta"]);
                    consultaMedica.DataCadastro = Convert.ToDateTime(linha["DataCadastro"]);
                    consultaMedica.CadastradoPor = Convert.ToString(linha["Usuario"]);
                    consultaMedica.DataModificacao = Convert.ToDateTime(linha["DataModificacao"]);

                    consultaMedicaColecao.Add(consultaMedica);
                }
                return consultaMedicaColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar o nome. Detalhes " + ex.Message);
            }
        }
    
    }
}
