﻿<%@ Page Language="C#" MasterPageFile="~/NonSessionSite.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="increment_the_app.ResetPassword" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">


</asp:Content>


<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">
    <br />

     <div class="form-group">
        <div id="warningMessage" class="alert alert-danger" style="display: none;"></div>
    </div>

    <form class="navbar-form navbar-left">
  <div class="form-group">
    <input type="text" class="form-control" runat="server" id="Email" style="width:500px; margin-right:10px; float:left;" placeholder="Lütfen şifre sıfırlama için email adresinizi giriniz">
      <button type="button" style="width:100px;" id="btnResetPassword" class="btn btn-success">Gönder</button>
  </div>
</asp:Content>

<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">


</asp:Content>
