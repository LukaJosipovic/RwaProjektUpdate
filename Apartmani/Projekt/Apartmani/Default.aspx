<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Apartmani.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">


    <div class="container p-4">
        <form id="formLogin" method="post">
            <fieldset>
                <legend id="legend">Login</legend>
                <div class="mb-3">
                    <label for="username" class="form-label">Username</label>
                    <asp:TextBox ID="txtUsername" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUsername" Display="Dynamic" ForeColor="Red" runat="server">* Required</asp:RequiredFieldValidator>
                </div>
                <div class="mb-3">
                    <label for="password" class="form-label">Password</label>
                    <asp:TextBox ID="txtPassword" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red" runat="server">* Required</asp:RequiredFieldValidator>
                </div>
                <asp:Button ID="btnLogin" class="btn btn-primary" runat="server" Text="Submit" OnClick="btnLogin_Click"/>
            </fieldset>
        </form>

        <asp:Panel ID="PanelLoginFailed" CssClass="container p-3" runat="server" Visible="false">
            <div class="alert alert-danger" role="alert">
                Login failed, try again.
            </div>
        </asp:Panel>

    </div>



</asp:Content>
