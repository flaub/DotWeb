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
	
	<h8:ClientCode ID="clientCode" runat="server"/>

	<script type="text/javascript">
		function Tuple(config) {
			this.id = config.id;
			this.value = config.value;
		};
		Tuple.prototype.getId = function() { return this.id; };
		Tuple.prototype.setId = function(id) { this.id = id; };
		Tuple.prototype.getValue = function() { return this.value; };
		Tuple.prototype.setValue = function(value) { this.value = value; };
		Tuple.prototype.fireEvent = function() { console.log('firing'); this.handler(this, this.id); }
		Tuple.StaticMethod = function(x, y) { console.log(x * y); };
		Tuple.Factory = function() {
			return new Tuple({
				id: 59,
				value: 'hi'
			});
		};
		
//		var t = new Tuple({id: 1, value: 'value'});
//		console.log(t.getId());
		
	</script>
</asp:Content>
