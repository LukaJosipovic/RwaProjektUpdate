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
    public partial class AdminUsers : Access
    {
        private IList<User> allUsers = new List<User>();
        protected void Page_Load(object sender, EventArgs e)
        {
            allUsers = ((IRepository)Application["database"]).LoadUsers();
            
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            rptUsers.DataSource = allUsers;
            rptUsers.DataBind();
        }
    }
}