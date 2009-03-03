<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	CodeBehind="ExtJs.aspx.cs" Inherits="H8.MVC.Views.Home.ExtJs" %>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript" src="<%= ResolveUrl("~/js/ExtJs/ext-base.js") %>"></script>
	<script type="text/javascript" src="<%= ResolveUrl("~/js/ExtJs/ext-all-debug.js") %>"></script>
	<script type="text/javascript" src="<%= ResolveUrl("~/js/ExtJs/ExtSharpAdapter.js") %>"></script>

	<h2>ExtJs Sample</h2>
	<div id="grid"></div>
	<web:ClientCode ID="clientCode" runat="server" Source="DotWeb.Sample.Script.ExtScript, DotWeb.Sample.Script" />
</asp:Content>
