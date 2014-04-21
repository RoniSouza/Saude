using Negocios;
using ObjetoTransferencia;
using System;
using System.Web;

namespace Web.Profissionais
{
    public partial class Adicionar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Inserir(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Profissional profissional = new Profissional();

                profissional.Nome = TextBoxNome.Text;
                profissional.Endereco = TextBoxEndereco.Text;
                profissional.Numero = TextBoxNumero.Text;
                profissional.Bairro = TextBoxBairro.Text;
                profissional.Cidade = TextBoxCidade.Text;
                profissional.Estado = DropDownListEstado.Text;
                profissional.CEP = TextBoxCEP.Text;
                profissional.Cargo = TextBoxCargo.Text;
                profissional.RG = TextBoxRG.Text;
                profissional.OrgaoEmissor = DropDownListOrgaoEmissor.Text;
                profissional.UF = DropDownListUF.Text;
                profissional.Naturalidade = TextBoxNaturalidade.Text;
                profissional.Nacionalidade = TextBoxNacionalidade.Text;
                profissional.ConselhoClasse = DropDownListConselhoClasse.Text;
                profissional.NumeroRegistro = TextBoxNumeroRegistro.Text;
                profissional.UFRegistro = DropDownListUFRegistro.Text;
                profissional.CPF = TextBoxCPF.Text;
                profissional.TelefoneFixo = TextBoxTelFixo.Text;
                profissional.TelefoneCelular = TextBoxTelCel.Text;
                profissional.DataNascimento = Convert.ToDateTime(TextBoxDataNasc.Text);
                profissional.Email = TextBoxEmail.Text;
                profissional.DataAdmissao = Convert.ToDateTime(TextBoxDataAdmissao.Text);
                profissional.CadastradoPor = HttpContext.Current.User.Identity.Name;

                try
                {
                    ProfissionalNegocio profissionalNegocio = new ProfissionalNegocio();
                    profissionalNegocio.Inserir(profissional);
                    string message = "Profissional Cadastrado com sucesso!";
                    Response.Write("<script>alert('" + message + "')</script>");
                }
                catch (Exception ex)
                {
                    ErrorMessage.Text = ex.Message;
                    ErrorMessage.Visible = true;
                }
            }
        }
    }
}