<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="AdminApartment.aspx.cs" Inherits="Apartmani.AdminApartment1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="container p-3">
        <span id="sort" class="container p-3">
            <asp:Label ID="Label1" runat="server" CssClass="form-label" Text="Sort by"></asp:Label>
            <asp:DropDownList ID="ddlSortby" CssClass="form-select-sm" runat="server"></asp:DropDownList>
            <span class="container p-3">
                <asp:Label ID="Label2" runat="server" CssClass="form-label" Text="Sort type"></asp:Label>
                <asp:DropDownList ID="ddlType" CssClass="form-select-sm" runat="server"></asp:DropDownList>
            </span>

            <asp:Button ID="btnSort" class="btn btn-primary" runat="server" Text="Button" OnClick="btnSort_Click" />
        </span>
    </div>

    <div class="container p-3">
        <asp:GridView ID="gvApartments" AutoGenerateColumns="false" CssClass="table table-striped" runat="server">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="Name" HeaderText="Apartment name" />
                <asp:BoundField DataField="NameEng" HeaderText="Apartment eng name" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:BoundField DataField="MaxAdults" HeaderText="Max Adults" />
                <asp:BoundField DataField="MaxChildren" HeaderText="Max Children" />
                <asp:BoundField DataField="TotalRooms" HeaderText="Total Rooms" />
                <asp:BoundField DataField="BeachDistance" HeaderText="Beach Distance" />
                <asp:BoundField DataField="Name1" HeaderText="City" />
                <asp:BoundField DataField="Name2" HeaderText="Apartment owner" />
                <asp:BoundField DataField="Name3" HeaderText="Status" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDelete" CssClass="btn btn-primary" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete apartment?')" runat="server">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnSelect" CssClass="btn btn-dark" OnClick="btnSelect_Click" runat="server">Select</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnUpdate" CssClass="btn btn-light" OnClick="btnUpdate_Click" runat="server">Update</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div class="container p-3">
            <fieldset>
                <legend id="legend">Edit apartment</legend>

                <div class="container p-2">
                    <asp:Label ID="lbName" CssClass="form-label" runat="server"></asp:Label>
                </div>

                <div class="container p-2">
                    <asp:Label ID="lbId" CssClass="form-label" runat="server"></asp:Label>
                </div>

                <div class="container p-2">
                    <asp:Label ID="lbTotalRooms" CssClass="form-label" runat="server" Text="Total rooms"></asp:Label>
                    <asp:TextBox ID="txtTotalRooms" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="container p-2">
                    <asp:Label ID="lbMaxAdults" CssClass="form-label" runat="server" Text="Max adults"></asp:Label>
                    <asp:TextBox ID="txtbMaxAdults" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="container p-2">
                    <asp:Label ID="lbMaxChildren" CssClass="form-label" runat="server" Text="Max children"></asp:Label>
                    <asp:TextBox ID="txtMaxChildren" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="container p-2">
                    <asp:Label ID="lbBeachDistance" CssClass="form-label" runat="server" Text="Beach distance"></asp:Label>
                    <asp:TextBox ID="txtBeachDistance" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="container p-2">
                    <asp:Label ID="lbImageUplad" for="ImageUpload" class="form-label" runat="server" Text="Upload image"></asp:Label>
                    <asp:FileUpload ID="ImageUpload" CssClass="form-control" runat="server"/>
                    <asp:Label ID="lbFormatError" class="form-label" runat="server"></asp:Label>
                    <asp:Button ID="btnDeleteImage" CssClass="btn btn-primary" runat="server" Text="Delete image" OnClick="btnDeleteImage_Click" />
                </div>

            </fieldset>
        </div>
    </div>
</asp:Content>
