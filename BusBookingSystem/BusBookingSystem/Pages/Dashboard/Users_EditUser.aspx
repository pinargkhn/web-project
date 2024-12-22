<%@ Page Title="Edit User" Language="C#" MasterPageFile="/Site.Master" AutoEventWireup="true" CodeBehind="~/Pages/Dashboard/Users_EditUser.aspx.cs" Inherits="BusBookingSystem.Pages.Users_EditUser" %>

<asp:Content ID="EditUserContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container bg-light rounded shadow-sm p-4 mt-5">
            <h1 class="text-center text-primary font-weight-bold mb-5">Edit User</h1>
            <div class="form-group">
                <label for="txtUsername">Username:</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtPassword">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
            </div>
            <div class="form-group">
                <label for="txtEmail">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group text-center mt-4">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" OnClick="btnCancel_Click" />
            </div>
        </div>
    </form>
</asp:Content>
