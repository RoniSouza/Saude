using AcessoBancoDados;
using Negocios;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Web.Funcionarios
{
    public partial class Visualizar : System.Web.UI.Page
    {

        FuncionarioNegocio funcionarioNegocio = new FuncionarioNegocio();
        FuncionarioColecao funcionarioColecao = new FuncionarioColecao();
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();
        Funcionario funcionario = new Funcionario();
        private string idfuncionario;
        private DateTime data;

        protected void Page_Load(object sender, EventArgs e)
        {
            idfuncionario = Request.QueryString["id"];
            if (!Page.IsPostBack)
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdFuncionario", idfuncionario);
                DataTable datatableProfissional = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspFuncionarioPesquisarPorId");

                foreach (DataRow linha in datatableProfissional.Rows)
                {
                    TextBoxCodigo.Text = Convert.ToString(linha["IdFuncionario"]);
                    TextBoxNome.Text = Convert.ToString(linha["Nome"]);
                    TextBoxEndereco.Text = Convert.ToString(linha["Endereco"]);
                    TextBoxBairro.Text = Convert.ToString(linha["Bairro"]);
                    TextBoxCidade.Text = Convert.ToString(linha["Cidade"]);
                    DropDownListEstado.Text = Convert.ToString(linha["Estado"]);
                    TextBoxCEP.Text = Convert.ToString(linha["CEP"]);
                    TextBoxCargo.Text = Convert.ToString(linha["Cargo"]);
                    TextBoxRG.Text = Convert.ToString(linha["RG"]);
                    DropDownListOrgaoEmissor.Text = Convert.ToString(linha["OrgaoEmissor"]);
                    DropDownListUF.Text = Convert.ToString(linha["UF"]);
                    TextBoxNaturalidade.Text = Convert.ToString(linha["Naturalidade"]);
                    TextBoxNacionalidade.Text = Convert.ToString(linha["Nacionalidade"]);
                    TextBoxCPF.Text = Convert.ToString(linha["CPF"]);
                    TextBoxTelFixo.Text = Convert.ToString(linha["TelefoneFixo"]);
                    TextBoxTelCel.Text = Convert.ToString(linha["TelefoneCelular"]);
                    data = Convert.ToDateTime(linha["DataNascimento"]);
                    TextBoxDataNasc.Text = data.ToString("dd/MM/yyyy");
                    TextBoxEmail.Text = Convert.ToString(linha["Email"]);
                    data = Convert.ToDateTime(linha["DataAdmissao"]);
                    TextBoxDataAdmissao.Text = data.ToString("dd/MM/yyyy");
                    data = Convert.ToDateTime(linha["DataCadastro"]);
                    TextBoxDataCadastro.Text = data.ToString("dd/MM/yyyy HH:mm");
                    TextBoxCadastradoPor.Text = Convert.ToString(linha["Usuario"]);
                    data = Convert.ToDateTime(linha["DataModificacao"]);
                    TextBoxDataModificacao.Text = data.ToString("dd/MM/yyyy HH:mm");

                }
            }
        }
        protected void Alterar(object sender, EventArgs e)
        {
            funcionario.IdPessoa = Convert.ToInt32(TextBoxCodigo.Text);
            funcionario.Nome = TextBoxNome.Text;
            funcionario.Endereco = TextBoxEndereco.Text;
            funcionario.Numero = TextBoxNumero.Text;
            funcionario.Bairro = TextBoxBairro.Text;
            funcionario.Cidade = TextBoxCidade.Text;
            funcionario.Estado = DropDownListEstado.Text;
            funcionario.CEP = TextBoxCEP.Text;
            funcionario.Cargo = TextBoxCargo.Text;
            funcionario.RG = TextBoxRG.Text;
            funcionario.OrgaoEmissor = DropDownListOrgaoEmissor.Text;
            funcionario.UF = DropDownListUF.Text;
            funcionario.Naturalidade = TextBoxNaturalidade.Text;
            funcionario.Nacionalidade = TextBoxNacionalidade.Text;
            funcionario.CPF = TextBoxCPF.Text;
            funcionario.TelefoneFixo = TextBoxTelFixo.Text;
            funcionario.TelefoneCelular = TextBoxTelCel.Text;
            funcionario.DataNascimento = Convert.ToDateTime(TextBoxDataNasc.Text);
            funcionario.Email = TextBoxEmail.Text;
            funcionario.DataAdmissao = Convert.ToDateTime(TextBoxDataAdmissao.Text);
            funcionario.CadastradoPor = HttpContext.Current.User.Identity.Name;

            try
            {
                funcionarioNegocio.Alterar(funcionario);
                string message = "Funcionário Alterado com sucesso!";
                Response.Write("<script>alert('" + message + "')</script>");

            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
                ErrorMessage.Visible = true;
            }
        }

        protected void Excluir(object sender, EventArgs e)
        {
            try
            {
                funcionarioNegocio.Excluir(funcionario);
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
                ErrorMessage.Visible = true;
            }
        }
        protected void Voltar(object sender, EventArgs e)
        {
            Response.Redirect("~/Funcionarios/Index.aspx");
        }
    }
}