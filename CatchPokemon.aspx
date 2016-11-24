<%@ Page Title="" Language="C#" MasterPageFile="~/Loginmenu.master" AutoEventWireup="true" CodeFile="CatchPokemon.aspx.cs" Inherits="CatchPokemon" %>

<asp:Content ID="Content11" ContentPlaceHolderID="ChildContent1" Runat="Server">
    <h1>A wild Pokémon has appeared!</h1>
    <asp:label runat="server" text="Label" ID="LabelFight"></asp:label>
    <asp:datalist runat="server" id="datalistcatchpokemon">
        <ItemTemplate>
            <img class="<%#Eval("PokemonId") %>" src="Images/<%#Eval("Image") %>" />
        </ItemTemplate>
    </asp:datalist>
    <h2>Click the Pokeball to catch it.</h2>
    <asp:ImageButton ID="ImageButton1" runat="server" Height="61px" ImageUrl="~/Images/Pokeball.png" Width="63px" OnClick="ImageButton1_Click" />

</asp:Content>

