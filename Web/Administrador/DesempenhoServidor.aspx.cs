using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Administrador
{
    public partial class DesempenhoServidor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PerformanceCounter objMemperf = new PerformanceCounter("Memory", "Available Bytes");
            PerformanceCounter objProcperf = new PerformanceCounter("System", "Processes");
            PerformanceCounter objComperf = new PerformanceCounter("System", "Threads");

            Label1.Text = string.Format("{0:#,###}", objMemperf.NextValue()) + "Byte";
            Label2.Text = objProcperf.NextValue().ToString();
            Label3.Text = objComperf.NextValue().ToString();

            if (!Page.IsPostBack)
            {
                foreach (PerformanceCounterCategory objPer in PerformanceCounterCategory.GetCategories())
                {
                    ListBox1.Items.Add(new ListItem(objPer.CategoryName));
                }
            }
        }
    }
}