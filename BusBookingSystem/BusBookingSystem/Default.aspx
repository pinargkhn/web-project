<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BusBookingSystem._Default" %>
<%@ Register Src="~/UserControls/MainSlider.ascx" TagPrefix="uc" TagName="MainSlider" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
			<uc:MainSlider ID="MainSlider" runat="server" />
			<section class="tg-parallax" data-appear-top-offset="600" data-parallax="scroll" data-image-src="images/parallax/bgparallax-03.jpg">
				<div class="tg-sectionspace tg-haslayout">
					<div class="container">
						<div class="row">
							<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
								<div class="tg-ourpartners">
									<div class="tg-pattern"><img src="images/patternw.png" alt="image destination"></div>
									<h2>Developed @ DOU</h2>
								</div>
							</div>
						</div>
					</div>
				</div>
			</section>
</asp:Content>
