<%@ Page Title="" Language="C#" MasterPageFile="~/view/MasterPage.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="twitterTopic.view.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="التسجيل"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="الأسم"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="الأيميل"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server">السياسات والشروط</asp:HyperLink>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="أوافق" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
