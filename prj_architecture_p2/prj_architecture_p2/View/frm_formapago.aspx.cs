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
    public partial class frm_formapago : System.Web.UI.Page
    {
        DAOCxc fp = new DAOCxc();
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

        }

        private void loadDataToGrid()
        {
            try
            {
                grdFps.DataSource = fp.getListFp();
                grdFps.DataBind();
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Error: " + ex.Message;
            }

        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                txt_mensaje.Text = fp.insertFp(txt_id.Text, txt_name.Text);
                this.cleanForm();
                loadDataToGrid();
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
                txt_mensaje.Text = fp.updateFp(txt_id.Text, txt_name.Text);
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
                txt_mensaje.Text = fp.deleteFp(txt_id.Text);
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
                grdFps.DataSource = fp.findFp(txt_id.Text);
                grdFps.DataBind();
                DataTable dt = fp.findFp(txt_id.Text);
                txt_name.Text = dt.Rows[0]["NOMBRE_FORMAPAGO"].ToString();
                
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Error: " + ex.Message;
            }
        }
    }
}