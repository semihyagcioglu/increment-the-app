<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SingUp.aspx.cs" Inherits="increment_the_app.SingUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Signup form three fields - Bootsnipp.com</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="//netdna.bootstrapcdn.com/twitter-bootstrap/2.3.2/css/bootstrap-combined.min.css" rel="stylesheet" />
    <style type="text/css">
        </style>
    <script src="//code.jquery.com/jquery-1.10.2.min.js"></script>
    <script src="//netdna.bootstrapcdn.com/twitter-bootstrap/2.3.2/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        window.alert = function () { }
        function ClearText() {
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
            <div class="span3 well">
                <%--<asp:Label ID="lblTitle" runat="server">New to WebApp? Sing Up!</asp:Label>--%>
                <legend>New to WebApp? Sign up!</legend>
                <asp:TextBox CssClass="span3" ID="txtName" Text="Name" TextMode="SingleLine" runat="server" />
                <asp:TextBox CssClass="span3" ID="txtSurname" Text="Surname" TextMode="SingleLine" runat="server" />
                <asp:TextBox CssClass="span3" ID="txtEmail" Text="E-Mail" TextMode="Email" runat="server" />
                <asp:TextBox CssClass="span3" ID="txtPassword" Text="Password" TextMode="Password" runat="server" />
                <label class="checkbox">
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                    I agree all your <a href="#">Terms of Services</a>
                </label>
                <asp:Button CssClass="btn btn-warning" ID="btnSubmit" runat="server" Text="ButtonSign up for WebApp" />
            </div>
    </form>
</body>
</html>
