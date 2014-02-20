<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchTask.aspx.cs" Inherits="increment_the_app.WebForm2" %>
<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">
    <div><input type="text" class="form-control" id="InputSearch" runat="server" style="width:600px; float:left;" placeholder="Aramak istenen iş..">
        <div id="btnSearch" class="btn btn-lg btn-success btn-block" style="width:70px; float:left; height:33px; margin-left:10px; font-size:12px;">Arama</div>

   
&nbsp;&nbsp;&nbsp;

        </div>
&nbsp;
</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>


