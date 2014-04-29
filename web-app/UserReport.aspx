<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserReport.aspx.cs" Inherits="increment_the_app.UserReport" %>


<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">
     <script src="js/userReport.js"></script>
</asp:Content>
<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">
    <%--<div class="table-responsive">--%>
    <table id="myUsers">
        <%--<thead>
            <tr>
                <th>Adı</th>
                <th>Soyadı</th>
                <th>E-Mail</th>
                <th>Doğum Tarihi</th>
                <th>Cinsiyet</th>

            </tr>
        </thead>--%>
    </table>
        <%--</div>--%>
</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>
