using Lib.Dal;
using Lib.Model;
using Lib.Sort;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apartmani
{
    public partial class AdminApartment : Access
    {
        //IList<Apartment> allApartments = new List<Apartment>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AppendSortItem();
                DataTable allApartments = ((IRepository)Application["database"]).LoadApartmentsReservation();
                LoadData(SortById.SortByIdAsc(allApartments));
            }
        }

        private void AppendSortItem()
        {
            ddlSortby.Items.Add(new ListItem("Number of rooms"));
            ddlSortby.Items.Add(new ListItem("Price"));
            ddlType.Items.Add(new ListItem("ASC"));
            ddlType.Items.Add(new ListItem("DESC"));
        }

        private void LoadData(DataTable ap)
        {
            gvApartments.DataSource = ap;
            gvApartments.DataBind();
            //rptApartments.DataSource = ap;
            //rptApartments.DataBind();
        }

        protected void btnSort_Click(object sender, EventArgs e)
        {
            DataTable allApartments = ((IRepository)Application["database"]).LoadApartmentsReservation();
            
            if (ddlSortby.SelectedValue == "Price" && ddlType.SelectedValue == "ASC")
            {
                LoadData(SortByPrice.SortByPriceAsc(allApartments));
            }
            else if (ddlSortby.SelectedValue == "Price" && ddlType.SelectedValue == "DESC")
            {
                LoadData(SortByPrice.SortByPriceDesc(allApartments));
            }
            else if (ddlSortby.SelectedValue == "Number of rooms" && ddlType.SelectedValue == "ASC")
            {
                LoadData(SortByRooms.SortByRoomsAsc(allApartments));
            }
            else
            {
                LoadData(SortByRooms.SortByRoomsDesc(allApartments));
            }
        }
    }
}