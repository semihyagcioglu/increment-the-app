<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendGrid.aspx.cs" Inherits="increment_the_app.SendGrid" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
    <div>
        rto mail
        <asp:TextBox ID="txtToMail" runat="server"></asp:TextBox>
&nbsp;to name
        <asp:TextBox ID="txtToName" runat="server"></asp:TextBox>
&nbsp;<br />
        from mail&nbsp;
        <asp:TextBox ID="txtFromMail" runat="server"></asp:TextBox>
&nbsp; from name&nbsp;
        <asp:TextBox ID="txtFromName" runat="server"></asp:TextBox>
        &nbsp;&nbsp; it can be everythink.<br />
        subject <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
        <br />
        text
        <asp:TextBox ID="txtText" runat="server"></asp:TextBox>
&nbsp; we can send html or text.<br />
        <br />
        <br />
        <br />
        ........<br />
        <br />
        <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="Send" />
    </div>
    </form>
</body>
</html>