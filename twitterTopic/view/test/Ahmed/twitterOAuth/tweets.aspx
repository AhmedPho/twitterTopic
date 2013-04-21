<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tweets.aspx.cs" Inherits="twitterTopic.view.test.Ahmed.twitterOAuth.tweets" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="tweet" HeaderText="tweet" SortExpression="tweet" />
                <asp:BoundField DataField="dataOfTweet" HeaderText="dataOfTweet" SortExpression="dataOfTweet" />
                <asp:BoundField DataField="fromUser" HeaderText="fromUser" SortExpression="fromUser" />
                <asp:BoundField DataField="idOfTweet" HeaderText="idOfTweet" SortExpression="idOfTweet" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Database1ConnectionString %>" SelectCommand="SELECT * FROM [TweetForCategory]"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
