using Negocios;
using ObjetoTransferencia;
using System;

namespace Web.Prontuarios
{
    public partial class Index : System.Web.UI.Page
    {
        private string idpaciente;
        protected void Page_Load(object sender, EventArgs e)
        {
            idpaciente = Request.QueryString["id"];
            AtualizarGridPaciente();
        }
        private void AtualizarGridPaciente()
        {
            PacienteNegocio pacienteNegocios = new PacienteNegocio();
            PacienteColecao pacienteColecao = new PacienteColecao();
            pacienteColecao = pacienteNegocios.ConsultaPorId(Convert.ToInt32(idpaciente));
            GridViewPacientes.DataSource = pacienteColecao;
            GridViewPacientes.DataBind();
        }
        protected void VisualizarEvolucaoEnfermagem(object sender, EventArgs e)
        {
            Response.Redirect("~/Prontuarios/VisualizarEvolucaoEnfermagem.aspx?id=" + idpaciente);
        }
        protected void VisualizarEvolucaoMedica(object sender, EventArgs e)
        {
            Response.Redirect("~/Prontuarios/VisualizarEvolucaoMedica.aspx?id=" + idpaciente);
        }
        protected void VisualizarPrescricaoMedica(object sender, EventArgs e)
        {
            Response.Redirect("~/Prontuarios/VisualizarPrescricaoMedica.aspx?id=" + idpaciente);
        }
        protected void VisualizarPrescricaoEnfermagem(object sender, EventArgs e)
        {
            Response.Redirect("~/Prontuarios/VisualizarPrescricaoEnfermagem.aspx?id=" + idpaciente);
        }
        protected void InserirEvolucaoEnfermagem(object sender, EventArgs e)
        {
            Response.Redirect("~/Prontuarios/InserirEvolucaoEnfermagem.aspx?id=" + idpaciente);
        }
        protected void InserirEvolucaoMedica(object sender, EventArgs e)
        {
            Response.Redirect("~/Prontuarios/InserirEvolucaoMedica.aspx?id=" + idpaciente);
        }
        protected void InserirPrescricaoMedica(object sender, EventArgs e)
        {
            Response.Redirect("~/Prontuarios/InserirPrescricaoMedica.aspx?id=" + idpaciente);
        }
        protected void InserirPrescricaoEnfermagem(object sender, EventArgs e)
        {
            Response.Redirect("~/Prontuarios/InserirPrescricaoEnfermagem.aspx?id=" + idpaciente);
        }
        protected void Voltar(object sender, EventArgs e)
        {
            Response.Redirect("~/Pacientes/Visualizar.aspx?id=" + idpaciente);
        }
    }
}