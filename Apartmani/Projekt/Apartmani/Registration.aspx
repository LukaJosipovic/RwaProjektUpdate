<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Apartmani.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <asp:Panel ID="PanelRegistration" CssClass="container p-4" runat="server" Visible="true">
        <form id="formRegistration" method="post" action="Registration.aspx">
            <fieldset>
                <legend id="legend">Registration</legend>

                <div class="mb-3">
                    <asp:Label ID="lbUsername" for="txtUsername" class="form-label" runat="server" Text="Username"></asp:Label>
                    <asp:TextBox ID="txtUsername" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUsername" Display="Dynamic" ForeColor="Red" runat="server">* Required</asp:RequiredFieldValidator>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lbEmail" for="txtEmail" class="form-label" runat="server" Text="E-mail"></asp:Label>
                    <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" runat="server">* Required</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtEmail" ValidationExpression="^\S+@\S+$" ForeColor="Red" runat="server">*Invalid email address</asp:RegularExpressionValidator>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lbEmailConfirmed" for="txtEmailConfirmed" class="form-label" runat="server" Text="Confirmed E-mail"></asp:Label>
                    <asp:TextBox ID="txtEmailConfirmed" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtEmailConfirmed" Display="Dynamic" ForeColor="Red" runat="server">* E-mail must be confirmed</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtEmailConfirmed" ControlToCompare="txtEmail" runat="server" Display="Dynamic" ForeColor="Red">* E-mails are not the same</asp:CompareValidator>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lbAddress" for="txtAddress" class="form-label" runat="server" Text="Address"></asp:Label>
                    <asp:TextBox ID="txtAddress" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtAddress" Display="Dynamic" ForeColor="Red" runat="server">* Required</asp:RequiredFieldValidator>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lbPhoneNumber" for="txtPhoneNumber" class="form-label" runat="server" Text="Phone number"></asp:Label>
                    <asp:TextBox ID="txtPhoneNumber" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtPhoneNumber" Display="Dynamic" ForeColor="Red" runat="server">* Required</asp:RequiredFieldValidator>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lbPhoneNumberConfirmed" for="txtPhoneNumberConfirmed" class="form-label" runat="server" Text="Confirmed phone number"></asp:Label>
                    <asp:TextBox ID="txtPhoneNumberConfirmed" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtPhoneNumberConfirmed" Display="Dynamic" ForeColor="Red" runat="server">* Phone number must be confirmed</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" ControlToValidate="txtPhoneNumberConfirmed" ControlToCompare="txtPhoneNumber" runat="server" Display="Dynamic" ForeColor="Red">* Phone numbers are not the same</asp:CompareValidator>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblPassword" for="txtPassword" class="form-label" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="txtPassword" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red" runat="server">* Required</asp:RequiredFieldValidator>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblPasswordConfirm" for="txtPasswordConfirm" class="form-label" runat="server" Text="Confirmed password"></asp:Label>
                    <asp:TextBox ID="txtPasswordConfirmed" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtPasswordConfirmed" Display="Dynamic" ForeColor="Red" runat="server">* Password must be confirmed</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator3" ControlToValidate="txtPasswordConfirmed" ControlToCompare="txtPassword" runat="server" Display="Dynamic" ForeColor="Red">* Passwords are not the same</asp:CompareValidator>
                </div>

                <asp:Button ID="btnSend" class="btn btn-primary" runat="server" Text="Submit" OnClick="btnSend_Click" />
            </fieldset>
        </form>
    </asp:Panel>

    <asp:Panel ID="PanelSuccess" runat="server" Visible="false">
        <div class="alert alert-success" role="alert">
            Registration success, login with your account <a href="Default.aspx">Login</a>.
        </div>
    </asp:Panel>

    <asp:Panel ID="PanelFailed" runat="server" Visible="false">
        <div class="alert alert-danger" role="alert">
            Registration failed, try again <a href="Registration.aspx">Registration</a>.
        </div>
    </asp:Panel>

</asp:Content>
