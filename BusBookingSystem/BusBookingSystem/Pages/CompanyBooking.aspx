<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyBooking.aspx.cs" Inherits="BusBookingSystem.Pages.CompanyBooking" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Company Bookings</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }
        .container {
            margin: 20px;
        }
        .info-message {
            color: #f00;
            margin-top: 10px;
        }
        h1 {
            color: #333;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>All Bookings</h1>

            <!-- GridView for displaying bookings -->
            <asp:GridView 
                ID="gvBookings" 
                runat="server" 
                CssClass="table table-striped" 
                AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="BookingID" HeaderText="Booking ID" />
                    <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
                    <asp:BoundField DataField="BusName" HeaderText="Bus Name" />
                    <asp:BoundField DataField="BookingDate" HeaderText="Booking Date" DataFormatString="{0:dd/MM/yyyy hh:mm tt}" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                </Columns>
            </asp:GridView>

            <!-- No results message -->
            <asp:Label 
                ID="lblNoBookings" 
                runat="server" 
                CssClass="info-message" 
                Visible="false" 
                Text="No bookings found.">
            </asp:Label>
        </div>
    </form>
</body>
</html>
