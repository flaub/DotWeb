<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	CodeBehind="Index.aspx.cs" Inherits="H8.MVC.Views.Home.Index" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		<%= Html.Encode(ViewData["Message"]) %></h2>
	<p>
		To learn more about ASP.NET MVC visit <a href="http://asp.net/mvc" title="ASP.NET MVC Website">
			http://asp.net/mvc</a>.
	</p>

	<div id="grid"></div>
	
	<h8:ClientCode runat="server" Source="~/Views/Home/IndexScript.cs" />
	
</asp:Content>
