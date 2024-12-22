<%@ Page Title="Add New Bus" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Pages/Dashboard/Buses_AddBus.aspx.cs" Inherits="BusBookingSystem.Pages.Buses_AddBus" %>

<asp:Content ID="AddBusContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container bg-light rounded shadow-sm p-4 mt-5">
            <h1 class="text-center text-primary font-weight-bold mb-5">Add New Bus</h1>
            <div class="form-group">
                <label for="txtBusName">Bus Name:</label>
                <asp:TextBox ID="txtBusName" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtDepartureLocation">Departure Location:</label>
                <asp:TextBox ID="txtDepartureLocation" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtArrivalLocation">Arrival Location:</label>
                <asp:TextBox ID="txtArrivalLocation" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtDepartureTime">Departure Time:</label>
                <asp:TextBox ID="txtDepartureTime" runat="server" CssClass="form-control" TextMode="DateTime" />
            </div>
            <div class="form-group">
                <label for="txtSeatsAvailable">Seats Available:</label>
                <asp:TextBox ID="txtSeatsAvailable" runat="server" CssClass="form-control" TextMode="Number" />
            </div>
            <div class="form-group text-center mt-4">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" OnClick="btnCancel_Click" />
            </div>
        </div>
    </form>
</asp:Content>
