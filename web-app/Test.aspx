<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="increment_the_app.Test" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">

    <div class="row">
		<div class="col-md-4 col-md-offset-4">
    		<asp:GridView ID="gvUsers" runat="server"></asp:GridView>
		</div>
	</div>

</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>
          
       
