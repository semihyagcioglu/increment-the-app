<%@ Page Language="C#" MasterPageFile="~/NonSessionSite.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="increment_the_app.ResetPassword" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">


</asp:Content>


<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">
    <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>

    <asp:TextBox ID="txtEmail" runat="server" Width="347px"></asp:TextBox>
    <br />
    <br />
    <div id="btnGonder" class="btn btn-success"></div>

</asp:Content>

<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">


</asp:Content>
