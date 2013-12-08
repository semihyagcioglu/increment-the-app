<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="increment_the_app.LogIn" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">

    <div class="row">
		<div class="col-md-4 col-md-offset-4">
    		<div class="panel panel-default">
			  	<div class="panel-heading">
			    	<h3 class="panel-title">Giriş yapın</h3>
			 	</div>
			  	<div class="panel-body">
			    	  	<div class="form-group">
			    		    <input class="form-control" placeholder="E-posta" name="email" type="email" required>
			    		</div>
			    		<div class="form-group">
			    			<input class="form-control" placeholder="Şifre" name="password" type="password" value="" required>
			    		</div>
			    		<div class="checkbox">
			    	    	<label>
			    	    		<input name="remember" type="checkbox" value="Remember Me" checked> Beni hatırla
			    	    	</label>
			    	    </div>
			    		<input class="btn btn-lg btn-success btn-block" type="submit" value="Giriş yap">
			    </div>
			</div>
		</div>
	</div>

</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>