<%@ Page Title="Manage Buses" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Pages/CompanyBus.aspx.cs" Inherits="BusBookingSystem.Pages.CompanyBus" %>

<asp:Content ID="BusContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container bg-white rounded shadow-sm p-4 mt-5">
            <h1 class="text-center text-primary font-weight-bold">Manage Buses</h1>

            <!-- Add and Edit Buttons -->
            <div class="text-right mb-3">
                <asp:Button 
                    ID="btnAddBus" 
                    runat="server" 
                    Text="Add Bus" 
                    CssClass="btn btn-primary" 
                    OnClick="btnAddBus_Click" />
            </div>

            <!-- Buses Table -->
            <div class="table-responsive mt-4">
                <asp:GridView 
                    ID="gvBuses" 
                    runat="server" 
                    CssClass="table table-striped table-hover" 
                    AutoGenerateColumns="False" 
                    OnRowDeleting="gvBuses_RowDeleting" 
                    OnRowCommand="gvBuses_RowCommand" 
                    DataKeyNames="BusID">
                    <Columns>
                        <asp:BoundField DataField="BusID" HeaderText="Bus ID" ReadOnly="True" />
                        <asp:BoundField DataField="BusName" HeaderText="Bus Name" />
                        <asp:BoundField DataField="DepartureLocation" HeaderText="Departure" />
                        <asp:BoundField DataField="ArrivalLocation" HeaderText="Arrival" />
                        <asp:BoundField DataField="DepartureTime" HeaderText="Time" />
                        <asp:BoundField DataField="SeatsAvailable" HeaderText="Seats" />
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Actions" />
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:Button 
                                    ID="btnEdit" 
                                    runat="server" 
                                    CssClass="btn btn-warning btn-sm" 
                                    Text="Edit" 
                                    CommandName="EditBus" 
                                    CommandArgument='<%# Eval("BusID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <!-- No results message -->
                <asp:Label 
                    ID="lblNoBuses" 
                    runat="server" 
                    CssClass="text-center text-danger mt-3 d-block" 
                    Visible="false" 
                    Text="No buses found.">
                </asp:Label>
            </div>
        </div>
    </form>
</asp:Content>
