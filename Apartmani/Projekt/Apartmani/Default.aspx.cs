using Apartmani.Model;
using Lib.Cryptography;
using Lib.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apartmani
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PanelLoginFailed.Visible = false;
            }

            if (Session["user"] != null)
            {
                Response.Redirect("Dashboard.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var username = txtUsername.Text;
                var password = SHA512.HashPassword(txtPassword.Text);

                var user = ((IRepository)Application["database"]).AuthUser(username, password);
                UserLogin(user);
            }
        }

        private void UserLogin(User user)
        {
            if (user == null)
            {
                PanelLoginFailed.Visible = true;
            }
            else
            {
                Session["user"] = user;

                if (user.UserName == "admin" && user.PasswordHash == "c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec")
                {
                    Response.Redirect("Admin.aspx");
                }
                else
                {
                    Response.Redirect("Dashboard.aspx");
                    PanelLoginFailed.Visible = false;
                }
            }
        }
    }
}