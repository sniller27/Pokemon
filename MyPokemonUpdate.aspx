<%@ Page Title="My Pokémon Updates" Language="C#" MasterPageFile="~/Loginmenu.master" AutoEventWireup="true" CodeFile="MyPokemonUpdate.aspx.cs" Inherits="MyPokemonUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent1" Runat="Server">

    <asp:Label ID="LabelPositiveFeedback" runat="server" Text=""></asp:Label>
    <asp:Label ID="LabelNegativeFeedback" runat="server" Text=""></asp:Label>
    <h2>Update my Pokémon</h2>
    <p>Choose Pokémon to update:</p>
    <asp:DropDownList ID="DropDownListPokemons" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPokemons_SelectedIndexChanged"></asp:DropDownList>

    <br />
    <br />
    <asp:TextBox ID="TextBoxPokemonName" runat="server"></asp:TextBox>
    <asp:Label ID="LabelPokemonName" runat="server" Text="Pokémon name"></asp:Label>
    <br />
    <asp:TextBox ID="TextBoxPokemonLevel" runat="server"></asp:TextBox>
    <asp:Label ID="LabelLevel" runat="server" Text="Level"></asp:Label>
    <br />
    <asp:TextBox ID="TextBoxPokemonCurExp" runat="server"></asp:TextBox>
    <asp:Label ID="LabelCurExp" runat="server" Text="Current Experience"></asp:Label>
    <br />
    <asp:TextBox ID="TextBoxNextLvlExp" runat="server"></asp:TextBox>
    <asp:Label ID="LabelNextLvlExp" runat="server" Text="Experience to next level"></asp:Label>
    <br />
    <asp:Label ID="LabelPokemonGender" runat="server" Text="Gender"></asp:Label>
    <br />
    <asp:RadioButtonList ID="RadioButtonListPokemonGender" runat="server">
        <asp:ListItem>Male</asp:ListItem>
        <asp:ListItem>Female</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <asp:Button ID="ButtonUpdatePokecatch" runat="server" Text="Update" OnClick="ButtonUpdatePokecatch_Click" />

</asp:Content>

