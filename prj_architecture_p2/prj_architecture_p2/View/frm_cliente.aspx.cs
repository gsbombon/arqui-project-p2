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
    public partial class Cliente : System.Web.UI.Page
    {
        DAOFacturation cliente = new DAOFacturation();
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
            txt_ruc.Text = string.Empty;
        }
        protected void btn_addClick(object sender, EventArgs e)
        {
            try
            {
                txt_mensaje.Text = cliente.insertClient(txt_ruc.Text, txt_name.Text, txt_address.Text);
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
                txt_mensaje.Text = cliente.updateClient(Convert.ToInt32(txt_id.Text), txt_ruc.Text, txt_name.Text, txt_address.Text);
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
                txt_mensaje.Text = cliente.deleteClient(Convert.ToInt32(txt_id.Text));
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
                grdClientes.DataSource = cliente.findClient(txt_ruc.Text);
                grdClientes.DataBind();
                DataTable dt = cliente.findClient(txt_ruc.Text);
                txt_id.Text = dt.Rows[0]["ID_CLIENTE"].ToString();
                txt_name.Text = dt.Rows[0]["NOMBRE_CLIENTE"].ToString();
                txt_address.Text = dt.Rows[0]["DIRECCION_CLIENTE"].ToString();
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
                grdClientes.DataSource = cliente.getListClients();
                grdClientes.DataBind();
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Error: " + ex.Message;
            }

        }
    }
}