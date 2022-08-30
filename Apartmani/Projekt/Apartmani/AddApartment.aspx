<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="AddApartment.aspx.cs" Inherits="Apartmani.AddApartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <asp:Panel ID="PanelAddApartment" CssClass="container p-4" runat="server" Visible="true">
        <form id="formAddApartment" method="post" action="AddApartment.aspx">
            <fieldset>
                <legend id="legend">Add apartment</legend>

                <div class="mb-3">
                    <asp:Label ID="lbOwner" class="form-label" runat="server" Text="Owner"></asp:Label>
                    <asp:DropDownList ID="ddlOwner" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lbStatus" class="form-label" runat="server" Text="Status"></asp:Label>
                    <asp:DropDownList ID="ddlStatus" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lbCity" class="form-label" runat="server" Text="City"></asp:Label>
                    <asp:DropDownList ID="ddlCity" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lbAddress" for="txtAddress" class="form-label" runat="server" Text="Address"></asp:Label>
                    <asp:TextBox ID="txtAddress" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtAddress" Display="Dynamic" ForeColor="Red" runat="server">* Required</asp:RequiredFieldValidator>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lbNmae" for="txtPhoneNumber" class="form-label" runat="server" Text="Name"></asp:Label>
                    <asp:TextBox ID="txtName" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtName" Display="Dynamic" ForeColor="Red" runat="server">* Required</asp:RequiredFieldValidator>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lbNmaeEng" for="txtNameEng" class="form-label" runat="server" Text="Name in English"></asp:Label>
                    <asp:TextBox ID="txtNameEng" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtNameEng" Display="Dynamic" ForeColor="Red" runat="server">* Required</asp:RequiredFieldValidator>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lbPrice" for="txtPrice" class="form-label" runat="server" Text="Price"></asp:Label>
                    <asp:TextBox ID="txtPrice" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtPrice" Display="Dynamic" ForeColor="Red" runat="server">* Required</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtPrice" ValidationExpression="\d+" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="* Must be a integer"></asp:RegularExpressionValidator>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lbMaxAdults" for="txtMaxAdults" class="form-label" runat="server" Text="Max adults"></asp:Label>
                    <asp:TextBox ID="txtMaxAdults" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtMaxAdults" Display="Dynamic" ForeColor="Red" runat="server">* Required</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtMaxAdults" ValidationExpression="\d+" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="* Must be a integer"></asp:RegularExpressionValidator>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lbMaxChildren" for="txtMaxChildren" class="form-label" runat="server" Text="Max children"></asp:Label>
                    <asp:TextBox ID="txtMaxChildren" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtMaxChildren" Display="Dynamic" ForeColor="Red" runat="server">* Required</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtMaxChildren" ValidationExpression="\d+" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="* Must be a integer"></asp:RegularExpressionValidator>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lbTotalRooms" for="txtTotalRooms" class="form-label" runat="server" Text="Total rooms"></asp:Label>
                    <asp:TextBox ID="txtTotalRooms" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtTotalRooms" Display="Dynamic" ForeColor="Red" runat="server">* Required</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtTotalRooms" ValidationExpression="\d+" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="* Must be a integer"></asp:RegularExpressionValidator>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lbBeachDistance" for="txtBeachDistance" class="form-label" runat="server" Text="Beach distance"></asp:Label>
                    <asp:TextBox ID="txtBeachDistance" class="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtBeachDistance" ValidationExpression="\d+" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="* Must be a integer"></asp:RegularExpressionValidator>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lbImageUplad" for="ImageUpload" class="form-label" runat="server" Text="Upload representative image"></asp:Label>
                    <asp:FileUpload ID="ImageUpload" CssClass="form-control" runat="server" />
                    <asp:Label ID="lbFormatError" class="form-label" runat="server"></asp:Label>
                </div>
                
                <div class="mb-3">
                    <asp:Label ID="lbTags" class="form-label" runat="server" Text="Tags"></asp:Label>
                    <asp:CheckBoxList ID="CBLTags" runat="server"></asp:CheckBoxList>
                </div>

                <asp:Button ID="btnAdd" class="btn btn-primary" runat="server" Text="Add" OnClick="btnAdd_Click" />
            </fieldset>
        </form>
    </asp:Panel>

    <asp:Panel ID="PanelSuccess" runat="server" Visible="false">
        <div class="alert alert-success" role="alert">
            Successfully adding an apartment
        </div>
    </asp:Panel>

    <asp:Panel ID="PanelWarning" runat="server" Visible="false">
        <div class="alert alert-warning" role="alert">
            The specified name is already in use
        </div>
    </asp:Panel>

</asp:Content>
