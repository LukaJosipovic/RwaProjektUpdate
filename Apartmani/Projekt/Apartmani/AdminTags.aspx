<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="AdminTags.aspx.cs" Inherits="Apartmani.AdminTags" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="container p-5">
                    <asp:Repeater ID="rptTags" runat="server">

                        <HeaderTemplate>
                            <table id="myTable" class="table table-striped">
                                <thead>
                                    <tr>
                                        <th scope="col">Id</th>
                                        <th scope="col">Name</th>
                                        <th scope="col">NameEng</th>
                                        <th scope="col"></th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>

                        <ItemTemplate>
                            <tr>
                                <th scope="row"><%#Eval(nameof(Lib.Model.Tag.Id)) %></th>
                                <td><%#Eval(nameof(Lib.Model.Tag.Name)) %></td>
                                <td><%#Eval(nameof(Lib.Model.Tag.NameEng)) %></td>
                                <td>
                                    <asp:LinkButton ID="btnDeleteTag" OnClick="btnDeleteTag_Click" CssClass="btn btn-primary" OnClientClick="return confirm('Are you sure you want to delete tag?')" CommandArgument="<%#Eval(nameof(Lib.Model.Tag.Id)) %>" runat="server">Delete</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>

                        <FooterTemplate>
                            </tbody>
                        </table>
                        </FooterTemplate>

                    </asp:Repeater>
                </div>
            </div>

            <div class="col-md-6">
                <div class="container p-3">
                    <fieldset>
                        <legend id="legend">Add Tag</legend>

                        <div class="container p-3">
                            <asp:Label ID="lbName" CssClass="form-label" runat="server" Text="Tag name"></asp:Label>
                            <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="container p-3">
                            <asp:Label ID="lbNameEng" CssClass="form-label" runat="server" Text="Tag name in English"></asp:Label>
                            <asp:TextBox ID="txtNameEng" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="container p-3">
                            <asp:Label ID="lbTagType" CssClass="form-label" runat="server" Text="Tag type"></asp:Label>
                            <asp:DropDownList ID="ddlTagType" CssClass="form-select" runat="server"></asp:DropDownList>
                        </div>

                        <div class="container p-3">
                            <asp:Button ID="btnAddTag" CssClass="btn btn-primary" runat="server" Text="Add" OnClick="btnAddTag_Click" />
                        </div>
                    </fieldset>
                </div>
                
                <asp:Panel ID="PanelSuccess" runat="server">
                    <div class="alert alert-success" role="alert">
                        Tag successfully added.
                    </div>
                </asp:Panel>

                <asp:Panel ID="PanelFailed" runat="server">
                    <div class="alert alert-danger" role="alert">
                        Tag already exists.
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
