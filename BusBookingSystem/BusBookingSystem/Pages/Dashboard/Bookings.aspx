<%@ Page Title="Bookings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Pages/Dashboard/Bookings.aspx.cs" Inherits="BusBookingSystem.Pages.Bookings" %>

<asp:Content ID="BookingsContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container bg-light rounded shadow-sm p-4 mt-5">
            <h1 class="text-center text-warning font-weight-bold mb-5">Bookings</h1>

            <!-- Add Button -->
            <div class="text-right mb-3">
                <asp:Button 
                    ID="btnAddBooking" 
                    runat="server" 
                    CssClass="btn btn-primary" 
                    Text="Add New Booking" 
                    OnClick="btnAddBooking_Click" />
            </div>

            <div class="table-responsive">
                <asp:GridView 
                    ID="gvBookings" 
                    runat="server" 
                    CssClass="table table-striped table-hover" 
                    AutoGenerateColumns="False" 
                    OnRowCommand="gvBookings_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="BookingID" HeaderText="Booking ID" />
                        <asp:BoundField DataField="CustomerID" HeaderText="Customer ID" />
                        <asp:BoundField DataField="BusID" HeaderText="Bus ID" />
                        <asp:BoundField DataField="BookingDate" HeaderText="Booking Date" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <!-- Edit Button -->
                                <asp:Button 
                                    ID="btnEditBooking" 
                                    runat="server" 
                                    CommandName="EditBooking" 
                                    CommandArgument='<%# Eval("BookingID") %>' 
                                    Text="Edit" 
                                    CssClass="btn btn-primary btn-sm mr-2" />
                                <!-- Delete Button -->
                                <asp:Button 
                                    ID="btnDeleteBooking" 
                                    runat="server" 
                                    CommandName="DeleteBooking" 
                                    CommandArgument='<%# Eval("BookingID") %>' 
                                    Text="Delete" 
                                    CssClass="btn btn-danger btn-sm" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</asp:Content>
