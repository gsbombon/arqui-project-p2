using Microsoft.Azure.Management.AppService.Fluent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prj_architecture_p2.View
{
    public partial class frm_main : System.Web.UI.Page
    {
        String hostName = string.Empty;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            hostName = Dns.GetHostName();
            txt_server.Text = "Hostname: " + hostName;
        }
    }
}