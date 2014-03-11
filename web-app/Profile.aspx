<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Profile.aspx.cs" Inherits="increment_the_app.ProfileEdit" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {

            $("#EditProfile").click(function (e) {
                window.location.href = "ProfileEdit.aspx";
            });
        });
        
        </script>

    <style type="text/css">

        .mt-profile-hero-avatar img {
            width: 200px;
            height: 200px;
            border-radius: 115px;
            border: 5px solid whitesmoke;
            box-shadow: 0px 2px 2px rgba(155,155,155,0.5);
        }
        .mt-profile-hero-avatar {
            position: relative;
            width: 200px;
            margin-left: auto;
            margin-right: auto;
        }

    </style>

</asp:Content>

<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">

    <hr class="mt-profile-separator">

    <div style="width:700px; " >

  <div class="mt-profile-name" style="width:300px; margin:0 auto;">

    <div class="mt-profile-title">

      
      <h1 class="title" style="background-position:center; text-align:center; font-size:24px;" >ALi ÖZTÜRK</h1>

    </div>

    <div class="mt-profile-subtitles">
      
    </div>

  </div>

  <div class="mt-profile-hero-avatar" style="margin:0 auto; width:200px;">
  <img alt="ali ö." class="mt-profile-hero-avatar" src="/img/poster_small.png">
</div>

  <div class="mt-profile-section mt-profile-lists row">
      
      <div class="mt-profile-accounts column four">
        <div class="mt-profile-list-inner">
        </div>
      </div>
    <p>
        <br />
       
         <div class="form-group">
        <label class="text-primary" style="color:black;">Ad Soyad:</label>
             <label class="text-primary" id="lblName" runat="server" > </label>
             </div>
        <div class="form-group">
        <label class="text-primary" style="color:black;">Email:</label>
            <label class="text-primary" id="lblEmail" runat="server" > </label>
            </div>
          <div class="form-group">
        <label class="text-primary" style="color:black;">Doğum Tarihi:</label>
                    <label class="text-primary" id="lblBirthDate" runat="server" > </label>
                    </div>
            <div class="form-group">
        <label class="text-primary" style="color:black;">Adres:</label>
                <label class="text-primary" id="lblAddress" runat="server" > </label>
                </div>
                <div class="form-group">
        <label class="text-primary" style="color:black;">Telefon:</label>
                    <label class="text-primary" id="lblPhone" runat="server" > </label>
                    </div>
          <div class="form-group">
        <label class="text-primary" style="color:black;">Hakkımda:</label>
                    <label class="text-primary" id="lblAbout" runat="server" > </label>
                    </div>
                    

    </p>
  </div>
  <div class="mt-profile-section mt-profile-actions" style="width:120px; margin:0 auto;">
   <button type="button" class="btn btn-warning"  id="EditProfile" >Profil Düzenle</button><br /><br />
</div>
</div>
</asp:Content>

<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">

</asp:Content>