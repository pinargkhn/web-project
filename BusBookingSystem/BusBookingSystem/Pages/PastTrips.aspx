<%@ Page Title="Past Trips" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Pages/PastTrips.aspx.cs" Inherits="BusBookingSystem.Pages.PastTrips" %>

<asp:Content ID="PastTripsContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <!-- Main Content -->
        <div class="container bg-white rounded shadow-sm p-4 mt-5">
            <h1 class="text-center text-success font-weight-bold">Past Trips</h1>
            <div class="table-responsive mt-4">
                <asp:GridView 
                    ID="gvPastTrips" 
                    runat="server" 
                    CssClass="table table-striped table-hover" 
                    AutoGenerateColumns="False" 
                    OnRowCommand="gvPastTrips_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="BookingID" HeaderText="Booking ID" />
                        <asp:BoundField DataField="BusName" HeaderText="Bus Name" />
                        <asp:BoundField DataField="DepartureLocation" HeaderText="Departure" />
                        <asp:BoundField DataField="ArrivalLocation" HeaderText="Arrival" />
                        <asp:BoundField DataField="BookingDate" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%-- Cancel butonu yalnızca "Booked" durumunda gösterilir --%>
                                <asp:Button 
                                    ID="btnCancel" 
                                    runat="server" 
                                    CommandName="CancelTrip" 
                                    CommandArgument='<%# Eval("BookingID") %>' 
                                    Text="Cancel" 
                                    CssClass="btn btn-danger btn-sm"
                                    Visible='<%# Eval("Status").ToString() == "Booked" %>'
                                    OnClientClick="return confirm('Are you sure you want to cancel this trip?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <!-- No results message -->
                <asp:Label 
                    ID="lblNoPastTrips" 
                    runat="server" 
                    CssClass="text-center text-danger mt-3 d-block" 
                    Visible="false" 
                    Text="No past trips found.">
                </asp:Label>
            </div>
        </div>
    </form>
</asp:Content>
