<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchTask.aspx.cs" Inherits="increment_the_app.WebForm2" %>
<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">

    <div style="width:750px; height:50px;"><div style="width:500px; float:left;"><input type="text" class="form-control" id="InputSearch" runat="server" style="width:500px; margin-right:inherit;" placeholder="Aramak istenen iş.."></div>
        <div id="btnSearch" class="btn btn-lg btn-success btn-block" style="width:70px;height:33px; float:left;margin-left:10px; font-size:12px;">Arama</div>
</div>
</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>
