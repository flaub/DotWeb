<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	CodeBehind="Simple.aspx.cs" Inherits="H8.MVC.Views.Home.Simple" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		.WEB Simple Sample</h2>
	<p>
		To learn more about the .Web Toolkit visit <a href="http://dotweb.com" title=".WEB Toolkit Website">
			http://dotweb.com</a>.
	</p>
	
	<script type="text/javascript" src="../../js/Tuple.js" ></script>

	<web:ClientCode ID="clientCode" runat="server" Source="DotWeb.Sample.Script.SimpleScript, DotWeb.Sample.Script"/>
</asp:Content>
