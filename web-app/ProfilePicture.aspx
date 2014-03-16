<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePicture.aspx.cs" MasterPageFile="~/Site.Master" Inherits="increment_the_app.ProfilePicture" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">

    <script src="js/jquery-1.10.2.min.js"></script>
    <script src="js/updateProfile.js"></script>

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

    <div style="width: 700px;">

        <div class="mt-profile-name" style="width: 300px; margin: 0 auto;">

            <div class="mt-profile-title">

                <h1 class="title" id="hdName" style="background-position: center; text-align: center; font-size: 24px;" runat="server"></h1>

            </div>

            <div class="mt-profile-subtitles">
            </div>

        </div>

        <div class="mt-profile-section mt-profile-lists row" style="margin-left: 5px; margin-left: 5px; width: 700px; margin: 0 auto; text-align: center;">
            <div class="caption">
                <div class="mt-profile-hero-avatar" style="margin: 0 auto; width: 200px;">
                    <img alt="" id="imgProfile" class="mt-profile-hero-avatar" src="" runat="server">
                </div>
                <div style="width: 210px; margin: 0 auto;">
                    <br />
                    <asp:FileUpload ID="FileUpload1" Width="300px" runat="server" />
                    <br />

                    <asp:Button ID="btnUpdatePicture" class="btn btn-primary" runat="server" Text="Değişiklikleri Kaydet" OnClick="btnUpdatePicture_Click" />
                    <br />
                    <br />
                </div>

            </div>

        </div>
    </div>
    </div>
            </div>
            <form class="navbar-form navbar-left" role="search">
                <div>

                    <br />
                    <br />
                </div>
                <br />
            </form>

    <p>&nbsp;</p>

</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>
