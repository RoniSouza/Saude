using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Negocios
{
    public class EvolucaoEnfermagemNegocio
    {
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();
        public string Inserir(EvolucaoEnfermagemClass evolucaoEnfermagemClass)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdPaciente", evolucaoEnfermagemClass.IdPessoa);
                acessoDadosSqlServer.AdicionarParametros("@FrequenciaCardiaca", evolucaoEnfermagemClass.FrequenciaCardiaca);
                acessoDadosSqlServer.AdicionarParametros("@PressaoArterial", evolucaoEnfermagemClass.PressaoArterial);
                acessoDadosSqlServer.AdicionarParametros("@Respiracao", evolucaoEnfermagemClass.Respiracao);
                acessoDadosSqlServer.AdicionarParametros("@Temperatura", evolucaoEnfermagemClass.Temperatura);
                acessoDadosSqlServer.AdicionarParametros("@Observacoes", evolucaoEnfermagemClass.Observacoes);
                acessoDadosSqlServer.AdicionarParametros("@Usuario", evolucaoEnfermagemClass.CadastradoPor);

                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspEvolucaoEnfermagemInserir").ToString();

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public EvolucaoEnfermagemColecao ConsultaPorId(string idpaciente)
        {
            try
            {
                EvolucaoEnfermagemColecao evolucaoEnfermagemColecao = new EvolucaoEnfermagemColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdPaciente", idpaciente);
                DataTable datatablePrescricaoMedica = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspEvolucaoEnfermagemPesquisar");

                foreach (DataRow linha in datatablePrescricaoMedica.Rows)
                {
                    EvolucaoEnfermagemClass evolucaoEnfermagemClass = new EvolucaoEnfermagemClass();

                    evolucaoEnfermagemClass.IdPessoa = Convert.ToInt32(linha["IdPaciente"]);
                    evolucaoEnfermagemClass.FrequenciaCardiaca = Convert.ToString(linha["FrequenciaCardiaca"]);
                    evolucaoEnfermagemClass.PressaoArterial = Convert.ToString(linha["PressaoArterial"]);
                    evolucaoEnfermagemClass.Respiracao = Convert.ToString(linha["Respiracao"]);
                    evolucaoEnfermagemClass.Temperatura = Convert.ToString(linha["Temperatura"]);
                    evolucaoEnfermagemClass.Observacoes = Convert.ToString(linha["Observacoes"]);
                    evolucaoEnfermagemClass.DataCadastro = Convert.ToDateTime(linha["DataCadastro"]);
                    evolucaoEnfermagemClass.CadastradoPor = Convert.ToString(linha["Usuario"]);
                    evolucaoEnfermagemClass.DataModificacao = Convert.ToDateTime(linha["DataModificacao"]);

                    evolucaoEnfermagemColecao.Add(evolucaoEnfermagemClass);
                }
                return evolucaoEnfermagemColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível pesquisar. Detalhes " + ex.Message);
            }
        }
    }

}
