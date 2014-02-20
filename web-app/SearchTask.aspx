<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchTask.aspx.cs" Inherits="increment_the_app.WebForm2" %>
<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">
    <asp:TextBox ID="txtSearch" runat="server" Width="355px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnSearch" runat="server" Text="Arama Yap" OnClick="btnSearch_Click" />
&nbsp;
</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>


