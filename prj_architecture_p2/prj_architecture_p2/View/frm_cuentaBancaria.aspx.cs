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
    public partial class CuentaBancaria : System.Web.UI.Page
    {
        DAOBancos cliente = new DAOBancos();
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
            txt_id.Text = "";
            txt_cuenta.Text = "";
            txt_name.Text = "";
            txt_description.Text = "";
        }
        protected void btn_addClick(object sender, EventArgs e)
        {
            try
            {
                txt_mensaje.Text = cliente.insertBanckAccount(txt_cuenta.Text, txt_name.Text, txt_description.Text);
                this.cleanForm();
                loadDataToGrid();
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Error: " + ex.Message;
            }
        }

        protected void btn_updateClick(object sender, EventArgs e)
        {
            try
            {
                txt_mensaje.Text = cliente.updateBackAccount(Convert.ToInt32(txt_id.Text), txt_cuenta.Text, txt_name.Text, txt_description.Text);
                this.cleanForm();
                loadDataToGrid();
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Error: " + ex.Message;
            }
        }

        protected void btn_deleteClick(object sender, EventArgs e)
        {
            try
            {
                txt_mensaje.Text = cliente.deleteBanckAccount(Convert.ToInt32(txt_id.Text));
                this.cleanForm();
                loadDataToGrid();
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Error: " + ex.Message;
            }
        }

        protected void btn_findClick(object sender, EventArgs e)
        {
            try
            {
                grdCB.DataSource = cliente.findBanckAccount(Convert.ToInt32(txt_id.Text));
                grdCB.DataBind();
                DataTable dt = cliente.findBanckAccount(Convert.ToInt32(txt_id.Text));
                txt_id.Text = dt.Rows[0]["ID_CB"].ToString();
                txt_cuenta.Text = dt.Rows[0]["CUENTA_CB"].ToString();
                txt_name.Text = dt.Rows[0]["NOMBRE_CB"].ToString();
                txt_description.Text = dt.Rows[0]["DESCRIPTION_CB"].ToString();
                txt_mensaje.Text = "Elemento encontrado ! ";
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
                grdCB.DataSource = cliente.getListBanckAccounts();
                grdCB.DataBind();
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Error: " + ex.Message;
            }

        }
    }
}