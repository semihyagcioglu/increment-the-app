<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ProfileEdit.aspx.cs" Inherits="increment_the_app.Profile" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">

    <script src="js/jquery-1.10.2.min.js"></script>
    <script src="js/updateProfile.js"></script>

    <script type="text/javascript">

        $(document).ready(function () {

            $("#bodyContent_btnChangePicture").click(function (e) {
                window.location.href = "ProfilePicture.aspx";
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
                <div>
                    <div class="mt-profile-hero-avatar" style="margin: 0 auto; width: 200px;">
                        <img alt="" id="imgProfile" class="mt-profile-hero-avatar" src="" runat="server">
                    </div>

                    <button id="btnChangePicture" runat="server" type="button" class="btn btn-warning" style="margin-left: 0 auto; margin-top: 10px; width: 120px; height: 30px; text-align: center;">Resmi Değiştir</button>

                    <br />
                    <br />
                </div>

                <form class="navbar-form navbar-left" role="search">

                    <div class="form-group">
                        <input type="text" id="InputName" runat="server" class="form-control" placeholder="Ad" style="height: 30px; width: 500px; margin: 0 auto;"><br />
                        <input type="text" id="InputSurname" runat="server" class="form-control" placeholder="Soyad" style="height: 30px; width: 500px; margin: 0 auto;"><br />
                        <input type="text" id="InputEmail" runat="server" class="form-control" placeholder="Email" style="height: 30px; width: 500px; margin: 0 auto;"><br />
                        <input type="text" id="InputPhone" runat="server" class="form-control" placeholder="Telefon" style="height: 30px; width: 500px; margin: 0 auto;"><br />
                        <input type="text" id="InputAdress" runat="server" class="form-control" placeholder="Adres" style="height: 30px; width: 500px; margin: 0 auto;"><br />
                        <input type="text" id="InputBirtDay" runat="server" class="form-control" placeholder="Doğum Tarihi" style="height: 30px; width: 500px; margin: 0 auto;"><br />
                        <div style="width: 500px; margin: 0 auto;">
                            <label style="float: left; font-size: 14px; margin-top: 5px; color: #9C9C9C;">Cinsiyet :</label>
                            <div class="col-lg-2" style="float: left;">
                                <div class="input-group" style="height: 30px;">
                                    <span class="input-group-addon" style="width: 5px;">
                                        <input type="radio" id="Male" style="height: 15px;" runat="server">
                                    </span>
                                    <label class="form-control" style="height: 31px;">Erkek</label>
                                </div>
                            </div>

                            <div class="col-lg-2" style="float: left; margin-left: 40px;">
                                <div class="input-group">
                                    <span class="input-group-addon" style="height: 30px;">
                                        <input type="radio" id="Female" runat="server">
                                    </span>
                                    <label class="form-control" style="height: 31px;">Kadın</label>
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <br />

                        <textarea id="InputAbout" runat="server" class="form-control" style="height: 100px; width: 650px; margin: 0 auto;" placeholder="Hakkımda"></textarea><br />
                    </div>
            </div>
            <div style="width: 210px; margin: 0 auto;">
                <button type="button" class="btn btn-primary" id="btnUpdateProfile">Değişiklikleri Kaydet</button>
            </div>
            <br />
            </form>
        </div>
        <p>&nbsp;</p>
    </div>
</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>
