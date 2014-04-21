using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Negocios
{
    public class PrescricaoEnfermagemNegocio
    {
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();
        public string Inserir(PrescricaoEnfermagem prescricaoEnfermagemClass)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdPaciente", prescricaoEnfermagemClass.IdPessoa);
                acessoDadosSqlServer.AdicionarParametros("@Tipo", prescricaoEnfermagemClass.Tipo);
                acessoDadosSqlServer.AdicionarParametros("@Descricao", prescricaoEnfermagemClass.Descricao);
                acessoDadosSqlServer.AdicionarParametros("@Horario", prescricaoEnfermagemClass.Horario);
                acessoDadosSqlServer.AdicionarParametros("@NomeEnfermeiro", prescricaoEnfermagemClass.NomeEnfermeiro);

                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPrescricaoEnfermagemInserir").ToString();

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }


        public PrescricaoEnfermagemColecao ConsultarPrescricoes(string idpaciente)
        {
            try
            {
                PrescricaoEnfermagemColecao prescricaoEnfermagemColecao = new PrescricaoEnfermagemColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdPaciente", idpaciente);
                DataTable datatablePrescricaoEnfermagem = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPrescricaoEnfermagemPesquisar");

                foreach (DataRow linha in datatablePrescricaoEnfermagem.Rows)
                {
                    PrescricaoEnfermagem prescricaoEnfermagemClass = new PrescricaoEnfermagem();

                    prescricaoEnfermagemClass.IdPrescricaoEnfermagem = Convert.ToInt32(linha["IdPrescricaoEnfermagem"]);
                    prescricaoEnfermagemClass.IdPessoa = Convert.ToInt32(linha["IdPaciente"]);
                    prescricaoEnfermagemClass.Tipo = Convert.ToString(linha["Tipo"]);
                    prescricaoEnfermagemClass.Descricao = Convert.ToString(linha["Descricao"]);
                    prescricaoEnfermagemClass.Horario = Convert.ToDateTime(linha["Horario"]);
                    prescricaoEnfermagemClass.TarefaRealizada = Convert.ToBoolean(linha["TarefaRealizada"]);
                    prescricaoEnfermagemClass.DataCadastro = Convert.ToDateTime(linha["DataCadastro"]);
                    prescricaoEnfermagemClass.NomeEnfermeiro = Convert.ToString(linha["NomeEnfermeiro"]);
                    prescricaoEnfermagemClass.DataModificacao = Convert.ToDateTime(linha["DataModificacao"]);

                    prescricaoEnfermagemColecao.Add(prescricaoEnfermagemClass);
                }
                return prescricaoEnfermagemColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível pesquisar. Detalhes " + ex.Message);
            }
        }
        public PrescricaoEnfermagemColecao ConsultarPrescricoesEnfermagemRealizadas(string idpaciente)
        {
            try
            {
                PrescricaoEnfermagemColecao prescricaoEnfermagemColecao = new PrescricaoEnfermagemColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdPaciente", idpaciente);
                DataTable datatablePrescricaoEnfermagem = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPrescricaoEnfermagemRealizadasPesquisar");

                foreach (DataRow linha in datatablePrescricaoEnfermagem.Rows)
                {
                    PrescricaoEnfermagem prescricaoEnfermagemClass = new PrescricaoEnfermagem();

                    prescricaoEnfermagemClass.IdPrescricaoEnfermagem = Convert.ToInt32(linha["IdPrescricaoEnfermagem"]);
                    prescricaoEnfermagemClass.IdPessoa = Convert.ToInt32(linha["IdPaciente"]);
                    prescricaoEnfermagemClass.Tipo = Convert.ToString(linha["Tipo"]);
                    prescricaoEnfermagemClass.Descricao = Convert.ToString(linha["Descricao"]);
                    prescricaoEnfermagemClass.Horario = Convert.ToDateTime(linha["Horario"]);
                    //prescricaoMedicaClass.TarefaRealizada = Convert.ToBoolean(linha["TarefaRealizada"]);
                    prescricaoEnfermagemClass.NomeEnfermeiro = Convert.ToString(linha["NomeEnfermeiro"]);
                    prescricaoEnfermagemClass.HoraRealizacaoTarefa = Convert.ToString(linha["HoraRealizacaoTarefa"]);
                    prescricaoEnfermagemClass.DataCadastro = Convert.ToDateTime(linha["DataCadastro"]);
                    prescricaoEnfermagemClass.DataModificacao = Convert.ToDateTime(linha["DataModificacao"]);

                    prescricaoEnfermagemColecao.Add(prescricaoEnfermagemClass);
                }
                return prescricaoEnfermagemColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível pesquisar. Detalhes " + ex.Message);
            }
        }
        public PrescricaoEnfermagemColecao ConsultarPrescricoesEnfermagemAFazer(string idpaciente)
        {
            try
            {
                PrescricaoEnfermagemColecao prescricaoEnfermagemColecao = new PrescricaoEnfermagemColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdPaciente", idpaciente);
                DataTable datatablePrescricaoEnfermagem = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPrescricaoEnfermagemAFazerPesquisar");

                foreach (DataRow linha in datatablePrescricaoEnfermagem.Rows)
                {
                    PrescricaoEnfermagem prescricaoEnfermagemClass = new PrescricaoEnfermagem();

                    prescricaoEnfermagemClass.IdPrescricaoEnfermagem = Convert.ToInt32(linha["IdPrescricaoEnfermagem"]);
                    prescricaoEnfermagemClass.IdPessoa = Convert.ToInt32(linha["IdPaciente"]);
                    prescricaoEnfermagemClass.Tipo = Convert.ToString(linha["Tipo"]);
                    prescricaoEnfermagemClass.Descricao = Convert.ToString(linha["Descricao"]);
                    prescricaoEnfermagemClass.Horario = Convert.ToDateTime(linha["Horario"]);
                    //prescricaoMedicaClass.TarefaRealizada = Convert.ToBoolean(linha["TarefaRealizada"]);
                    prescricaoEnfermagemClass.NomeEnfermeiro = Convert.ToString(linha["NomeEnfermeiro"]);
                    prescricaoEnfermagemClass.HoraRealizacaoTarefa = Convert.ToString(linha["HoraRealizacaoTarefa"]);
                    prescricaoEnfermagemClass.DataCadastro = Convert.ToDateTime(linha["DataCadastro"]);
                    prescricaoEnfermagemClass.DataModificacao = Convert.ToDateTime(linha["DataModificacao"]);

                    prescricaoEnfermagemColecao.Add(prescricaoEnfermagemClass);
                }
                return prescricaoEnfermagemColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível pesquisar. Detalhes " + ex.Message);
            }
        }
        public string MarcarTarefaRealizada(PrescricaoEnfermagem prescricaoEnfermagemClass)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdPrescricaoEnfermagem", prescricaoEnfermagemClass.IdPrescricaoEnfermagem);
                acessoDadosSqlServer.AdicionarParametros("@TarefaRealizada", prescricaoEnfermagemClass.TarefaRealizada);
                acessoDadosSqlServer.AdicionarParametros("@NomeEnfermeiro", prescricaoEnfermagemClass.NomeEnfermeiro);
                acessoDadosSqlServer.AdicionarParametros("@HoraRealizacaoTarefa", prescricaoEnfermagemClass.HoraRealizacaoTarefa);

                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPrescricaoEnfermagemMarcarTarefaRealizada").ToString();

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
     
    }
}
