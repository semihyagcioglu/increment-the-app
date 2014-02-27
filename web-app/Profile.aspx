﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Profile.aspx.cs" Inherits="increment_the_app.Profile" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">


</asp:Content>


<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="ProfileContent">
        <div class="ProfileHeader">

            <div class="ProfileName">
                <div class="row">
  <div class="col-sm-6 col-md-4">
    <div class="thumbnail">
      <img src="img/ornekprofile.png" height="200" width="300" alt="">
      <div class="caption">
        <p><a href="#" class="btn btn-primary" id="ChangeImage" role="button">Değiştir</a></p>
      </div>
    </div>
  </div>
</div>
                <div class="progress" style="width:70%;"> 
  <div class="progress-bar" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width: 40%;">
   Profiliniz %40 dolu...
  </div>
</div>
                    
                    <form class="navbar-form navbar-left" role="search">
                <div class="form-group">
                    <input type="text" id="InputName" runat="server" class="form-control" placeholder="Ad" size="30"><br />
                    <input type="text" id="InputSurname" runat="server" class="form-control" placeholder="Soyad"><br />
                    <input type="text" id="InputEmail" runat="server" class="form-control" placeholder="Email"><br />
                    <input type="text" id="InputPhone" runat="server" class="form-control" placeholder="Telefon"><br />
                    <input type="text" id="InputAdress" runat="server" class="form-control" placeholder="Adres"><br />
                    <input type="text" id="InputBirtDay" runat="server" class="form-control" placeholder="Doğum Tarihi"><br />
                    <div class="input-group">
      <span class="input-group-addon">
        <input type="checkbox">
      </span>
      <input type="text" class="form-control">
    </div><!-- /input-group -->
                    <textarea id="InputAbout" class="form-control" style=" height:100px;" placeholder="Hakkımda"></textarea><br />
                    </div>
                <button type="submit" id="btnUpdateProfile" class="btn btn-default">Değişiklikleri Kaydet</button><br /><br />
                </form>         

            </div>

        </div>

    </div>
</asp:Content>

<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">


</asp:Content>