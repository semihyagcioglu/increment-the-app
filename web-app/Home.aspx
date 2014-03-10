<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="increment_the_app.Home" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">

</asp:Content>
<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">
    

    <div class="main">

        <div class="solMenu">
            <button type="button" style="width:100px;" id="btnPostedTask" class="btn btn-success">Gönderilen İşler</button>
            <button type="button" style="width:100px;" id="btnTaskRabbits" class="btn btn-success">İşlerim</button>
            <button type="button" style="width:100px;" id="btnTransaction" class="btn btn-success">Hareketlerim</button>

            </div>

                
       


                </div>
            

        </div>
 <div class="dropdown">
                <div class="baslik"><span class="btn btn-primary"><a href="PostTask.aspx"><span style="color:#fff;" >Yeni İş İlanı Ver</span></a></span></div>
                <div class="ilanicerik">

    </div>


    <div class="row marketing">
    </div>

</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>
