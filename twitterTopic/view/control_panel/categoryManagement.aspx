<%@ Page Title="" Language="C#" MasterPageFile="~/view/control_panel/ControlPanel.Master" AutoEventWireup="true" CodeBehind="categoryManagement.aspx.cs" Inherits="twitterTopic.view.control_panel.categoryManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>&nbsp;</td>
            <td colspan="4">
                <asp:Label ID="Error1" runat="server" ForeColor="Red" Text="Enter Category Name." Visible="False"></asp:Label>
                <br />
                <asp:Label ID="Error2" runat="server" ForeColor="Red" Text="Select Category." Visible="False"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Add : "></asp:Label>
            </td>
            <td colspan="4">
                <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Edit : "></asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1" DataTextField="CategoryName" DataValueField="IDOfCategory">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Database1ConnectionString %>" SelectCommand="SELECT [IDOfCategory], [CategoryName] FROM [Category]"></asp:SqlDataSource>
            </td>
            <td colspan="2">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Edit" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Delete : "></asp:Label>
            </td>
            <td colspan="4">
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="CategoryName" DataValueField="IDOfCategory">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Database1ConnectionString %>" SelectCommand="SELECT [IDOfCategory], [CategoryName] FROM [Category]"></asp:SqlDataSource>
            </td>
            <td>
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Delete" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Link To List : "></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Cateogry : "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource3" DataTextField="CategoryName" DataValueField="IDOfCategory">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Database1ConnectionString %>" SelectCommand="SELECT [IDOfCategory], [CategoryName] FROM [Category]"></asp:SqlDataSource>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text="List : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" style="width: 38px" Text="Link" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="Get Tweets : "></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Cateogry : "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="SqlDataSource4" DataTextField="CategoryName" DataValueField="IDOfCategory">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Database1ConnectionString %>" SelectCommand="SELECT CategoryName, IDOfCategory FROM Category WHERE (ListID IS NOT NULL)"></asp:SqlDataSource>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Get Tweets" />
            </td>
        </tr>
    </table>
</asp:Content>
