<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="increment_the_app.Home" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">

</asp:Content>
<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">
    

    <div class="main">

        <div class="solMenu">


            <div class="dropdown">
                <div class="baslik"><span class="label label-success"><a href="PostTask.aspx">Yeni İş İlanı Ver !!!</a></span></div>
                <div class="alt-baslik"><span class="label label-success">En Son Eklenenler</span></div>
                <div class="ilanicerik">


                    <ul class="onilan">

                        <li>İlan1</li>
                        <li>İlan2</li>
                        <li>İlan3</li>
                        <li>İlan4</li>
                        <li>İlan5</li>


                    </ul>


                </div>

                <div class="solalt">

                    <div class="baslik"><span class="label label-success">Çalışan</span></div>
                    <div class="alt-baslik"><span class="label label-success">En Son Eklenenler</span></div>
                    <ul class="onilan">

                        <li>İlan1</li>
                        <li>İlan2</li>
                        <li>İlan3</li>
                        <li>İlan4</li>
                        <li>İlan5</li>
                    
                    </ul>
                </div>

            </div>

        </div>

        <div class="ortamenu">

            <div class="panel panel-default">
                <div class="panel-heading">Ayın En Başarılı Çalışanı</div>
                <div class="panel-body">
                    Ahmet Mehmet
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Ayın En Hızlı Çalışanı</h3>
                </div>
                <div class="panel-body">
                    Ali Veli
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">Aktif Olan İşler</div>
                <div class="panel-body">
                    <asp:GridView ID="gvOnlineTask" runat="server" Width="471px"></asp:GridView>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Büyük İlanlar</h3>
                </div>
                <div class="panel-body">
                    <img src="img/slider-img-2.jpg" width="470" />
                </div>
            </div>
        </div>


    </div>


    <div class="row marketing">
    </div>

</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>
