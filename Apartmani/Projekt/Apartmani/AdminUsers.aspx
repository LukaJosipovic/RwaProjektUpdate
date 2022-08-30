<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="AdminUsers.aspx.cs" Inherits="Apartmani.AdminUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="container p-5">
        <asp:Repeater ID="rptUsers" runat="server">
            
            <HeaderTemplate>
                <table id="myTable" class="table table-striped">
                    <thead>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">Username</th>
                            <th scope="col">Address</th>
                            <th scope="col">E-mail</th>
                            <th scope="col">Phone number</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            
            <ItemTemplate>
                <tr>
                    <th scope="row"><%#Eval(nameof(Apartmani.Model.User.Id)) %></th>
                    <td><%#Eval(nameof(Apartmani.Model.User.UserName)) %></td>
                    <td><%#Eval(nameof(Apartmani.Model.User.Address)) %></td>
                    <td><%#Eval(nameof(Apartmani.Model.User.Email)) %></td>
                    <td><%#Eval(nameof(Apartmani.Model.User.PhoneNumber)) %></td>
                </tr>
            </ItemTemplate>
            
            <FooterTemplate>
                </tbody>
            </table>
            </FooterTemplate>

        </asp:Repeater>
    </div>
</asp:Content>
