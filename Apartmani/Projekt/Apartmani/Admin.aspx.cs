using Apartmani.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apartmani
{
    public partial class Admin : Access
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminUsers.aspx");
        }

        protected void btnApartment_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminApartmentReservation.aspx");
        }

        protected void btnAddApartment_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddApartment.aspx");
        }

        protected void btnShowApartment_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminApartment.aspx");
        }

        protected void btnTags_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminTags.aspx");
        }
    }
}