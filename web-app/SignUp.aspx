<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="increment_the_app.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <title>Sign Up - Bootsnipp.com</title>

    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        body
        {
            padding-top: 30px;
        }

        .form-control
        {
            margin-bottom: 10px;
        }
    </style>
    <script src="//code.jquery.com/jquery-1.10.2.min.js"></script>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.0.0/js/bootstrap.min.js"></script>
    <script type="text/javascript">window.alert = function () { }</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row" style="align-content:center">
            <div class="col-xs-12 col-sm-12 col-md-4 well well-sm">
                <span>Sign up!</span>
                <div class="row">
                    <div class="col-xs-6 col-md-6">
                        <input class="form-control" name="firstname" placeholder="First Name" type="text"
                            required autofocus />
                    </div>
                    <div class="col-xs-6 col-md-6">
                        <input class="form-control" name="lastname" placeholder="Last Name" type="text" required />
                    </div>
                </div>
                <input class="form-control" name="youremail" placeholder="Your Email" type="email" />
                <input class="form-control" name="reenteremail" placeholder="Re-enter Email" type="email" />
                <input class="form-control" name="password" placeholder="New Password" type="password" />

                <asp:CheckBox ID="CheckBox1" runat="server" />
                <span>I agree with the <a href="#">Terms and Conditions.</a></span>
                <br />
                <br />
                <button class="btn btn-lg btn-primary btn-block" type="submit">
                    Sign up</button>
            </div>
        </div>
    <script type="text/javascript">
    </script>
</asp:Content>
