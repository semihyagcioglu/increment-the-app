<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ProfileEdit.aspx.cs" Inherits="increment_the_app.ProfileEdit" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {

            $("#EditProfile").click(function (e) {
                window.location.href = "ProfileDetails.aspx";
            });
        });

    </script>

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
  <img alt="ali ö." class="mt-profile-hero-avatar" src="https://d27r861tkvec9a.cloudfront.net/core/assets/default_avatars/poster_small.png">
</div>

  <div class="mt-profile-section mt-profile-lists row">
      
      <div class="mt-profile-accounts column four">
        <div class="mt-profile-list-inner">

        </div>
      </div>
    <p>
    </p>
  </div>
  <div class="mt-profile-section mt-profile-actions" style="width:120px; margin:0 auto;">
   <button type="button" class="btn btn-warning"  id="EditProfile" >Profil Düzenle</button><br /><br />
</div>
</div>
</asp:Content>

<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">

</asp:Content>