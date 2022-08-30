using Lib.Dal;
using Lib.Model;
using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


namespace Apartmani
{
    public partial class AddApartment : Access
    {
        IList<Owner> owners = new List<Owner>();
        IList<Status> statuses = new List<Status>();
        IList<City> cities = new List<City>();
        IList<Tag> tags = new List<Tag>();
        protected void Page_Load(object sender, EventArgs e)
        {
            PanelAddApartment.Visible = true;
            PanelSuccess.Visible = false;

            owners = ((IRepository)Application["database"]).LoadOwners();
            statuses = ((IRepository)Application["database"]).LoadStatus();
            cities = ((IRepository)Application["database"]).LoadCities();
            tags = ((IRepository)Application["database"]).LoadTags();
            
            if (!IsPostBack)
            {
                AppendOwners(owners);
                AppendStatuses(statuses);
                AppendCities(cities);
                AppendTags(tags);
            }
        }

        private void AppendTags(IList<Tag> tags)
        {
            for (int i = 0; i < tags.Count; i++)
            {
                CBLTags.Items.Add(new ListItem(tags[i].Name));
            }
        }

        private void AppendCities(IList<City> cities)
        {
            for (int i = 0; i < cities.Count; i++)
            {
                ddlCity.Items.Add(new ListItem(cities[i].Name));
            }
        }

        private void AppendStatuses(IList<Status> statuses)
        {
            for (int i = 0; i < statuses.Count; i++)
            {
                ddlStatus.Items.Add(new ListItem(statuses[i].Name));
            }
        }

        private void AppendOwners(IList<Owner> owners)
        {
            for (int i = 0; i < owners.Count; i++)
            {
                ddlOwner.Items.Add(new ListItem(owners[i].Name));
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string owner = ddlOwner.SelectedValue;
                string status = ddlStatus.SelectedValue;
                string city = ddlCity.SelectedValue;

                IList<ListItem> tags = new List<ListItem>();
                foreach (ListItem item in CBLTags.Items)
                {
                    if (item.Selected)
                    {
                        tags.Add(item);
                    }
                }

                Apartment apartment = Apartment();

                if (tags.Count == 0)
                {
                    AddNoTagApartment(owner, status, city, apartment);
                }
                else
                {
                    AddApartmentWithTags(owner, status, city, apartment, tags);
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

                        ((IRepository)Application["database"]).AddRepresentativeImage(name, data);
                    }
                    else
                    {
                        lbFormatError.Text = "The file must be an image (.jpg, .jpeg, .png)";
                    }
                }
            }
        }

        private Apartment Apartment()
        {
            if (string.IsNullOrEmpty(txtBeachDistance.Text))
            {
                return new Apartment
                {
                    Address = txtAddress.Text,
                    Name = txtName.Text,
                    NameEng = txtNameEng.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    MaxAdults = int.Parse(txtMaxAdults.Text),
                    MaxChildren = int.Parse(txtMaxChildren.Text),
                    TotalRooms = int.Parse(txtTotalRooms.Text),
                };
            }
            else
            {
                return new Apartment
                {
                    Address = txtAddress.Text,
                    Name = txtName.Text,
                    NameEng = txtNameEng.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    MaxAdults = int.Parse(txtMaxAdults.Text),
                    MaxChildren = int.Parse(txtMaxChildren.Text),
                    TotalRooms = int.Parse(txtTotalRooms.Text),
                    BeachDistance = int.Parse(txtBeachDistance.Text)
                };
            }
        }

        private void AddApartmentWithTags(string owner, string status, string city, Apartment apartment, IList<ListItem> tags)
        {
            var name = ((IRepository)Application["database"]).ApartmentName(apartment.Name);
            if (string.IsNullOrEmpty(name))
            {
                ((IRepository)Application["database"]).AddApartment(owner, status, city, apartment);

                for (int i = 0; i < tags.Count; i++)
                {
                    ((IRepository)Application["database"]).AddTaggedApartment(apartment.Name, tags[i].Value);
                }
                PanelAddApartment.Visible = false;
                PanelSuccess.Visible = true;
            }
            else
            {
                PanelAddApartment.Visible = false;
                PanelWarning.Visible = true;
            }
        }

        private void AddNoTagApartment(string owner, string status, string city, Apartment apartment)
        {
            ((IRepository)Application["database"]).AddApartment(owner, status, city, apartment);

            PanelAddApartment.Visible = false;
            PanelSuccess.Visible = true;
        }
    }
}