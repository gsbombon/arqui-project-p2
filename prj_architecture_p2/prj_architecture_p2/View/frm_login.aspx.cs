using prj_architecture_p2.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prj_architecture_p2.View
{
    public partial class frm_login : System.Web.UI.Page
    {
        DAOLogin cliente = new DAOLogin(); 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_loginClick(object sender, EventArgs e)
        {
            try
            {
                if (cliente.loginIn(txt_user.Text, txt_pass.Text) == 1)
                {
                    Response.Redirect("frm_main.aspx");
                }
                else
                {
                    txt_mensaje.Text = "Usuario o contraseña incorrectos !";
                }
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Error: " + ex.Message;
            }
        }
    }
}