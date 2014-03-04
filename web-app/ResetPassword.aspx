<%@ Page Language="C#" MasterPageFile="~/NonSessionSite.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="increment_the_app.ResetPassword" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">


</asp:Content>


<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">
    <br />
    <div style="width:700px; height:150px; overflow:hidden;">
   
    &nbsp;<input type="text" id="Email" runat="server" class="form-control" placeholder="E-Mail" style="height:30px; width:400px; float:left;">
    

    <div id="btnResetPassword" class="btn btn-lg btn-success btn-block" style="width:120px;">Gönderr</div>
    
    </div>
</asp:Content>

<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">


</asp:Content>
