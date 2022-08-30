using Lib.Dal;
using Lib.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apartmani
{
    public partial class AdminTags : Access
    {
        private IList<Tag> allTags;
        protected void Page_Load(object sender, EventArgs e)
        {
            PanelSuccess.Visible = false;
            PanelFailed.Visible = false;

            if (!IsPostBack)
            {
                ddlTagType.Items.Add("Aparati");
                ddlTagType.Items.Add("Područja");
                ddlTagType.Items.Add("Ostalo");
                LoadData();
            }
        }


        protected void btnDeleteTag_Click(object sender, EventArgs e)
        {
            LinkButton btnDelete = (LinkButton)sender;
            int tagID = int.Parse(btnDelete.CommandArgument);

            IList<TaggedApartment> taggedApartments = new List<TaggedApartment>();
            taggedApartments = ((IRepository)Application["database"]).LoadTagedApartment();

            if (taggedApartments.Contains(new TaggedApartment { TagId = tagID }))
            {
                Response.Write("<script>alert('The tag you want to delete is currently in use')</script>");
            }
            else
            {
                ((IRepository)Application["database"]).DeleteTag(tagID);
                LoadData();
            }
        }
        private void LoadData()
        {
            txtName.Text = string.Empty;
            txtNameEng.Text = string.Empty;

            allTags = ((IRepository)Application["database"]).LoadTags();
            rptTags.DataSource = allTags;
            rptTags.DataBind();
        }
        protected void btnAddTag_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" || txtNameEng.Text != "")
            {
                string tagName = txtName.Text;
                string tagNameEng = txtNameEng.Text;
                string tagType = ddlTagType.SelectedValue;

                allTags = ((IRepository)Application["database"]).LoadTags();
                if (!allTags.Contains(new Tag { Name = txtName.Text }))
                {
                    ((IRepository)Application["database"]).AddTag(tagName, tagNameEng, tagType);
                    PanelSuccess.Visible = true;
                    PanelFailed.Visible = false;
                }
                else
                {
                    PanelSuccess.Visible = false;
                    PanelFailed.Visible = true;
                }
                LoadData();
            }
        }
    }
}