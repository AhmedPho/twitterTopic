<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="khlaidTest.aspx.cs" Inherits="stopwordRemovel.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="input"></asp:Label>
        <br />
        <asp:TextBox ID="TxtBoxInput" runat="server" Height="129px" TextMode="MultiLine" Width="403px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="output"></asp:Label>
        <br />
        <asp:TextBox ID="TxtBoxOutput" runat="server" Height="125px" TextMode="MultiLine" Width="408px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnRemoveStopword" runat="server" OnClick="btnRemoveStopword_Click" Text="Remove Stopword" />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Number of stopword removed:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblNumOfSW" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lbERR" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
