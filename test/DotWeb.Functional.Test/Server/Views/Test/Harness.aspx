<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <%= ViewData["Title"] %>
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
	<h2><%= ViewData["Title"] %></h2>
	<%= Html.ClientCode((string)ViewData["TypeName"], (string)ViewData["Mode"])%>
</asp:Content>
