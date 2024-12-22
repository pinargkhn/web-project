<%@ Page Title="Add Booking" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Pages/Dashboard/Bookings_AddBooking.aspx.cs" Inherits="BusBookingSystem.Pages.AddBooking" %>

<asp:Content ID="AddBookingContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container bg-light rounded shadow-sm p-4 mt-5">
            <h1 class="text-center text-primary font-weight-bold mb-5">Add New Booking</h1>
            <div class="form-group">
                <label for="txtCustomerID">Customer ID:</label>
                <asp:TextBox ID="txtCustomerID" CssClass="form-control" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtBusID">Bus ID:</label>
                <asp:TextBox ID="txtBusID" CssClass="form-control" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtBookingDate">Booking Date:</label>
                <asp:TextBox ID="txtBookingDate" CssClass="form-control" runat="server"  TextMode="DateTimeLocal" />
            </div>
            <div class="form-group">
                <label for="txtStatus">Status:</label>
                <asp:TextBox ID="txtStatus" CssClass="form-control" runat="server" />
            </div>
            <div class="form-group text-center mt-4">
                <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnCancel" CssClass="btn btn-secondary" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
        </div>
    </form>
</asp:Content>
