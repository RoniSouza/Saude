using Negocios;
using ObjetoTransferencia;
using System;


namespace Web.Pacientes
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        private void AtualizarGrid()
        {
            PacienteNegocio pacienteNegocios = new PacienteNegocio();
            PacienteColecao pacienteColecao = new PacienteColecao();

            try
            {
                if (rbtNome.Checked == true)
                {
                    pacienteColecao = pacienteNegocios.ConsultaPorNome(TextBoxPesquisar.Text);
                }
                else
                {
                    pacienteColecao = pacienteNegocios.ConsultaPorId(Convert.ToInt32(TextBoxPesquisar.Text));
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
                ErrorMessage.Visible = true;
            }
            GridViewPacientes.DataSource = pacienteColecao;
            GridViewPacientes.DataBind();
        }
        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        protected void GridViewPacientes_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            GridViewPacientes.PageIndex = e.NewPageIndex;
            AtualizarGrid();
        }
    }
}
  
        
    
