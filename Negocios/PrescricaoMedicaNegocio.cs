using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Data;

namespace Negocios
{
    public class PrescricaoMedicaNegocio
    {
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();
        public string Inserir(PrescricaoMedica prescricaoMedica)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdPaciente", prescricaoMedica.IdPessoa);
                acessoDadosSqlServer.AdicionarParametros("@Tipo", prescricaoMedica.Tipo);
                acessoDadosSqlServer.AdicionarParametros("@Descricao", prescricaoMedica.Descricao);
                acessoDadosSqlServer.AdicionarParametros("@Horario", prescricaoMedica.Horario);
                acessoDadosSqlServer.AdicionarParametros("@NomeMedico", prescricaoMedica.NomeMedico);

                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPrescricaoMedicaInserir").ToString();

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        

        public PrescricaoMedicaColecao ConsultarPrescricoes(string idpaciente)
        {
            try
            {
                PrescricaoMedicaColecao prescricaoMedicaColecao = new PrescricaoMedicaColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdPaciente", idpaciente);
                DataTable datatablePrescricaoMedica = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPrescricaoMedicaPesquisar");

                foreach (DataRow linha in datatablePrescricaoMedica.Rows)
                {
                    PrescricaoMedica prescricaoMedica = new PrescricaoMedica();

                    prescricaoMedica.IdPrescricaoMedica = Convert.ToInt32(linha["IdPrescricaoMedica"]);
                    prescricaoMedica.IdPessoa = Convert.ToInt32(linha["IdPaciente"]);
                    prescricaoMedica.Tipo = Convert.ToString(linha["Tipo"]);
                    prescricaoMedica.Descricao = Convert.ToString(linha["Descricao"]);
                    prescricaoMedica.Horario = Convert.ToDateTime(linha["Horario"]);
                    prescricaoMedica.TarefaRealizada = Convert.ToBoolean(linha["TarefaRealizada"]);
                    prescricaoMedica.DataCadastro = Convert.ToDateTime(linha["DataCadastro"]);
                    prescricaoMedica.NomeEnfermeiro = Convert.ToString(linha["NomeEnfermeiro"]);
                    prescricaoMedica.DataModificacao = Convert.ToDateTime(linha["DataModificacao"]);

                    prescricaoMedicaColecao.Add(prescricaoMedica);
                }
                return prescricaoMedicaColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível pesquisar. Detalhes " + ex.Message);
            }
        }
        public PrescricaoMedicaColecao ConsultarPrescricoesMedicasRealizadas(string idpaciente)
        {
            try
            {
                PrescricaoMedicaColecao prescricaoMedicaColecao = new PrescricaoMedicaColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdPaciente", idpaciente);
                DataTable datatablePrescricaoMedica = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPrescricaoMedicaRealizadasPesquisar");

                foreach (DataRow linha in datatablePrescricaoMedica.Rows)
                {
                    PrescricaoMedica prescricaoMedica = new PrescricaoMedica();

                    prescricaoMedica.IdPrescricaoMedica = Convert.ToInt32(linha["IdPrescricaoMedica"]);
                    prescricaoMedica.IdPessoa = Convert.ToInt32(linha["IdPaciente"]);
                    prescricaoMedica.Tipo = Convert.ToString(linha["Tipo"]);
                    prescricaoMedica.Descricao = Convert.ToString(linha["Descricao"]);
                    prescricaoMedica.Horario = Convert.ToDateTime(linha["Horario"]);
                    //prescricaoMedicaClass.TarefaRealizada = Convert.ToBoolean(linha["TarefaRealizada"]);
                    prescricaoMedica.NomeEnfermeiro = Convert.ToString(linha["NomeEnfermeiro"]);
                    prescricaoMedica.HoraRealizacaoTarefa = Convert.ToString(linha["HoraRealizacaoTarefa"]);
                    prescricaoMedica.DataCadastro = Convert.ToDateTime(linha["DataCadastro"]);
                    prescricaoMedica.DataModificacao = Convert.ToDateTime(linha["DataModificacao"]);

                    prescricaoMedicaColecao.Add(prescricaoMedica);
                }
                return prescricaoMedicaColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível pesquisar. Detalhes " + ex.Message);
            }
        }
        public PrescricaoMedicaColecao ConsultarPrescricoesMedicasAFazer(string idpaciente)
        {
            try
            {
                PrescricaoMedicaColecao prescricaoMedicaColecao = new PrescricaoMedicaColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdPaciente", idpaciente);
                DataTable datatablePrescricaoMedica = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPrescricaoMedicaAFazerPesquisar");

                foreach (DataRow linha in datatablePrescricaoMedica.Rows)
                {
                    PrescricaoMedica prescricaoMedica = new PrescricaoMedica();

                    prescricaoMedica.IdPrescricaoMedica = Convert.ToInt32(linha["IdPrescricaoMedica"]);
                    prescricaoMedica.IdPessoa = Convert.ToInt32(linha["IdPaciente"]);
                    prescricaoMedica.Tipo = Convert.ToString(linha["Tipo"]);
                    prescricaoMedica.Descricao = Convert.ToString(linha["Descricao"]);
                    prescricaoMedica.Horario = Convert.ToDateTime(linha["Horario"]);
                    //prescricaoMedicaClass.TarefaRealizada = Convert.ToBoolean(linha["TarefaRealizada"]);
                    prescricaoMedica.NomeEnfermeiro = Convert.ToString(linha["NomeEnfermeiro"]);
                    prescricaoMedica.HoraRealizacaoTarefa = Convert.ToString(linha["HoraRealizacaoTarefa"]);
                    prescricaoMedica.DataCadastro = Convert.ToDateTime(linha["DataCadastro"]);
                    prescricaoMedica.DataModificacao = Convert.ToDateTime(linha["DataModificacao"]);

                    prescricaoMedicaColecao.Add(prescricaoMedica);
                }
                return prescricaoMedicaColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível pesquisar. Detalhes " + ex.Message);
            }
        }
        public string MarcarTarefaRealizada(PrescricaoMedica prescricaoMedica)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdPrescricaoMedica", prescricaoMedica.IdPrescricaoMedica);
                acessoDadosSqlServer.AdicionarParametros("@TarefaRealizada", prescricaoMedica.TarefaRealizada);
                acessoDadosSqlServer.AdicionarParametros("@NomeEnfermeiro", prescricaoMedica.NomeEnfermeiro);
                acessoDadosSqlServer.AdicionarParametros("@HoraRealizacaoTarefa", prescricaoMedica.HoraRealizacaoTarefa);

                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPrescricaoMedicaMarcarTarefaRealizada").ToString();

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

    }
}
