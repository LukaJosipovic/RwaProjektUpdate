<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="AdminApartmentReservation.aspx.cs" Inherits="Apartmani.AdminApartment" %>

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
                <asp:BoundField DataField="Details" HeaderText="Details" />
                <asp:BoundField DataField="UserName" HeaderText="Unregistered user" />
                <asp:BoundField DataField="UserName1" HeaderText="Registered user" />
            </Columns>
        </asp:GridView>
       

        <%--<asp:Repeater ID="rptApartments" runat="server"></asp:Repeater>
            <HeaderTemplate>
                <table id="ApartmentsTable" class="table table-striped">
                    <thead>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">Name</th>
                            <th scope="col">NameEng</th>
                            <th scope="col">Address</th>
                            <th scope="col">Max adults</th>
                            <th scope="col">Max children</th>
                            <th scope="col">Total rooms</th>
                            <th scope="col">Price</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            
            <ItemTemplate>
                <tr>
                    <th scope="row"><%#Eval(nameof(Lib.Model.Apartment.Id)) %></th>
                    <td><%#Eval(nameof(Lib.Model.Apartment.Name)) %></td>
                    <td><%#Eval(nameof(Lib.Model.Apartment.NameEng)) %></td>
                    <td><%#Eval(nameof(Lib.Model.Apartment.Address)) %></td>
                    <td><%#Eval(nameof(Lib.Model.Apartment.MaxAdults)) %></td>
                    <td><%#Eval(nameof(Lib.Model.Apartment.MaxChildren)) %></td>
                    <td><%#Eval(nameof(Lib.Model.Apartment.TotalRooms)) %></td>
                    <td><%#Eval(nameof(Lib.Model.Apartment.Price)) %></td>
                </tr>
            </ItemTemplate>
            
            <FooterTemplate>
                </tbody>
            </table>
            </FooterTemplate>--%>
    </div>
</asp:Content>
