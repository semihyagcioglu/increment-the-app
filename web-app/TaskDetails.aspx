<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TaskDetails.aspx.cs" Inherits="increment_the_app.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <script src="js/offer.js"></script>
    
    <style type="text/css">
        .auto-style1 {
            color: #0066FF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <input type="hidden" runat="server" id="TaskDetailsId" />
     <div class="form-group">
        <div id="warningMessagePostedTask" class="alert alert-success" style="display: none;">
           Teklifiniz kaydedildi...
        </div>
    </div>
     <div class="form-group">
        <div id="warningMessage" class="alert alert-danger" style="display: none; text-align:center;"></div>
    </div>
    <div id="TaskDetailsContent">
        <div class="firstbehind">
            <div style="height:200px; width:100px; float:right;">
            <div class="photomins"></div>
               <div style="margin-top:20px; float:left; width: 77px;"> 
                   <asp:Label ID="lblPrice" runat="server"></asp:Label>
                   &nbsp;TL</div>

                 <button type="button" style="text-align:center;" id="btnOffer" class="btn btn-success">Teklif Ver</button>
                   </div>
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
            <div class="Calendar">Tarih:<asp:Label ID="lblDate" runat="server"></asp:Label>
        </div>
            <div class="hours">Saat:<asp:Label ID="lblHour" runat="server"></asp:Label>
        </div>
            <br />
            &nbsp;<div style="margin-left: 25px;"><span class="auto-style1">İşin Detayı :</span></div>
            <div class="post-explanation" style="float:none; margin-bottom:30px; width:560px;margin-left: 25px;">
                <asp:Label ID="lblTaskDetails" runat="server"></asp:Label>
            </div>
        </div>
 
</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>
    