using AcessoBancoDados;
using Negocios;
using ObjetoTransferencia;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Web.Pacientes
{
    public partial class ImprimirQRCode1 : System.Web.UI.Page
    {
        PacienteNegocio pacienteNegocios = new PacienteNegocio();
        PacienteColecao pacienteColecao = new PacienteColecao();
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            acessoDadosSqlServer.LimparParametros();
            acessoDadosSqlServer.AdicionarParametros("@IdPaciente", id);
            DataTable datatablePaciente = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPacientePesquisarPorId");

            foreach (DataRow linha in datatablePaciente.Rows)
            {
                byte[] byteArray = (byte[])linha["QRCode"];
                MemoryStream memStream = new MemoryStream();
                memStream.Write(byteArray, 0, byteArray.Length);
                Bitmap bitmap = new Bitmap(memStream);
                bitmap.Save(Response.OutputStream, ImageFormat.Jpeg);
            }
           
        }
    }
}