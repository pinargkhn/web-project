<%@ Page Title="Edit Bus" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Pages/EditBus.aspx.cs" Inherits="BusBookingSystem.Pages.EditBus" %>

<asp:Content ID="EditBusContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container bg-white rounded shadow-sm p-4 mt-5">
            <h1 class="text-center text-primary font-weight-bold">Edit Bus</h1>

            <!-- Edit Bus Form -->
            <div class="form-group mt-4">
                <label for="txtBusName">Bus Name:</label>
                <asp:TextBox ID="txtBusName" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtDeparture">Departure Location:</label>
                <asp:TextBox ID="txtDeparture" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtArrival">Arrival Location:</label>
                <asp:TextBox ID="txtArrival" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtTime">Departure Time:</label>
                <asp:TextBox ID="txtTime" runat="server" CssClass="form-control" TextMode="DateTimeLocal" />
            </div>
            <div class="form-group">
                <label for="txtSeats">Seats Available:</label>
                <asp:TextBox ID="txtSeats" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" PostBackUrl="~/Pages/CompanyBus.aspx" />
        </div>
    </form>
</asp:Content>
