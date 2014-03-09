<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ProfileEdit.aspx.cs" Inherits="increment_the_app.ProfileEdit" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">

</asp:Content>

<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">
    <div class=" form-group" style="align-content:center;">

  <div class="mt-profile-name">

    <div class="mt-profile-title">

      <hr class="mt-profile-separator">
      <h1 class="title" >ALi ÖZTÜRK</h1>

        <a href="/account" class="mt-profile-title-action">Edit Account Details</a>

    </div>

    <div class="mt-profile-subtitles">
      
    </div>

  </div>

  <div class="mt-profile-hero-avatar">
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
  <div class="mt-profile-section mt-profile-actions">
    <a href="/profile/edit" class="button large">Edit your profile</a>
</div>
</div>
</asp:Content>

<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">

</asp:Content>