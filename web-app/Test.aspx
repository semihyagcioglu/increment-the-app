<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="increment_the_app.Test" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="shortcut icon" href="img/favicon.png">

    <title>Increment the App</title>

    <!-- Bootstrap core CSS -->
      <link href="css/bootstrap-theme.css" rel="stylesheet" />
     
      <link href="css/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
      <link href="css/jumbotron-narrow.css" rel="stylesheet" /> 

    <!-- Just for debugging purposes. Don't actually copy this line! -->
    <!--[if lt IE 9]><script src="../../docs-assets/js/ie8-responsive-file-warning.js"></script><![endif]-->

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->
  </head>

  <body>
      <form id="frm" runat="Server">
    <div class="container">
        <div class="header" >
            <div class="btn"><a href="LogIn.aspx" target="_self">Login</a></div>
            <div class="btn btn-success">Sign Up</div>
        </div>

      <div class="jumbotron">
          <asp:GridView ID="gvUsers" runat="server"></asp:GridView>
       
      </div>
        
        <div class="row marketing">
          
		
      </div>

      <div class="footer">
        <p>&copy; Increment the App 2013</p>
      </div>

    </div> <!-- /container -->

          </form>
    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
  </body>
</html>
