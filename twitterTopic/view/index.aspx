<%@ Page Title="" Language="C#" MasterPageFile="~/view/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="twitterTopic.view.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    &nbsp;<asp:ImageButton ID="Button1" runat="server" Text="Button"  ImageUrl="~/img/login.png" OnClick="Button1_Click" />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
</asp:Content>
