<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Apartmani.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="container p-4">
        <fieldset>
            <legend id="legend">User</legend>

            <div class="mb-3">
                <label>Username</label>
                <p id="pUsername" runat="server"></p>
            </div>

            <div class="mb-3">
                <label>E-mail</label>
                <p id="pEmail" runat="server"></p>
            </div>

            <div class="mb-3">
                <label>Phone number</label>
                <p id="pPhoneNumber" runat="server"></p>
            </div>

            <div class="mb-3">
                <label>Address</label>
                <p id="pAddress" runat="server"></p>
            </div>

        </fieldset>
    </div>
</asp:Content>
