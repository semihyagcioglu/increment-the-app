<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PostTask.aspx.cs" Inherits="increment_the_app.PostTask" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">

    <script src="js/postTask.js"></script>

    <meta charset="utf-8">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">

    <script>
        $(function () {
            $("#datepicker").datepicker({ dateFormat: "yy-mm-dd" });
        });
    </script>

</asp:Content>
<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">

    <h4 class="ch4">
        <img src="img/search.png" alt="Pulpit rock" width="64" height="64">Lütfen Gerekli İş Bilgileri Girin</h4>
    <hr width="”100%”" color="”#0000F8”" size="5">
    <div class="form-group">
        <div id="warningMessage" class="alert alert-danger" style="display: none;"></div>
    </div>
    <form role="form">
        <div class="form-group">
            <label class="text-primary">
                <img src="img/title.png" alt="Pulpit rock" width="32" height="32">Yapılmak İstenen İş</label>
            <input type="text" class="form-control" id="InputTitle" placeholder="Yapılmak istenen iş...">
        </div>
        <div class="form-group">
            <label class="text-primary">
                <img src="img/detail.png" alt="Pulpit rock" width="32" height="32">İşin Detayı</label>
            <textarea class="form-control" id="InputTitleDetail" placeholder="Lütfen yapılacak işin detaylarını girin..." rows="3"></textarea>
        </div>
    </form>
    <br />
    <div class="btn-group dropup">
        <form role="form">
            <div class="form-group">
                <label class="text-primary">
                    <img src="img/location.png" alt="Pulpit rock" width="32" height="32">Nerede yapılacak ?</label>
                <input type="text" class="form-control" id="Inputlocation" placeholder="Nerede yapılsın...">
            </div>
        </form>
        <label class="text-primary">
            <img src="img/date.png" alt="Pulpit rock" width="32" height="32">İşin Teslim Tarihi</label>
        <div class="panel-body">
            <div class="form-group">
                <input id="datepicker" type="text" class="form-control" placeholder="Tarih Seçin" required />
            </div>

        </div>

        <form role="form">
            <div class="form-group">
                <label class="text-primary">
                    <img src="img/money.png" alt="Pulpit rock" width="32" height="32">Ücret ?</label>
                <div class="input-group">
                    <input type="text" class="form-control" id="InputMoney" placeholder="Ne kadar ödemeyi düşünüyosun..." />
                    <span class="input-group-addon">.00 TL</span>
                </div>
            </div>
        </form>
        <br />

        <div id="btnTaskSave" class="btn btn-lg btn-success btn-block">Kaydet ve Teklif Al</div>
    </div>
</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>
