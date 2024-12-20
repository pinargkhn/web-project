<%@ Page Title="Book a Bus" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Pages/Book.aspx.cs" Inherits="BusBookingSystem.Pages.Book" %>

<asp:Content ID="BookContent" ContentPlaceHolderID="MainContent" runat="server">
	<div class="container">
		<div class="row">
			<h1>Book a Bus</h1>
			<asp:Label ID="lblMessage" runat="server" CssClass="info-message"></asp:Label>
			<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
				<form class="tg-formtheme tg-formtrip" runat="Server">
					<fieldset>
						<br />
						<!-- Search Filters -->
						<div class="form-group">
							<asp:TextBox ID="departureLocation" runat="server" CssClass="form-control" placeholder="Departure Location"></asp:TextBox>
						</div>
						<div class="form-group">
							<asp:TextBox ID="arrivalLocation" runat="server" CssClass="form-control" placeholder="Arrival Location"></asp:TextBox>
						</div>
						<div class="form-group">
							<asp:TextBox ID="txtDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
						</div>
						<div class="form-group">
							<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="tg-btn" OnClick="btnSearch_Click" />
						</div>

						<br />
						<br />
						<br />

						<!-- Results Table -->
						<asp:GridView ID="gvBuses" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" OnRowCommand="gvBuses_RowCommand">
							<Columns>
								<asp:BoundField DataField="BusID" HeaderText="Bus ID" />
								<asp:BoundField DataField="BusName" HeaderText="Bus Name" />
								<asp:BoundField DataField="DepartureLocation" HeaderText="DepartureLocation" />
								<asp:BoundField DataField="ArrivalLocation" HeaderText="ArrivalLocation" />
								<asp:BoundField DataField="DepartureTime" HeaderText="DepartureTime" DataFormatString="{0:dd/MM/yyyy hh:mm}" />
								<asp:BoundField DataField="SeatsAvailable" HeaderText="SeatsAvailable" />
								<asp:TemplateField>
									<ItemTemplate>
										<asp:Button ID="btnBook" runat="server" Text="Book" CommandName="Book" CommandArgument='<%# Eval("BusID") %>' CssClass="btn btn-primary" />
									</ItemTemplate>
								</asp:TemplateField>
							</Columns>
						</asp:GridView>
					
						<!-- No Results Message -->
						<asp:Label ID="lblNoResults" runat="server" CssClass="info-message" Visible="false" Text="No buses found matching your search criteria."></asp:Label>
						<br />
						<br />
					</fieldset>
				</form>
			</div>
		</div>
	</div>
</asp:Content>
