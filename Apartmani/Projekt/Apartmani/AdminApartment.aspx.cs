using Lib.Dal;
using Lib.Sort;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apartmani
{
    public partial class AdminApartment1 : Access
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AppendSortItem();
                LoadDataById();
            }
        }

        private void LoadDataById()
        {
            DataTable allApartments = ((IRepository)Application["database"]).LoadApartment();
            LoadData(SortById.SortByIdAsc(allApartments));
        }

        private void AppendSortItem()
        {
            ddlSortby.Items.Add(new ListItem("Number of rooms"));
            ddlSortby.Items.Add(new ListItem("Price"));
            ddlType.Items.Add(new ListItem("ASC"));
            ddlType.Items.Add(new ListItem("DESC"));
        }

        protected void btnSort_Click(object sender, EventArgs e)
        {
            DataTable allApartments = ((IRepository)Application["database"]).LoadApartment();

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

        private void LoadData(DataTable ap)
        {
            gvApartments.DataSource = ap;
            gvApartments.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int ApartmentId = int.Parse(gvApartments.Rows[rowindex].Cells[0].Text);

            ((IRepository)Application["database"]).DeleteApartment(ApartmentId, DateTime.Now);
            DataTable allApartments = ((IRepository)Application["database"]).LoadApartment();
            LoadData(SortById.SortByIdAsc(allApartments));
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int ApartmentId = int.Parse(gvApartments.Rows[rowindex].Cells[0].Text);
            string name = gvApartments.Rows[rowindex].Cells[2].Text;
            int maxAdults = int.Parse(gvApartments.Rows[rowindex].Cells[5].Text);
            int maxChildren = int.Parse(gvApartments.Rows[rowindex].Cells[6].Text);
            int totalRooms = int.Parse(gvApartments.Rows[rowindex].Cells[7].Text);
            int beachDistance = int.Parse(gvApartments.Rows[rowindex].Cells[8].Text);

            lbName.Text = name;
            lbId.Text = ApartmentId.ToString();
            txtTotalRooms.Text = totalRooms.ToString();
            txtbMaxAdults.Text = maxAdults.ToString();
            txtMaxChildren.Text = maxChildren.ToString();
            txtBeachDistance.Text = beachDistance.ToString();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int ApartmentId = int.Parse(gvApartments.Rows[rowindex].Cells[0].Text);
            int maxAdults; 
            bool maxAdultsUpdate = int.TryParse(txtbMaxAdults.Text, out maxAdults);
            int maxChildren;
            bool maxChildernUpdate = int.TryParse(txtMaxChildren.Text, out maxChildren);
            int totalRooms;
            bool totalRoomsUpdate = int.TryParse(txtTotalRooms.Text, out totalRooms);
            int beachDistance;
            bool beachDisatnceUpdate = int.TryParse(txtBeachDistance.Text, out beachDistance);

            if (maxAdultsUpdate == true && maxChildernUpdate == true && totalRoomsUpdate == true && beachDisatnceUpdate == true)
            {
                ((IRepository)Application["database"]).UpdateApartment(ApartmentId, maxAdults, maxChildren, totalRooms, beachDistance);
                LoadDataById();
            }

            if (ImageUpload.HasFile)
            {
                HttpPostedFile postedFile = ImageUpload.PostedFile;
                string name = Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(name);
                int size = postedFile.ContentLength;

                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                {
                    Stream stream = postedFile.InputStream;
                    BinaryReader br = new BinaryReader(stream);
                    byte[] data = br.ReadBytes((int)stream.Length);

                    ((IRepository)Application["database"]).AddImage(ApartmentId, name, data);
                }
                else
                {
                    lbFormatError.Text = "The file must be an image (.jpg, .jpeg, .png)";
                }
            }
        }

        protected void btnDeleteImage_Click(object sender, EventArgs e)
        {
            if (ImageUpload.HasFile)
            {
                string extension = System.IO.Path.GetExtension(ImageUpload.FileName);
                string name = ImageUpload.FileName;
                int ApartmentId = int.Parse(lbId.Text);

                ((IRepository)Application["database"]).DeleteImage(ApartmentId, name, DateTime.Now);
            }
        }
    }
}
