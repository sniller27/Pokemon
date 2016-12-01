<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Welcome" %>

<asp:Content ID="Content4" ContentPlaceHolderID="content" Runat="Server">
    <h2>Welcome to Pokémon event 2016</h2>
    <form id="loginform" runat="server">
        <asp:Label ID="LabelPositiveFeedback" runat="server"></asp:Label>
        <asp:Label ID="LabelNegativeFeedback" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxAlias" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click" />

    </form>
</asp:Content>

