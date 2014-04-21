using Negocios;
using ObjetoTransferencia;
using System;

namespace Web.Profissionais
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        private void AtualizarGrid()
        {
            ProfissionalNegocio profissionalNegocio = new ProfissionalNegocio();
            ProfissionalColecao profissionalColecao = new ProfissionalColecao();

            try
            {
                if (rbtNome.Checked == true)
                {
                    profissionalColecao = profissionalNegocio.ConsultaPorNome(TextBoxPesquisar.Text);
                }
                else
                {
                    profissionalColecao = profissionalNegocio.ConsultaPorId(Convert.ToInt32(TextBoxPesquisar.Text));
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
                ErrorMessage.Visible = true;
            }
            GridViewProfissionais.DataSource = profissionalColecao;
            GridViewProfissionais.DataBind();
        }
        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            AtualizarGrid();
        }
    }
}