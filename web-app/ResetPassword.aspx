<%@ Page Language="C#" MasterPageFile="~/NonSessionSite.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="increment_the_app.ResetPassword" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">


</asp:Content>


<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">
    <br />
    <asp:Label ID="lblEmail" runat="server" Text="Email :" Font-Bold="True"></asp:Label>

    &nbsp;<asp:TextBox ID="txtEmail" runat="server" Width="355px" Height="24px"></asp:TextBox>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnSendPassword" runat="server" CssClass="btn" Height="32px" OnClick="btnSendPassword_Click" Text="Gönder" Width="81px" />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    
</asp:Content>

<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">


</asp:Content>
