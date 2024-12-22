<%@ Page Title="Add Company" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Pages/Dashboard/Companies_AddCompany.aspx.cs" Inherits="BusBookingSystem.Pages.AddCompany" %>

<asp:Content ID="AddCompanyContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container bg-light rounded shadow-sm p-4 mt-5">
            <h1 class="text-center text-primary font-weight-bold mb-5">Add New Company</h1>
            <div class="form-group">
                <label for="txtCompanyName">Company Name:</label>
                <asp:TextBox ID="txtCompanyName" CssClass="form-control" runat="server" />
            </div>
            <div class="form-group text-center mt-4">
                <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnCancel" CssClass="btn btn-secondary" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
        </div>
    </form>
</asp:Content>
