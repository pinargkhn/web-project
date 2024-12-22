<%@ Page Title="Users" Language="C#" MasterPageFile="/Site.Master" AutoEventWireup="true" CodeBehind="~/Pages/Dashboard/Users.aspx.cs" Inherits="BusBookingSystem.Pages.Users" %>

<asp:Content ID="ManageUsersContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container bg-light rounded shadow-sm p-4 mt-5">
            <h1 class="text-center text-danger font-weight-bold mb-5">Manage Users</h1>

            <!-- Add Button -->
            <div class="text-right mb-3">
                <asp:Button 
                    ID="btnAddUser" 
                    runat="server" 
                    CssClass="btn btn-primary" 
                    Text="Add New User" 
                    OnClick="btnAddUser_Click" />
            </div>

            <div class="table-responsive">
                <asp:GridView 
                    ID="gvUsers" 
                    runat="server" 
                    CssClass="table table-striped table-hover" 
                    AutoGenerateColumns="False" 
                    OnRowCommand="gvUsers_RowCommand"
                    OnRowDataBound="gvUsers_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="UserID" HeaderText="User ID" />
                        <asp:BoundField DataField="Username" HeaderText="Username" />
                        <asp:BoundField DataField="PasswordHash" HeaderText="Password" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="CompanyID" HeaderText="Company ID" />
                        <asp:TemplateField HeaderText="Is Admin">
                            <ItemTemplate>
                                <asp:CheckBox 
                                    ID="chkIsAdmin" 
                                    runat="server" 
                                    Checked='<%# Convert.ToBoolean(Eval("IsAdmin")) %>' 
                                    AutoPostBack="true" 
                                    OnCheckedChanged="chkIsAdmin_CheckedChanged" 
                                    ToolTip='<%# Eval("UserID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Is Developer">
                            <ItemTemplate>
                                <asp:CheckBox 
                                    ID="chkIsDeveloper" 
                                    runat="server" 
                                    Checked='<%# Convert.ToBoolean(Eval("IsDeveloper")) %>' 
                                    AutoPostBack="true" 
                                    OnCheckedChanged="chkIsDeveloper_CheckedChanged" 
                                    ToolTip='<%# Eval("UserID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <!-- Edit Button -->
                                <asp:Button 
                                    ID="btnEditUser" 
                                    runat="server" 
                                    CommandName="EditUser" 
                                    CommandArgument='<%# Eval("UserID") %>' 
                                    Text="Edit" 
                                    CssClass="btn btn-primary btn-sm mr-2" />
                                <!-- Delete Button -->
                                <asp:Button 
                                    ID="btnDeleteUser" 
                                    runat="server" 
                                    CommandName="DeleteUser" 
                                    CommandArgument='<%# Eval("UserID") %>' 
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
