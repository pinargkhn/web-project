<%@ Page Title="Edit Bus" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBus.aspx.cs" Inherits="BusBookingSystem.Pages.EditBus" %>

<asp:Content ID="EditBusContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container bg-light rounded shadow-sm p-4 mt-5">
            <h1 class="text-center text-danger font-weight-bold mb-5">Edit Bus</h1>
            <div class="form-group">
                <label for="txtBusName">Bus Name:</label>
                <asp:TextBox ID="txtBusName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtDeparture">Departure Location:</label>
                <asp:TextBox ID="txtDeparture" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtArrival">Arrival Location:</label>
                <asp:TextBox ID="txtArrival" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtTime">Departure Time:</label>
                <asp:TextBox ID="txtTime" CssClass="form-control" runat="server"  TextMode="DateTimeLocal"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtSeats">Seats Available:</label>
                <asp:TextBox ID="txtSeats" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnUpdate" CssClass="btn btn-primary" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnCancel" CssClass="btn btn-danger" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
        </div>
    </form>
</asp:Content>
