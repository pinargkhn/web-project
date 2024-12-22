<%@ Page Title="Dashboard" Language="C#" MasterPageFile="/Site.Master" AutoEventWireup="true" CodeBehind="/Pages/Dashboards.aspx.cs" Inherits="BusBookingSystem.Pages.Dashboards" %>

<asp:Content ID="DashboardContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container bg-light rounded shadow-sm p-4 mt-5">
            <h1 class="text-center text-primary font-weight-bold mb-5">Admin Dashboard</h1>
            <div class="row mb-4">
                <!-- Manage Users -->
                <div class="col-md-3 text-center">
                    <asp:Button 
                        ID="btnManageUsers" 
                        runat="server" 
                        CssClass="btn btn-danger btn-lg btn-block" 
                        Text="Manage Users" 
                        OnClick="btnManageUsers_Click" />
                </div>
                <!-- Manage Buses -->
                <div class="col-md-3 text-center">
                    <asp:Button 
                        ID="btnManageBuses" 
                        runat="server" 
                        CssClass="btn btn-success btn-lg btn-block" 
                        Text="Manage Buses" 
                        OnClick="btnManageBuses_Click" />
                </div>
                <!-- Manage Companies -->
                <div class="col-md-3 text-center">
                    <asp:Button 
                        ID="btnManageCompanies" 
                        runat="server" 
                        CssClass="btn btn-info btn-lg btn-block" 
                        Text="Manage Companies" 
                        OnClick="btnManageCompanies_Click" />
                </div>
                <!-- Manage Bookings -->
                <div class="col-md-3 text-center">
                    <asp:Button 
                        ID="btnManageBookings" 
                        runat="server" 
                        CssClass="btn btn-warning btn-lg btn-block" 
                        Text="Manage Bookings" 
                        OnClick="btnManageBookings_Click" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>