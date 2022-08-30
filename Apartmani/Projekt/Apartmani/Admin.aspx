<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Apartmani.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="container p-4">
        <fieldset>
            <legend id="legend">Apartments reservation</legend>
            <div>
                <label class="form-label">Apartments reservation</label>
            </div>
            <asp:Button ID="btnApartment" CssClass="btn btn-primary" runat="server" Text="Show reservation" OnClick="btnApartment_Click" />
        </fieldset>
    </div>
    
    <div class="container p-4">
        <fieldset>
            <legend id="legend">Apartments</legend>
            <div>
                <label class="form-label">Show apartments</label>
            </div>
            <asp:Button ID="btnShowApartment" CssClass="btn btn-primary" runat="server" Text="Show apartments" OnClick="btnShowApartment_Click" />
        </fieldset>
    </div>

    <div class="container p-4">
        <fieldset>
            <legend id="legend">Apartments</legend>
            <div>
                <label class="form-label">Add apartment</label>
            </div>
            <asp:Button ID="btnAddApartment" CssClass="btn btn-primary" runat="server" Text="Add apartment" OnClick="btnAddApartment_Click" />
        </fieldset>
    </div>

    <div class="container p-4">
        <fieldset>
            <legend id="legend">Users</legend>
            <div>
                <label class="form-label">Show a list of all users</label>
            </div>
            <asp:Button ID="btnUsers" CssClass="btn btn-primary" runat="server" Text="Show" OnClick="btnUsers_Click" />
        </fieldset>
    </div>

    <div class="container p-4">
        <fieldset>
            <legend id="legend">Tags</legend>
            <div>
                <label class="form-label">Tags administration</label>
            </div>
            <asp:Button ID="btnTags" CssClass="btn btn-primary" runat="server" Text="Administration" OnClick="btnTags_Click" />
        </fieldset>
    </div>
</asp:Content>
