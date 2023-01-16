using MySqlX.XDevAPI;
using prj_architecture_p2.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prj_architecture_p2.View
{
    public partial class frm_cobrador : System.Web.UI.Page
    {
        DAOCxc cobrador = new DAOCxc();
        protected void Page_Load(object sender, EventArgs e)
        {
            String hostName = string.Empty;
            hostName = Dns.GetHostName();
            txt_server.Text = "Hostname: " + hostName;
            if (!IsPostBack)
            {
                loadDataToGrid();
            }
        }
        public void cleanForm()
        {
            txt_id.Text = string.Empty;
            txt_name.Text = string.Empty;
            txt_address.Text = string.Empty;
            
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                txt_mensaje.Text = cobrador.insertCobrador(txt_id.Text, txt_name.Text, txt_address.Text);
                this.cleanForm();
                loadDataToGrid();
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Error: " + ex.Message;
            }
        }

        private void loadDataToGrid()
        {
            try
            {
                grdCobradores.DataSource = cobrador.getListCobrador();
                grdCobradores.DataBind();
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Error: " + ex.Message;
            }

        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                txt_mensaje.Text = cobrador.updateCobrador(txt_id.Text, txt_name.Text, txt_address.Text);
               
                this.cleanForm();
                loadDataToGrid();
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Error: " + ex.Message;
            }
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                txt_mensaje.Text = cobrador.deleteCobrador(txt_id.Text);
                this.cleanForm();
                loadDataToGrid();
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Error: " + ex.Message;
            }
        }

        protected void btn_find_Click(object sender, EventArgs e)
        {
            try
            {
                grdCobradores.DataSource = cobrador.findCobrador(txt_id.Text);
                grdCobradores.DataBind();
                DataTable dt = cobrador.findCobrador(txt_id.Text);
                txt_name.Text = dt.Rows[0]["NOMBRE_COBRADOR"].ToString();
                txt_address.Text = dt.Rows[0]["DIRECCION_COBRADOR"].ToString();
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Error: " + ex.Message;
            }
        }
    }
}