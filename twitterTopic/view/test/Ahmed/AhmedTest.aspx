<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AhmedTest.aspx.cs" Inherits="twitterTopic.view.test.AhmedTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get Root" />
            <br />
            <asp:Label ID="RootLabel" runat="server"></asp:Label>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
