<%@ Page Language="C#" MasterPageFile="~/NonSessionSite.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="increment_the_app.ResetPassword" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">
    <script src="js/resetPassword.js"></script>

</asp:Content>


<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">
    <br />

    <form class="navbar-form navbar-left">
  <div class="form-group">
    <input type="text" class="form-control" runat="server" id="Email" style="width:500px; margin-right:10px; float:left;" placeholder="Lütfen şifre sıfırlama için email adresinizi giriniz">
      <button type="button" style="width:100px;" id="btnResetPassword" class="btn btn-success">Gönder</button>
  </div>

        

         <div class="form-group">
        <div id="successMessage" class="alert alert-success" style="display: none; width:500px; text-align:center;"></div>
    </div>

</asp:Content>

<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">


</asp:Content>
