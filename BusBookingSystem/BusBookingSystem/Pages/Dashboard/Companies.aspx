<%@ Page Title="Companies" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Pages/Dashboard/Companies.aspx.cs" Inherits="BusBookingSystem.Pages.Companies" %>

<asp:Content ID="CompaniesContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container bg-light rounded shadow-sm p-4 mt-5">
            <h1 class="text-center text-info font-weight-bold mb-5">Companies</h1>

            <!-- Add Button -->
            <div class="text-right mb-3">
                <asp:Button 
                    ID="btnAddCompany" 
                    runat="server" 
                    CssClass="btn btn-primary" 
                    Text="Add New Company" 
                    OnClick="btnAddCompany_Click" />
            </div>

            <div class="table-responsive">
                <asp:GridView 
                    ID="gvCompanies" 
                    runat="server" 
                    CssClass="table table-striped table-hover" 
                    AutoGenerateColumns="False" 
                    OnRowCommand="gvCompanies_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="CompanyID" HeaderText="Company ID" />
                        <asp:BoundField DataField="CompanyName" HeaderText="Company Name" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <!-- Edit Button -->
                                <asp:Button 
                                    ID="btnEditCompany" 
                                    runat="server" 
                                    CommandName="EditCompany" 
                                    CommandArgument='<%# Eval("CompanyID") %>' 
                                    Text="Edit" 
                                    CssClass="btn btn-primary btn-sm mr-2" />
                                <!-- Delete Button -->
                                <asp:Button 
                                    ID="btnDeleteCompany" 
                                    runat="server" 
                                    CommandName="DeleteCompany" 
                                    CommandArgument='<%# Eval("CompanyID") %>' 
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
