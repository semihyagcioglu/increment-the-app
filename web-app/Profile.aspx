<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Profile.aspx.cs" Inherits="increment_the_app.Profile" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">


</asp:Content>


<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="ProfileContent">
        <div class="ProfileHeader">

            <div class="ProfileName">
                    <form class="navbar-form navbar-left" role="search">
                <div class="form-group">
                    <input type="text" class="form-control" placeholder="Ad"><br />
                    <input type="text" class="form-control" placeholder="Soyad"><br />
                    <input type="text" class="form-control" placeholder="Mail Adresi"><br />
                    <input type="text" class="form-control" placeholder="Telefon"><br />
                    <input type="text" class="form-control" placeholder="Şifre"><br />
                    <input type="text" class="form-control" placeholder="Şifre Tekrar">
                    </div>
                <button type="submit" class="btn btn-default">Değişiklikleri Kaydet</button>
                </form>         

            </div>

        </div>

    </div>
</asp:Content>

<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">


</asp:Content>