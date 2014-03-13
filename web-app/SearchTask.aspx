<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchTask.aspx.cs" Inherits="increment_the_app.WebForm2" %>
<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">
    <style type="text/css">
        #result-avatar {
        float:left;
        }
          #title {
        float:left;
        }
        .temizle {
        clear:both;
        }

    </style>
    <script src="js/searchTasks.js"></script>
</asp:Content>
<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">

  <br />
    <div>
    <form class="navbar-form navbar-left" role="search">
  <div class="form-group">
    <input type="text" class="form-control" runat="server" id="InputSearchTask" style="width:500px; margin-left:40px; margin-right:10px; float:left;" placeholder="Aranacak anahtar kelimeyi giriniz...">
      <button type="button" style="width:100px;" id="btnSearchTask" class="btn btn-success">Ara</button>
  </div>  
</form>
</div>
    <table id="searchResult">

    </table>
    <br /><br />
    <div class="temizle"></div>
    <asp:Panel ID="pnlSearchTask" runat="server"></asp:Panel>
</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>
