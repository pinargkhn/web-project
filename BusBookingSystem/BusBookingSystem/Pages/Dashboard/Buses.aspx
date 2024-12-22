<%@ Page Title="Buses" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Pages/Dashboard/Buses.aspx.cs" Inherits="BusBookingSystem.Pages.Buses" %>

<asp:Content ID="BusesContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container bg-light rounded shadow-sm p-4 mt-5">
            <h1 class="text-center text-success font-weight-bold mb-5">Buses</h1>

            <!-- Add Button -->
            <div class="text-right mb-3">
                <asp:Button 
                    ID="btnAddBus" 
                    runat="server" 
                    CssClass="btn btn-primary" 
                    Text="Add New Bus" 
                    OnClick="btnAddBus_Click" />
            </div>

            <div class="table-responsive">
                <asp:GridView 
                    ID="gvBuses" 
                    runat="server" 
                    CssClass="table table-striped table-hover" 
                    AutoGenerateColumns="False" 
                    OnRowCommand="gvBuses_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="BusID" HeaderText="Bus ID" />
                        <asp:BoundField DataField="BusName" HeaderText="Bus Name" />
                        <asp:BoundField DataField="DepartureLocation" HeaderText="Departure Location" />
                        <asp:BoundField DataField="ArrivalLocation" HeaderText="Arrival Location" />
                        <asp:BoundField DataField="DepartureTime" HeaderText="Departure Time" />
                        <asp:BoundField DataField="SeatsAvailable" HeaderText="Seats Available" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <!-- Edit Button -->
                                <asp:Button 
                                    ID="btnEditBus" 
                                    runat="server" 
                                    CommandName="EditBus" 
                                    CommandArgument='<%# Eval("BusID") %>' 
                                    Text="Edit" 
                                    CssClass="btn btn-primary btn-sm mr-2" />

                                <!-- Delete Button -->
                                <asp:Button 
                                    ID="btnDeleteBus" 
                                    runat="server" 
                                    CommandName="DeleteBus" 
                                    CommandArgument='<%# Eval("BusID") %>' 
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