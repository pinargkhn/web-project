<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyBooking.aspx.cs" Inherits="BusBookingSystem.Pages.CompanyBooking" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Company Bookings</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <style>
        body {
            background-color: #FF8260;
            font-family: Arial, sans-serif;
            padding: 20px;
        }
        .container {
            max-width: 1200px;
            margin: 0 auto;
            background-color: #FFF;
            border-radius: 8px;
            box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
            padding: 20px;
        }
        h1 {
            color: #707070;
            font-weight: bold;
        }
        .table {
            margin-top: 20px;
            border-radius: 8px;
            overflow: hidden;
        }
        .thead-dark {
            background-color: #969696;
            color: #FFF;
        }
        .table-hover tbody tr:hover {
            background-color: #FFD7B5;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="text-center">Company Bookings</h1>
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
                        <asp:BoundField DataField="BookingDate" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd}" />
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
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.4.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
