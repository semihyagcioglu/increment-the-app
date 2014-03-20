<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="increment_the_app.Home" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">
    <script src="js/myTasks.js"></script>
</asp:Content>
<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {

            $("#btnIsEkle").click(function (e) {
                window.location.href = "PostTask.aspx";
            });

            $("#btnOffer").click(function (e) {
                window.location.href = "Offer.aspx";
            });
        });
    </script>

    <div class="main">

        <div class="solMenu .col-md-3">
            <button type="button" style="width: 120px; margin-bottom: 5px;margin-left:10px;" id="btnPostedTask" class="btn btn-default">Gönderilen İşler</button>
            <button type="button" style="width: 120px; margin-bottom: 5px; margin-left:10px;" id="btnTaskRabbits" class="btn btn-default">İşlerim</button>
            <button type="button" style="width: 120px; margin-bottom: 5px;margin-left:10px;" id="btnTransaction" class="btn btn-default">Hareketlerim</button>
            <button type="button" style="width: 120px; margin-bottom: 5px;margin-left:10px;" id="btnOffer" class="btn btn-default">Tekliflerim</button>
            <button type="button" style="width: 120px;margin-left:10px;" id="btnGuideline" class="btn btn-default">Yasal Uyarı!</button>
        </div>
        <div class=".col-md-6">
            <div>
                <h6 style="font-size: large; font-weight: bold; color: #000000"> İŞLER </h6>
                <h6 style="font-size: larger; font-weight: bold">İşleri hızlandırmak için iş eklemeye ne dersiniz? </h6>
            </div>
            <div>
                <button type="button" style="width: 120px;" id="btnIsEkle" class="btn btn-warning">Yeni İş Ekle</button>
            </div>
            <div>
              <%--  <br />
               --%>
                <%--<label class="text-primary" style="text-align:center; font-size:16px; margin:0 auto; width:100px;">İşlerim</label>--%>
                 <table id="myTaskResult">

                 </table>
                <br /><br />    
            </div>
           
        </div>

    </div>

    <div class="row marketing">
    </div>
</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>
