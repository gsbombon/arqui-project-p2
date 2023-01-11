using prj_architecture_p2.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prj_architecture_p2.View
{
    public partial class frm_register : System.Web.UI.Page
    {
        DAOLogin cliente = new DAOLogin();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_registerClick(object sender, EventArgs e)
        {
            try
            {
                txt_mensaje.Text = cliente.singUp(txt_user.Text, txt_pass.Text);
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Error: " + ex.Message;
            }
        }
    }
}