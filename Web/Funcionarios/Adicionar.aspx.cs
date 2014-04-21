using Negocios;
using ObjetoTransferencia;
using System;
using System.Web;

namespace Web.Funcionarios
{
    public partial class Adicionar : System.Web.UI.Page
    {
        private string retorno;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Inserir(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Funcionario funcionario = new Funcionario();

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
                    FuncionarioNegocio funcionarioNegocio = new FuncionarioNegocio();
                    funcionarioNegocio.Inserir(funcionario);
                    if (retorno == "Já existe um funcionario cadastrado com esse CPF")
                    {
                        ErrorMessage.Text = retorno.ToString();
                    }
                    else
                    {
                        string message = "Funcionário Cadastrado com sucesso!";
                        Response.Write("<script>alert('" + message + "')</script>");
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage.Text = ex.Message;
                    ErrorMessage.Visible = true;
                }
                 }
       }
        protected void Voltar(object sender, EventArgs e)
        {
            Response.Redirect("~/Funcionarios/Index.aspx");
        }
    }
}