using System;

namespace Web.Pacientes
{
    public partial class ImprimirQRCode : System.Web.UI.Page
    {
        private string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];
            imagem.ImageUrl = "GetQRCode.aspx?id=" + id;
        }
    }
}