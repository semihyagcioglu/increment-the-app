<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="increment_the_app.SignUp" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">

    <div class="row">
		<div class="col-md-4 col-md-offset-4">
    		<div class="panel panel-default">
			  	<div class="panel-heading">
			    	<h3 class="panel-title">Sadece 5 saniyede</h3>
			 	</div>
			  	<div class="panel-body">
			    	<form accept-charset="UTF-8" role="form">
			    	  	
			    		<div class="form-group">
                            <input class="form-control" name="firstname" placeholder="Ad" type="text"
                            required autofocus />
                        </div>
                        <div class="form-group">
                            <input class="form-control" name="lastname" placeholder="Soyad" type="text" required />
			    		</div>
			    		<div class="form-group">
			    			<input class="form-control" name="youremail" placeholder="E-Posta" type="email" />
			    		</div>
                        <div class="form-group">
			    			<input class="form-control" name="reenteremail" placeholder="E-Posta tekrar" type="email" />
			    		</div>
                        <div class="form-group">
			    			<input class="form-control" name="password" placeholder="Şifre" type="password" />
			    		</div>
			    		<div class="checkbox">
			    	    	<label>
			    	    		<input name="chkAcceptTOC" type="checkbox" value="kabul ediyorum"> <span><a href="#">Kullanım şartlarını</a> kabul ediyorum</span>
			    	    	</label>
			    	    </div>
			    		<input class="btn btn-lg btn-success btn-block" type="submit" value="Kayıt ol">
			      	</form>
			    </div>
			</div>
		</div>
	</div>

       
    
</asp:Content>

<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>