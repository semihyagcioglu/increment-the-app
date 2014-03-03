<%@ Page Title="" Language="C#" MasterPageFile="~/NonSessionSite.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="increment_the_app.WebForm3" %>
<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">
    
    <form class="navbar-form navbar-left" role="search" style="margin-top:30px;">
        <div class="panel-heading">
                    <h3 class="panel-title">Şifre Değiştir</h3>
                </div>
                <div class="form-group">
                    <input type="password" id="OldPassword" runat="server" class="form-control" placeholder="Eski Şifre" style="height:30px; width:400px;"><br />
                    <input type="password" id="NewPassword" runat="server" class="form-control" placeholder="Yeni Şifre" style="height:30px;width:400px;"><br />
                    <input type="password" id="NewPasswordAgain" runat="server" class="form-control" placeholder="Yeni Şifre Tekrar" style="height:30px;width:400px;"><br />
                     <button type="submit" id="btnChangePassword" class="btn btn-default">Değiştir</button><br /><br />
                    <br /></div></form>

</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>
