using AcessoBancoDados;
using MessagingToolkit.QRCode.Codec;
using Negocios;
using ObjetoTransferencia;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace Web.Pacientes
{
    public partial class Adicionar : System.Web.UI.Page
    {
        PacienteNegocio pacienteNegocio = new PacienteNegocio();
        PacienteColecao pacienteColecao = new PacienteColecao();
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();
        private string retorno;
        private int idpaciente;
        private byte[] qrcode;
        Paciente paciente = new Paciente();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void Inserir(object sender, EventArgs e)
        {
            if (IsValid)
            {
              

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
                paciente.Responsavel = TextBoxResp.Text;
                paciente.RGResponsavel = TextBoxRGResponsavel.Text;
                paciente.TelefoneResponsavel = TextBoxTelefoneResponsavel.Text;
                paciente.Pai = TextBoxPai.Text;
                paciente.Mae = TextBoxMae.Text;
                paciente.Convenio = TextBoxConvenio.Text;
                paciente.NumeroInscricao = TextBoxNumeroInscricao.Text;
                paciente.ValidadeCartao = Convert.ToString(TextBoxValidadeCartao.Text);
                paciente.TipoPlano = TextBoxTipoPlano.Text;
                paciente.Leito = DropDownListLeito.Text;
                paciente.CadastradoPor = HttpContext.Current.User.Identity.Name;

                try
                {
                    PacienteNegocio pacienteNegocios = new PacienteNegocio();
                    retorno = pacienteNegocios.Inserir(paciente);
                    idpaciente = Convert.ToInt32(retorno);
                    string message = "Paciente Cadastrado com sucesso!";
                    Response.Write("<script>alert('" + message + "')</script>");
                }
                catch (Exception)
                {
                    ErrorMessage.Text = retorno.ToString();
                    ErrorMessage.Visible = true;
                }
            }
        }
        private void GerarQRCode(byte[] qrcode)
        {
            paciente.IdPessoa = idpaciente;
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
        protected void ImprimirQRCode(object sender, EventArgs e)
        {
            string texto = Convert.ToString(idpaciente);
            QRCodeEncoder encoder = new QRCodeEncoder();
            MemoryStream ms = new MemoryStream();
            Bitmap img = encoder.Encode(texto);
            img.Save(ms, ImageFormat.Bmp);
            qrcode = ms.ToArray();

            GerarQRCode(qrcode);
            Response.Redirect("~/Pacientes/ImprimirQRCode.aspx?id=" + idpaciente);
        }
    }
}