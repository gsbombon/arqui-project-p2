using MySqlX.XDevAPI;
using prj_architecture_p2.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prj_architecture_p2.View
{
    public partial class ReporteFacturacion : System.Web.UI.Page
    {
        DAOFacturation cliente = new DAOFacturation();
        protected void Page_Load(object sender, EventArgs e)
        {
            String hostName = string.Empty;
            hostName = Dns.GetHostName();
            txt_server.Text = "Hostname: " + hostName;
            if (!IsPostBack)
            {
                loadTableReport();
            }
        }

        private void loadTableReport()
        {
            try
            {
                grdReporte.DataSource = cliente.getReportOne();
                grdReporte.DataBind();
            }
            catch (Exception ex) 
            { 
                txt_mensaje.Text = "Excepción: " + ex.Message; 
            }

        }
    }
}