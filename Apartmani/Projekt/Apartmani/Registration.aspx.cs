using Apartmani.Model;
using Lib.Cryptography;
using Lib.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apartmani
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PanelRegistration.Visible = true;
                PanelSuccess.Visible = false;
                PanelFailed.Visible = false; 
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                User user = new User
                {
                    UserName = txtUsername.Text,
                    Email = txtEmail.Text,
                    Address = txtAddress.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    PasswordHash = SHA512.HashPassword(txtPassword.Text),
                };

                IList<User> allUsers = ((IRepository)Application["database"]).LoadUsers();
                
                if (!allUsers.Contains(new User { UserName = txtUsername.Text}))
                {
                    ((IRepository)Application["database"]).AddUser(user);
                    RenderData(user);
                }
                else
                {
                    FailedRegistration(user);
                }
            }
        }

        private void FailedRegistration(User user)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div id='results' class='container p-4'><fieldset>");
            sb.Append($"<legend>{user.UserName}</legend>");
            sb.Append("<div class='mb-3'><label class='form-label'>User with a username </label> ");
            sb.Append($"<label> <label class='fw-bold'> {user.UserName}</label> already exists</label>");
            sb.Append("</div>");
            sb.Append("</fieldset></div>");

            LiteralControl write = new LiteralControl(sb.ToString());
            PanelFailed.Controls.Add(write);

            PanelRegistration.Visible = false;
            PanelFailed.Visible = true;
        }

        private void RenderData(User user)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div id='results' class='container p-4'><fieldset>");
            sb.Append($"<legend>{user.UserName}</legend>");
            sb.Append("<div class='mb-3'><label class='form-label'>First name: </label>");
            sb.Append($"<label class='fw-bold'>{user.UserName}</label>");
            sb.Append("</div>");
            sb.Append("<div class='mb-3'><label class='form-label'>Last name: </label>");
            sb.Append($"<label class='fw-bold'>{user.Email}</label>");
            sb.Append("</div>");
            sb.Append("<div class='mb-3'><label class='form-label'>City: </label>");
            sb.Append($"<label class='fw-bold'>{user.Address}</label>");
            sb.Append("</div>");
            sb.Append("<div class='mb-3'><label class='form-label'>Username: </label>");
            sb.Append($"<label class='fw-bold'>{user.PhoneNumber}</label>");
            sb.Append("</div>");
            sb.Append("<div class='mb-3'><label class='form-label'>Password: </label>");
            sb.Append($"<label class='fw-bold'>{user.PasswordHash}</label>");
            sb.Append("</div>");
            sb.Append("</fieldset></div>");

            LiteralControl write = new LiteralControl(sb.ToString());
            PanelSuccess.Controls.Add(write);

            PanelRegistration.Visible = false;
            PanelSuccess.Visible = true;
        }
    }
}