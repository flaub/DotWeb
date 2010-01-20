<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
    <%= ViewData["Title"] %>
</asp:Content>

<asp:Content ContentPlaceHolderID="Header" runat="server">
	<link type="text/css" rel="Stylesheet" href="/Content/log.css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
	<h2><%= ViewData["Title"] %></h2>
	<div id="sandbox"></div>
	<%= Html.ClientCode((string)ViewData["TypeName"], (string)ViewData["Mode"])%>
</asp:Content>
