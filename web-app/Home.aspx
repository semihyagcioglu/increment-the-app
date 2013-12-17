<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="increment_the_app.Home" %>

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

    <div class="container">
        <div class="header">
           <div class ="ustbuton">
             <div class="btn"><a href="LogIn.aspx" target="_self">Login</a></div>
         <div class="btn btn-success">Sign Up</div></div><!--ustbuton bitiş-->
            <div class="logo"> İncrements the App </div>
        </div>

        <div class="main">

            

            <div class="solMenu">

            
                <div class="dropdown">                
                    <div class="baslik"><span class="label label-success"> İş Veren</span></div>
                <div class="alt-baslik"> <span class="label label-success">En Son Eklenenler</span></div>
                  <div class="ilanicerik">
              
                
                      <ul class ="onilan">
                   
                    <li>İlan1</li>
                    <li>İlan2</li>
                    <li>İlan3</li>
                    <li>İlan4</li>
                    <li>İlan5</li>
                  
                   
                </ul>
                    

                      </div>

                    <div class="solalt">

                       <div class="baslik"><span class="label label-success">Çalışan</span></div>
                        <div class="alt-baslik"> <span class="label label-success">En Son Eklenenler</span></div>
                        <ul class ="onilan">
                   
                    <li>İlan1</li>
                    <li>İlan2</li>
                    <li>İlan3</li>
                    <li>İlan4</li>
                    <li>İlan5</li>
                 
                   
                </ul>
                    </div>

                </div>
                    
            </div>

            <div class="ortamenu">
         
                <div class="panel panel-default">
  <div class="panel-heading">Ayın En Başarılı Çalışanı</div>
  <div class="panel-body">
    Ahmet Mehmet
  </div>
</div>

<div class="panel panel-default">
  <div class="panel-heading">
    <h3 class="panel-title">Ayın En Hızlı Çalışanı</h3>
  </div>
  <div class="panel-body">
   Ali Veli
  </div>
</div>
                <div class="panel panel-default">
  <div class="panel-heading">Ayın Fırsatı</div>
  <div class="panel-body">
    %10 İndirim
  </div>
</div>

<div class="panel panel-default">
  <div class="panel-heading">
    <h3 class="panel-title">Büyük İlanlar</h3>
  </div>
  <div class="panel-body">
      <img src="img/slider-img-2.jpg" width="470" />
  </div>
</div>
            </div>
            

        </div>


        <div class="row marketing">
        </div>

        <div class="footer">
            <p>&copy; Increment the App 2013</p>
        </div>

    </div>
    <!-- /container -->


    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
</body>
</html>
