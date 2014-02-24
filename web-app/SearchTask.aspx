<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchTask.aspx.cs" Inherits="increment_the_app.WebForm2" %>
<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">
    <script src="js/searchTasks.js"></script>
</asp:Content>
<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">

   <%-- <div style="width:750px; height:50px;"><div style="width:500px; float:left;"><input type="text" class="form-control" id="InputSearch" runat="server" style="width:500px; margin-right:inherit;" placeholder="Aramak istenen iş.."></div>
        <div id="btnSearch" class="btn btn-lg btn-success btn-block" style="width:70px;height:33px; float:left;margin-left:10px; font-size:12px;">Arama</div>--%>
   <br />
    <div>
    <form class="navbar-form navbar-left" role="search">
  <div class="form-group">
    <input type="text" class="form-control" id="InputSearchTask" style="width:500px; margin-right:10px; float:left;" placeholder="Aranacak anahtar kelimeyi giriniz...">
      <button type="button" style="width:100px;" id="btnSearchTask" class="btn btn-success">Ara</button>
  </div>  
</form>

</div>

</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>
