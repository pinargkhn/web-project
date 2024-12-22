<%@ Page Title="Company Bookings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Pages/CompanyBooking.aspx.cs" Inherits="BusBookingSystem.Pages.CompanyBooking" %>

<asp:Content ID="BookContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <!-- Main Content -->
        <div class="container bg-white rounded shadow-sm p-4 mt-5">
            <h1 class="text-center text-primary font-weight-bold">Company Bookings</h1>
            <div class="table-responsive mt-4">
                <asp:GridView 
                    ID="gvBookings" 
                    runat="server" 
                    CssClass="table table-striped table-hover" 
                    AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="BookingID" HeaderText="Booking ID" />
                        <asp:BoundField DataField="BusName" HeaderText="Bus Name" />
                        <asp:BoundField DataField="DepartureLocation" HeaderText="Departure" />
                        <asp:BoundField DataField="ArrivalLocation" HeaderText="Arrival" />
                        <asp:BoundField DataField="BookingDate" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd}"/>
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                    </Columns>
                </asp:GridView>

                <!-- No results message -->
                <asp:Label 
                    ID="lblNoBookings" 
                    runat="server" 
                    CssClass="text-center text-danger mt-3 d-block" 
                    Visible="false" 
                    Text="No bookings found.">
                </asp:Label>
            </div>
        </div>
    </form>
</asp:Content>
