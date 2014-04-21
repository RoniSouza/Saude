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

namespace Web.Profissionais
{
    public partial class Visualizar : System.Web.UI.Page
    {

        ProfissionalNegocio profissionalNegocio = new ProfissionalNegocio();
        ProfissionalColecao profissionalColecao = new ProfissionalColecao();
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();
        Profissional profissional = new Profissional();
        private string idprofissional;
        private string retorno;
        private DateTime data;

        protected void Page_Load(object sender, EventArgs e)
        {
            idprofissional = Request.QueryString["id"];

            if (!Page.IsPostBack)
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdProfissional", idprofissional);
                DataTable datatableProfissional = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspProfissionalPesquisarPorId");

                foreach (DataRow linha in datatableProfissional.Rows)
                {
                    TextBoxCodigo.Text = Convert.ToString(linha["IdProfissional"]);
                    TextBoxNome.Text = Convert.ToString(linha["Nome"]);
                    TextBoxEndereco.Text = Convert.ToString(linha["Endereco"]);
                    TextBoxNumero.Text = Convert.ToString(linha["Numero"]);
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
                    DropDownListConselhoClasse.Text = Convert.ToString(linha["ConselhoClasse"]);
                    TextBoxNumeroRegistro.Text = Convert.ToString(linha["NumeroRegistro"]);
                    DropDownListUFRegistro.Text = Convert.ToString(linha["UFRegistro"]);
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
            profissional.IdPessoa = Convert.ToInt32(TextBoxCodigo.Text);
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
                retorno = profissionalNegocio.Alterar(profissional);
                string message = "Profissional Alterado com sucesso!";
                Response.Write("<script>alert('" + message + "')</script>");
            }
            catch (Exception)
            {
                ErrorMessage.Text = retorno.ToString();
                ErrorMessage.Visible = true;
            }
        }

        protected void Excluir(object sender, EventArgs e)
        {
            profissionalNegocio.Excluir(profissional);
            string message = "Registro excluído com sucesso!";
            Response.Write("<script>alert('" + message + "')</script>");


        }
        protected void Voltar(object sender, EventArgs e)
        {
            Response.Redirect("~/Profissionais/Index.aspx");
        }

    }
}