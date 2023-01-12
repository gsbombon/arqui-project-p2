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
    public partial class Ciudad : System.Web.UI.Page
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
            txt_id.Text = "";
            txt_name.Text = "";
        }
        protected void btn_addClick(object sender, EventArgs e)
        {
            try
            {
                txt_mensaje.Text = cliente.insertCity(txt_name.Text);
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
                txt_mensaje.Text = cliente.updateCity(Convert.ToInt32(txt_id.Text), txt_name.Text);
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
                txt_mensaje.Text = cliente.deleteCity(Convert.ToInt32(txt_id.Text));
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
                grdCiudad.DataSource = cliente.findCity(Convert.ToInt32(txt_id.Text));
                grdCiudad.DataBind();
                DataTable dt = cliente.findCity(Convert.ToInt32(txt_id.Text));
                txt_id.Text = dt.Rows[0]["CODIGO_CIUDAD"].ToString();
                txt_name.Text = dt.Rows[0]["NOMBRE_CIUDAD"].ToString();
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
                grdCiudad.DataSource = cliente.getListCitys();
                grdCiudad.DataBind();
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Error: " + ex.Message;
            }

        }
    }
}