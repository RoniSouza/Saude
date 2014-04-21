using AcessoBancoDados.Properties;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AcessoBancoDados
{
    public class AcessoDadosSqlServer
    {
        //cria conexao
        private SqlConnection CriarConexao()
        {
            return new SqlConnection(Settings.Default.stringConexao);
        }

        //parametros que irao ao banco
        private SqlParameterCollection sqlParameterCollection = new SqlCommand().Parameters;

        public void LimparParametros()
        {
            sqlParameterCollection.Clear();
        }

        public void AdicionarParametros(string nomeParametro, object valorParametro)
        {
            sqlParameterCollection.Add(new SqlParameter(nomeParametro, valorParametro));
        }


        //Persistencia - Inserir, Alterar , Excluir
        //commandtype enumerador (mes=janeiro, fevereiro...) 
        public object ExecutarManipulacao(CommandType commandType, string nomeStoredProducedureOuTextoSql)
        {
            try
            {
                //cria conexao
                SqlConnection sqlConnection = CriarConexao();
                //abre conexao
                sqlConnection.Open();
                //comando que leva as informacoes para o banco
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                //colocar as coisas dentro do comando
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredProducedureOuTextoSql;
                sqlCommand.CommandTimeout = 7200; //em segundo default 30s

                //adicionar parametros no comando
                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {   //se tiver uma linha nao precisa de chave
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }
                return sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Consultas no banco
        public DataTable ExecutarConsulta(CommandType commandType, string nomeStoredProducedureOuTextoSql)
        {
            try
            {
                //cria conexao
                SqlConnection sqlConnection = CriarConexao();
                //abre conexao
                sqlConnection.Open();
                //comando que leva as informacoes para o banco
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                //colocar as coisas dentro do comando
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredProducedureOuTextoSql;
                sqlCommand.CommandTimeout = 7200; //em segundo default 30s

                //adicionar parametros no comando
                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {   //se tiver uma linha nao precisa de chave
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }

                //adpta os dados do SqlServer para o c#
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                //DataTabel cria tabela vazia que se coloca dados do sqlserver
                DataTable dataTable = new DataTable();

                //comando  que vai ao banco e preenche o datatable
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
