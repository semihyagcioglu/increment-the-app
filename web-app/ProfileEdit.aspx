﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ProfileEdit.aspx.cs" Inherits="increment_the_app.Profile" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">

    <script src="js/jquery-1.10.2.min.js"></script>
    <script src="js/updateProfile.js"></script>

    <style type="text/css">

        .thumbnail {
            width: 200px;
            height: 200px;
            border-radius: 115px;
            border: 5px solid whitesmoke;
            box-shadow: 0px 2px 2px rgba(155,155,155,0.5);
        }

        .thumbnail {
            position: relative;
            width: 200px;
            margin-left: auto;
            margin-right: auto;
        }

    </style>

</asp:Content>

<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="ProfileContent">
        <div class="ProfileHeader">

            <div class="ProfileName" style="margin-left:200px;">
                <div class="row">
                    <div class="col-sm-6 col-md-4">
                        <div class="thumbnail">
                            <img src="img/poster.png" height="200" width="300" alt="">
                            <div class="caption">
                            </div>                         
                             <button id="btn" class="btn btn-warning" style="margin-left:32px; margin-top:10px; width: 120px; height: 30px; text-align: center;">Resmi Değiştir</button>
                        </div>
                    </div>
                </div>
            </div>
            <form class="navbar-form navbar-left" role="search">
                <div>
                   
                    <br />
                    <br />
                </div>
                <div class="form-group">
                    <input type="text" id="InputName" runat="server" class="form-control" placeholder="Ad" style="height: 30px;"><br />
                    <input type="text" id="InputSurname" runat="server" class="form-control" placeholder="Soyad" style="height: 30px;"><br />
                    <input type="text" id="InputEmail" runat="server" class="form-control" placeholder="Email" style="height: 30px;"><br />
                    <input type="text" id="InputPhone" runat="server" class="form-control" placeholder="Telefon" style="height: 30px;"><br />
                    <input type="text" id="InputAdress" runat="server" class="form-control" placeholder="Adres" style="height: 30px;"><br />
                    <input type="text" id="InputBirtDay" runat="server" class="form-control" placeholder="Doğum Tarihi" style="height: 30px;"><br />
                    <div>
                       <label style="float:left; font-size:14px;">Cinsiyet</label>
                        <div class="col-lg-2" style="float: left;">
                            <div class="input-group" style="width:5px;">
                                <span class="input-group-addon" style="width:5px;">
                                    <input type="radio" id="Male" style="height:15px;" runat="server">
                                </span>
                                <label class="form-control" style="width: 62px;">Erkek</label>
                            </div>
                        </div>

                        <div class="col-lg-2">
                            <div class="input-group">
                                <span class="input-group-addon">
                                    <input type="radio" id="Female" runat="server">
                                </span>
                                <label class="form-control" style="width: 62px;">Kadın</label>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
             
                    <textarea id="InputAbout" runat="server" class="form-control" style="height: 100px;" placeholder="Hakkımda"></textarea><br />
                </div>
                <button type="button" class="btn btn-primary" id="btnUpdateProfile">Değişiklikleri Kaydet</button><br />
                <br />
            </form>
        </div>
        <p>&nbsp;</p>
    </div>
</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>