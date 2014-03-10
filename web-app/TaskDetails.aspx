<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TaskDetails.aspx.cs" Inherits="increment_the_app.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            color: #0066FF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="TaskDetailsContent">
        <div class="firstbehind">
            <div style="height:200px; width:100px; float:right;">
            <div class="photomins"></div>
               <div style="margin-top:20px; float:left; width: 91px;"> 
                   <%--<asp:Label ID="lblPrice" runat="server"></asp:Label>--%>
                   <span class="lblPrice" style="margin-left:7px; margin-top:20px;font-size:12px; height:10px;"></span></div>
                   <span class="label label-info" style="margin-left:7px; margin-top:20px;font-size:12px; height:10px;">&nbsp;TL</span></div>
            <br />
            </div>
            <div class="TaskName"><span class="auto-style1">İş Tanımı :</span><asp:Label ID="lblTaskTitle" runat="server" Text=" "></asp:Label>
&nbsp;<asp:Label ID="taskTitle" runat="server"></asp:Label>
            </div>
            <div class="User">
                <asp:Label ID="lblUser" runat="server"></asp:Label>
&nbsp;tarafından</div>
            <br />
            <br />
            <div class="Calendar">Tarih:</div>
            <div class="hours">Saat:</div>
            <br />
            &nbsp;<div><span class="auto-style1">İşin Detayı :</span></div>
            <div class="post-explanation" style="float:none; margin-bottom:10px; width:560px;">
                <asp:Label ID="lblTaskDetails" runat="server"></asp:Label>
            </div>
        </div>
 
</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>
    