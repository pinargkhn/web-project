<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainSlider.ascx.cs" Inherits="BusBookingSystem.UserControls.MainSlider" %>

<!--************************************
				Home Slider Start
*************************************-->
		<div class="tg-bannerholder">
			<div class="tg-slidercontent" style="background-image: url('images/slider/SliderBackground.png'); background-size: cover";>
				<div class="container">
					<div class="row">
						<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
							<h1>Find the best route!</h1>
							<h2>People don’t take trips, trips take People</h2>
							<form class="tg-formtheme tg-formtrip" runat="server">
								<fieldset>
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
								</fieldset>
							</form>
						</div>
					</div>
				</div>
			</div>
			<div id="tg-homeslider" class="tg-homeslider owl-carousel tg-haslayout">
				<figure class="item" data-vide-bg="poster: images/slider/img-01.jpg" data-vide-options="position: 0% 50%"></figure>
				<figure class="item" data-vide-bg="poster: images/slider/img-02.jpg" data-vide-options="position: 0% 50%"></figure>
				<figure class="item" data-vide-bg="poster: images/slider/img-03.jpg" data-vide-options="position: 0% 50%"></figure>
			</div>
		</div>
		<!--************************************
				Home Slider End
		*************************************-->