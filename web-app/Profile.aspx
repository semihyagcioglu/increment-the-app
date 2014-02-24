<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Profile.aspx.cs" Inherits="increment_the_app.Profile" %>

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
        <p><a href="#" class="btn btn-primary" role="button">Değiştir</a></p>
      </div>
    </div>
  </div>
</div>
                    <form class="navbar-form navbar-left" role="search">
                <div class="form-group">
                    <input type="text" class="form-control" placeholder="Ad Soyad"><br />
                    <input type="text" class="form-control" placeholder="Mail Adresi"><br />
                    <input type="text" class="form-control" placeholder="Telefon"><br />
                    <input type="text" class="form-control" placeholder="Adres"><br />
                    <input type="text" class="form-control" style=" height:100px;" placeholder="Hakkımda"><br />
                    </div>
                <button type="submit" class="btn btn-default">Değişiklikleri Kaydet</button><br /><br />
                </form>         

            </div>

        </div>

    </div>
</asp:Content>

<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">


</asp:Content>