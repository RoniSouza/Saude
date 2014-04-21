using AcessoBancoDados;
using MessagingToolkit.QRCode.Codec;
using Negocios;
using ObjetoTransferencia;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace Web.Pacientes
{
    public partial class Visualizar : System.Web.UI.Page
    {
        
        PacienteNegocio pacienteNegocio = new PacienteNegocio();
        PacienteColecao pacienteColecao = new PacienteColecao();
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();
        Paciente paciente = new Paciente();
        private string idpaciente;
        private byte[] qrcode;
        private DateTime data;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            idpaciente = Request.QueryString["id"];

            if (!Page.IsPostBack)
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdPaciente", idpaciente);
                DataTable datatablePaciente = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPacientePesquisarPorId");

                foreach (DataRow linha in datatablePaciente.Rows)
                {
                    TextBoxCodigo.Text = Convert.ToString(linha["IdPaciente"]);
                    TextBoxNome.Text = Convert.ToString(linha["Nome"]);
                    TextBoxEndereco.Text = Convert.ToString(linha["Endereco"]);
                    TextBoxNumero.Text = Convert.ToString(linha["Numero"]);
                    TextBoxBairro.Text = Convert.ToString(linha["Bairro"]);
                    TextBoxCidade.Text = Convert.ToString(linha["Cidade"]);
                    DropDownListEstado.Text = Convert.ToString(linha["Estado"]);
                    TextBoxCEP.Text = Convert.ToString(linha["CEP"]);
                    TextBoxRG.Text = Convert.ToString(linha["RG"]);
                    DropDownListOrgaoEmissor.Text = Convert.ToString(linha["OrgaoEmissor"]);
                    DropDownListUF.Text = Convert.ToString(linha["UF"]);
                    TextBoxNaturalidade.Text = Convert.ToString(linha["Naturalidade"]);
                    TextBoxNacionalidade.Text = Convert.ToString(linha["Nacionalidade"]);
                    TextBoxCorRaca.Text = Convert.ToString(linha["CorRaca"]);
                    DropDownListSexo.Text = Convert.ToString(linha["Sexo"]);
                    TextBoxCPF.Text = Convert.ToString(linha["CPF"]);
                    TextBoxTelFixo.Text = Convert.ToString(linha["TelefoneFixo"]);
                    TextBoxTelCel.Text = Convert.ToString(linha["TelefoneCelular"]);
                    data = Convert.ToDateTime(linha["DataNascimento"]);
                    TextBoxDataNasc.Text = data.ToString("dd/MM/yyyy");
                    TextBoxEmail.Text = Convert.ToString(linha["Email"]);
                    TextBoxResponsavel.Text = Convert.ToString(linha["Responsavel"]);
                    TextBoxPai.Text = Convert.ToString(linha["Pai"]);
                    TextBoxMae.Text = Convert.ToString(linha["Mae"]);
                    data = Convert.ToDateTime(linha["DataCadastro"]);
                    TextBoxDataCadastro.Text = data.ToString("dd/MM/yyyy HH:mm");
                    TextBoxCadastradoPor.Text = Convert.ToString(linha["Usuario"]);
                    data = Convert.ToDateTime(linha["DataModificacao"]);
                    TextBoxDataModificacao.Text = data.ToString("dd/MM/yyyy HH:mm");
                    TextBoxConvenio.Text = Convert.ToString(linha["Convenio"]);
                    TextBoxNumeroInscricao.Text = Convert.ToString(linha["NumeroInscricao"]);
                    data = Convert.ToDateTime(linha["ValidadeCartao"]);
                    TextBoxValidadeCartao.Text = data.ToString("dd/MM/yyyy");
                    TextBoxTipoPlano.Text = Convert.ToString(linha["TipoPlano"]);
                    DropDownListLeito.Text = Convert.ToString(linha["Leito"]);
                }
            }
        }
        protected void Alterar(object sender, EventArgs e)
        {
            paciente.IdPessoa = Convert.ToInt32(idpaciente);
            paciente.Nome = TextBoxNome.Text;
            paciente.Endereco = TextBoxEndereco.Text;
            paciente.Numero = TextBoxNumero.Text;
            paciente.Bairro = TextBoxBairro.Text;
            paciente.Cidade = TextBoxCidade.Text;
            paciente.Estado = DropDownListEstado.Text;
            paciente.CEP = TextBoxCEP.Text;
            paciente.RG = TextBoxRG.Text;
            paciente.OrgaoEmissor = DropDownListOrgaoEmissor.Text;
            paciente.UF = DropDownListUF.Text;
            paciente.Naturalidade = TextBoxNaturalidade.Text;
            paciente.Nacionalidade = TextBoxNacionalidade.Text;
            paciente.CorRaca = TextBoxCorRaca.Text;
            paciente.Sexo = DropDownListSexo.Text;
            paciente.CPF = TextBoxCPF.Text;
            paciente.TelefoneFixo = TextBoxTelFixo.Text;
            paciente.TelefoneCelular = TextBoxTelCel.Text;
            paciente.DataNascimento = Convert.ToDateTime(TextBoxDataNasc.Text);
            paciente.Email = TextBoxEmail.Text;
            paciente.Responsavel = TextBoxResponsavel.Text;
            paciente.Pai = TextBoxPai.Text;
            paciente.Mae = TextBoxMae.Text;
            paciente.Convenio = TextBoxConvenio.Text;
            paciente.NumeroInscricao = TextBoxNumeroInscricao.Text;
            paciente.ValidadeCartao = Convert.ToString(TextBoxValidadeCartao.Text);
            paciente.TipoPlano = TextBoxTipoPlano.Text;
            paciente.Leito = DropDownListLeito.Text;
            paciente.QRCode = qrcode;
            paciente.CadastradoPor = HttpContext.Current.User.Identity.Name;

            try
            {
                pacienteNegocio.Alterar(paciente);
                string message = "Paciente Alterado com sucesso!";
                Response.Write("<script>alert('" + message + "')</script>");
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
                ErrorMessage.Visible = true;
            }                   
        }
        private void AlterarQRCode(byte[] qrcode)
        {
            paciente.IdPessoa = Convert.ToInt32(TextBoxCodigo.Text);
            paciente.QRCode = qrcode;
            
            try
            {
              pacienteNegocio.AlterarQRCode(paciente);
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
                pacienteNegocio.Excluir(paciente);
                string message = "Paciente Excluído com sucesso!";
                Response.Write("<script>alert('" + message + "')</script>");

            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
                ErrorMessage.Visible = true;
            }
        }
        protected void VerProntuario(object sender, EventArgs e)
        {
            Response.Redirect("~/Prontuarios/Index.aspx?id=" + idpaciente);
        }
        protected void ImprimirQRCode(object sender, EventArgs e)
        {
            string texto = TextBoxCodigo.Text;
            QRCodeEncoder encoder = new QRCodeEncoder();
            MemoryStream ms = new MemoryStream();
            Bitmap img = encoder.Encode(texto);
            img.Save(ms, ImageFormat.Bmp);
            qrcode = ms.ToArray();
    
            AlterarQRCode(qrcode);
            Response.Redirect("~/Pacientes/ImprimirQRCode.aspx?id=" + idpaciente);
        }
        protected void Voltar(object sender, EventArgs e)
        {
            Response.Redirect("~/Pacientes/Index.aspx");
        }
    }
}