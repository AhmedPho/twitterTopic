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
    
        &nbsp;&nbsp;&nbsp;
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Retrieve Tweets" />
        <br />
        <asp:TextBox ID="TextBox3" runat="server" Height="387px" style="margin-top: 0px" TextMode="MultiLine" Width="1098px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="OAuthToken (Access Token):"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label7" runat="server" Text="AccessToken (Access Token Secret):"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label8" runat="server" Text="User Screen Name (authenticated user):"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Text="Number of tweets retrieved:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label10" runat="server" Text="Number of requsts:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label11" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="389px" TextMode="MultiLine" Width="549px"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" Height="389px" TextMode="MultiLine" Width="549px"></asp:TextBox>
        <br />
    
    </div>
    </form>
</body>
</html>
