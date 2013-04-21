<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="done.aspx.cs" Inherits="twitterTopic.view.test.twitterOAuth.done" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label5" runat="server" Text="Get Tweet For @"></asp:Label>
        <asp:TextBox ID="TextBoxUser" runat="server"></asp:TextBox>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="389px" TextMode="MultiLine" Width="549px"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" Height="389px" TextMode="MultiLine" Width="549px"></asp:TextBox>
        <asp:TextBox ID="TextBox3" runat="server" Height="387px" style="margin-top: 0px" TextMode="MultiLine" Width="545px"></asp:TextBox>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
