<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigationMenu.ascx.cs" Inherits="BusBookingSystem.UserControls.NavigationMenu" %>

<nav id="tg-nav" class="tg-nav">
    <div class="navbar-header">
        <a href="#menu" class="navbar-toggle collapsed">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
        </a>
    </div>
    <div id="tg-navigation" class="collapse navbar-collapse tg-navigation">
        <ul>
            <li><a href="/">Home</a></li>
            <li><a href="/Pages/Book">Start Booking</a></li>
            <asp:Literal ID="loginMenu" runat="server" Visible="false">
            <li class="menu-item-has-children"><a href="javascript:void(0);">Login</a>
                <ul class="sub-menu">
                    <li><a href="../Pages/register.aspx">Register</a></li>
                    <li><a href="../Pages/logIn.aspx">Login</a></li>
                </ul>
            </li>
            </asp:Literal>
            <asp:Literal ID="adminMenu" runat="server" Visible="false">
                <li><a href="/Pages/CompanyBus">Company Dashboard</a></li>
            </asp:Literal>
            <asp:Literal ID="developerMenu" runat="server" Visible="false">
                <li><a href="/Pages/Dashboards">Admin Dashboard</a></li>
            </asp:Literal>
        </ul>
    </div>
</nav>
