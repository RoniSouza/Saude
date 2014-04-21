using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Negocios;
using AcessoBancoDados;
using ObjetoTransferencia;
using System.Data;

namespace WebService
{
    /// <summary>
    /// Descrição resumida de Service
    /// </summary>
    [WebService(Namespace = "http://maissaude/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {

        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();
       
        [WebMethod]
        public PrescricaoMedicaColecao PesquisarPrescricoesAFazer(string idpaciente)
        {
            try
            {
                PrescricaoMedicaColecao prescricaoMedicaColecao = new PrescricaoMedicaColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdPaciente", idpaciente);
                DataTable datatablePrescricaoMedica = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPrescricaoMedicaAFazerPesquisar");

                foreach (DataRow linha in datatablePrescricaoMedica.Rows)
                {
                    PrescricaoMedica prescricaoMedicaClass = new PrescricaoMedica();

                    prescricaoMedicaClass.IdPrescricaoMedica = Convert.ToInt32(linha["IdPrescricaoMedica"]);
                    prescricaoMedicaClass.IdPessoa = Convert.ToInt32(linha["IdPaciente"]);
                    prescricaoMedicaClass.Tipo = Convert.ToString(linha["Tipo"]);
                    prescricaoMedicaClass.Descricao = Convert.ToString(linha["Descricao"]);
                    prescricaoMedicaClass.Horario = Convert.ToDateTime(linha["Horario"]);
                    prescricaoMedicaClass.TarefaRealizada = Convert.ToBoolean(linha["TarefaRealizada"]);
                    prescricaoMedicaClass.DataCadastro = Convert.ToDateTime(linha["DataCadastro"]);
                    prescricaoMedicaClass.NomeEnfermeiro = Convert.ToString(linha["NomeEnfermeiro"]);
                    prescricaoMedicaClass.DataModificacao = Convert.ToDateTime(linha["DataModificacao"]);

                    prescricaoMedicaColecao.Add(prescricaoMedicaClass);
                }
                return prescricaoMedicaColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível pesquisar. Detalhes " + ex.Message);
            }
        }
        [WebMethod]
        public PrescricaoMedicaColecao PesquisarPrescricoesRealizadas(string idpaciente)
        {
            try
            {
                PrescricaoMedicaColecao prescricaoMedicaColecao = new PrescricaoMedicaColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdPaciente", idpaciente);
                DataTable datatablePrescricaoMedica = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPrescricaoMedicaRealizadasPesquisar");

                foreach (DataRow linha in datatablePrescricaoMedica.Rows)
                {
                    PrescricaoMedica prescricaoMedicaClass = new PrescricaoMedica();

                    prescricaoMedicaClass.IdPrescricaoMedica = Convert.ToInt32(linha["IdPrescricaoMedica"]);
                    prescricaoMedicaClass.IdPessoa = Convert.ToInt32(linha["IdPaciente"]);
                    prescricaoMedicaClass.Tipo = Convert.ToString(linha["Tipo"]);
                    prescricaoMedicaClass.Descricao = Convert.ToString(linha["Descricao"]);
                    prescricaoMedicaClass.Horario = Convert.ToDateTime(linha["Horario"]);
                    prescricaoMedicaClass.TarefaRealizada = Convert.ToBoolean(linha["TarefaRealizada"]);
                    prescricaoMedicaClass.DataCadastro = Convert.ToDateTime(linha["DataCadastro"]);
                    prescricaoMedicaClass.NomeEnfermeiro = Convert.ToString(linha["NomeEnfermeiro"]);
                    prescricaoMedicaClass.DataModificacao = Convert.ToDateTime(linha["DataModificacao"]);

                    prescricaoMedicaColecao.Add(prescricaoMedicaClass);
                }
                return prescricaoMedicaColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível pesquisar. Detalhes " + ex.Message);
            }
        }
    }
}
