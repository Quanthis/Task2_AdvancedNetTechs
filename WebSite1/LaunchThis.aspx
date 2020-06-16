<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeFile="LaunchThis.aspx.cs" Inherits="LaunchThis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <style>
        body
        {
            width: 100%;
            color:white;
            background-color: black;
        }
        .aspbutton
        {
            width : 100%;
        }
        .asplabel
        {
            width : 100%;
        }
    </style>
    <title>Task 2 Of Advanced Net Techs</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button CssClass="aspbutton" Text="Click here to trigger action" ID="Button1" runat="server" OnClick="Button1_Click"/>
        </div>
        <div>
            <asp:TextBox CssClass="asplabel" Text="Enter your text to formatted here" ID="TextBox1" runat="server"/>
            <asp:Label Cssclass="asplabel" Text="Here your formatted text will display" ID="Label1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
