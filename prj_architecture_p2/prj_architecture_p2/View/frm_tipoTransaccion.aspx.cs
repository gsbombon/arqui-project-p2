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
    public partial class frm_tipoTransaccion : System.Web.UI.Page
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
            txt_name.Text = "";
            txt_sign.Text = "";
        }
        protected void btn_addClick(object sender, EventArgs e)
        {
            try
            {
                txt_mensaje.Text = cliente.insertTransactionType(txt_name.Text, txt_sign.Text);
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
                txt_mensaje.Text = cliente.updateTransactionType(Convert.ToInt32(txt_id.Text), txt_name.Text, txt_sign.Text);
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
                txt_mensaje.Text = cliente.deleteTransacionType(Convert.ToInt32(txt_id.Text));
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
                grdTT.DataSource = cliente.findTransactionType(Convert.ToInt32(txt_id.Text));
                grdTT.DataBind();
                DataTable dt = cliente.findTransactionType(Convert.ToInt32(txt_id.Text));
                txt_id.Text = dt.Rows[0]["ID_TT"].ToString();
                txt_name.Text = dt.Rows[0]["NOMBRE_TT"].ToString();
                txt_sign.Text = dt.Rows[0]["SIGNO_TT"].ToString();
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
                grdTT.DataSource = cliente.getListTransactionTypes();
                grdTT.DataBind();
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Error: " + ex.Message;
            }

        }
    }
}