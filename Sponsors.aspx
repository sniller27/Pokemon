<%@ Page Title="" Language="C#" MasterPageFile="~/Loginmenu.master" AutoEventWireup="true" CodeFile="Sponsors.aspx.cs" Inherits="Sponsors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderhead" Runat="Server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent1" Runat="Server">

    <asp:GridView ID="GridView1" runat="server"></asp:GridView>

    <asp:Label ID="Label1" runat="server" Text="Add new sponsor"></asp:Label>
    <br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    <br />
    <br />
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />

</asp:Content>

