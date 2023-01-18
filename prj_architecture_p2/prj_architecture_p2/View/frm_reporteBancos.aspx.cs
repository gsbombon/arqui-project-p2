using MySqlX.XDevAPI;
using prj_architecture_p2.DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prj_architecture_p2.View
{
    public partial class ReporteBancos : System.Web.UI.Page
    {
        ArrayList dates = new ArrayList();
        DAOBancos cliente = new DAOBancos();
        DataTable dtDates;
        protected void Page_Load(object sender, EventArgs e)
        {
            String hostName = string.Empty;
            hostName = Dns.GetHostName();
            txt_server.Text = "Hostname: " + hostName;
            if (!IsPostBack)
            {
                loadTableReport();
                loadCmbDates();
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

        private void loadCmbDates()
        {
            try
            {
                this.dtDates = cliente.filterDate();
                int nRows = this.dtDates.Rows.Count;
                for (int i = 0; i < nRows; i++)
                {
                    dates.Add(this.dtDates.Rows[i]["CUENTA_CB"].ToString());
                }
                cmb_date.DataSource = dates;
                cmb_date.DataBind();
                //txt_mensaje_ct.Text = "HOLA" + this.dtCuentas.Rows[0]["NOMBRE_CB"].ToString();
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Excepción cmb cuentas: " + ex.Message;
            }
        }

        protected void btn_findClick(object sender, EventArgs e)
        {
            try
            {
                grdReporte.DataSource = cliente.findDateReportOne(cmb_date.Text);
                grdReporte.DataBind();
                txt_mensaje.Text = "Elemento encontrado ! ";
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Error: " + ex.Message;
            }
        }

    }
}