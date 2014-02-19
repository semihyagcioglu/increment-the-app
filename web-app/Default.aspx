<%@ Page Language="C#" MasterPageFile="~/NonSessionSite.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="increment_the_app.Default" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">

      <div class="jumbotron">
       
          <div id="iphone" class="iphone"><img src="img/slide3_3.png" width="143px" height="376px" /></div>
          <div class="motto"> 
              <div class="motto-title">Increment the App</div>
			  
              <p >The ultimate application that will set you free. An amazing app for amazing people.</p>
          </div>

          <div id="btn" class="buttons">
              <a href="contact.html" class="btn btn-success" style="background-image: url('./img/taskwork.png'); background-repeat: no-repeat; background-position: center; height:110px;"></a>
              <a href="contact.html" class="btn btn-warning" style="background-image: url('./img/button_googlePlay.png'); background-repeat: no-repeat; background-position: center; height:110px"></a>
              <a href="contact.html" class="btn btn-primary" style="background-image: url('./img/button_win.png'); background-repeat: no-repeat; background-position: center; height:110px"></a>
          </div>
      </div>
        
      <div class="row marketing">
          
		
      </div>

</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>