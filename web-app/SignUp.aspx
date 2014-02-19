<%@ Page Title="" Language="C#" MasterPageFile="~/NonSessionSite.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="increment_the_app.SignUp" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">

    <script src="js/signup.js"></script>

</asp:Content>
<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">

    <div class="row">
		<div class="col-md-4 col-md-offset-4">
    		<div class="panel panel-default">
			  	<div class="panel-heading">
			    	<h3 class="panel-title">Sadece 10 saniyede</h3>
			 	</div>
			  	<div class="panel-body">	
                      <div class="form-group">
                        <div id="warningMessage" class="alert alert-danger" style="display: none;"></div>
                    </div>    	  	
			    		<div class="form-group">
                            <input id="nameInfo" class="form-control" name="firstname" placeholder="Ad" type="text"
                            required autofocus />
                        </div>
                        <div class="form-group">
                            <input id="surnameInfo" class="form-control" name="lastname" placeholder="Soyad" type="text" required />
			    		</div>
			    		<div class="form-group">
			    			<input id="emailInfo" class="form-control" name="youremail" placeholder="E-Posta" type="email" required />
			    		</div>
                       
                        <div class="form-group">
			    			<input id="passwordInfo" class="form-control" name="password" placeholder="Şifre" type="password" required />
			    		</div>
			    		<div class="checkbox">
			    	    	<label>
			    	    		<input name="chkAcceptTOC" type="checkbox" value="accept" checked required> <span><a href="#">Kullanım şartlarını</a> kabul ediyorum</span>
			    	    	</label>
			    	    </div>

                        <div class="form-group">
                           <a href="Login.aspx" class="btn btn-lg btn-link" ><span style="font-size:12px;">Zaten bir hesabın var mı?</span></a>
                        </div>
			    		<div id="btnRegister" class="btn btn-lg btn-success btn-block">Kayıt ol</div>
			    </div>
			</div>
		</div>
	</div>

       
    
</asp:Content>

<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>