using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Negocios
{
    public class EvolucaoMedicaNegocio
    {
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();
        public string Inserir(EvolucaoMedicaClass evolucaoMedicaClass)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdPaciente", evolucaoMedicaClass.IdPessoa);
                acessoDadosSqlServer.AdicionarParametros("@EvolucaoMedica", evolucaoMedicaClass.EvolucaoMedica);
                acessoDadosSqlServer.AdicionarParametros("@Observacoes", evolucaoMedicaClass.Observacoes);
                acessoDadosSqlServer.AdicionarParametros("@Usuario", evolucaoMedicaClass.CadastradoPor);

                return acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspEvolucaoMedicaInserir").ToString();

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public EvolucaoMedicaColecao ConsultaPorId(string idpaciente)
        {
            try
            {
                EvolucaoMedicaColecao evolucaoMedicaColecao = new EvolucaoMedicaColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdPaciente", idpaciente);
                DataTable datatableEvolucaoMedica = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspEvolucaoMedicaPesquisar");

                foreach (DataRow linha in datatableEvolucaoMedica.Rows)
                {
                    EvolucaoMedicaClass evolucaoMedicaClass = new EvolucaoMedicaClass();

                    evolucaoMedicaClass.IdPessoa = Convert.ToInt32(linha["IdPaciente"]);
                    evolucaoMedicaClass.EvolucaoMedica = Convert.ToString(linha["EvolucaoMedica"]);
                    evolucaoMedicaClass.Observacoes = Convert.ToString(linha["Observacoes"]);
                    evolucaoMedicaClass.DataCadastro = Convert.ToDateTime(linha["DataCadastro"]);
                    evolucaoMedicaClass.CadastradoPor = Convert.ToString(linha["Usuario"]);
                    evolucaoMedicaClass.DataModificacao = Convert.ToDateTime(linha["DataModificacao"]);

                    evolucaoMedicaColecao.Add(evolucaoMedicaClass);
                }
                return evolucaoMedicaColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível pesquisar. Detalhes " + ex.Message);
            }
        }
    }
}
