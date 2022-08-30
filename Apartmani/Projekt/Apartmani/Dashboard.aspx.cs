using Apartmani.Model;
using Lib.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apartmani
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            User user = (User)Session["user"];
            pUsername.InnerText = user.UserName;
            pEmail.InnerText = user.Email;
            pPhoneNumber.InnerText = user.PhoneNumber;
            pAddress.InnerText = user.Address;
            base.OnPreRender(e);
        }
    }
}