<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="increment_the_app.Home" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {

            $("#btnIsEkle").click(function (e) {
                window.location.href = "PostTask.aspx";
            });
        });
    </script>

    <div class="main">

        <div class="solMenu .col-md-3">
            <button type="button" style="width: 120px; margin-bottom: 5px;" id="btnPostedTask" class="btn btn-success">Gönderilen İşler</button>
            <button type="button" style="width: 120px; margin-bottom: 5px;" id="btnTaskRabbits" class="btn btn-success">İşlerim</button>
            <button type="button" style="width: 120px; margin-bottom: 5px;" id="btnTransaction" class="btn btn-success">Hareketlerim</button>
            <button type="button" style="width: 120px;" id="btnGuideline" class="btn btn-success">Kurallarımız</button>
        </div>
        <div class=".col-md-6">
            <div>
                <h6>İşleri hızlandırmak için iş eklemeye ne dersiniz? </h6>
            </div>
            <div>
                <button type="button" style="width: 120px;" id="btnIsEkle" class="btn btn-primary">Yeni İş Ekle</button>
            </div>
        </div>

    </div>



    <div class="row marketing">
    </div>
</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>
