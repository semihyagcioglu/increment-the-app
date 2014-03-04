<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Support.aspx.cs" Inherits="increment_the_app.WebForm4" %>
<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">

    <input type="text" id="SupportEmail" runat="server" class="form-control" placeholder="E-Mail" style="height:30px;"><br />
    <textarea id="SupportInputAbout" class="form-control" style=" height:300px;" placeholder="Soru ve yorumlarınız ile teknik destek talepleriniz için bizimle iletişime geçiniz."></textarea><br />
</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>
