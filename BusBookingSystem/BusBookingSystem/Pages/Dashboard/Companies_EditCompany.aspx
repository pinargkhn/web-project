<%@ Page Title="Edit Company" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Pages/Dashboard/Companies_EditCompany.aspx.cs" Inherits="BusBookingSystem.Pages.EditCompany" %>

<asp:Content ID="EditCompanyContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container bg-light rounded shadow-sm p-4 mt-5">
            <h1 class="text-center text-primary font-weight-bold mb-5">Edit Company</h1>
            <div class="form-group">
                <label for="txtCompanyName">Company Name:</label>
                <asp:TextBox ID="txtCompanyName" CssClass="form-control" runat="server" />
            </div>
            <div class="form-group text-center mt-4">
                <asp:Button ID="btnUpdate" CssClass="btn btn-success" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnCancel" CssClass="btn btn-secondary" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
        </div>
    </form>
</asp:Content>
