<%@ Page Title="Pokemon battle" Language="C#" MasterPageFile="~/Loginmenu.master" AutoEventWireup="true" CodeFile="CatchPokemon.aspx.cs" Inherits="CatchPokemon" %>

<asp:Content ID="Content11" ContentPlaceHolderID="ChildContent1" Runat="Server">
    <h1>A wild Pokémon has appeared!</h1>
    <asp:label runat="server" text="" ID="LabelFight"></asp:label>
    <asp:datalist runat="server" id="datalistcatchpokemon">
        <ItemTemplate>
            <asp:HiddenField ID="HiddenFieldPokemonId" runat="server" Value='<%#Eval("PokemonId") %>' />
            <asp:Label ID="LabelCatchPokemonName" runat="server" Text='<%#Eval("Name") %>'></asp:Label> 
            - Level:
            <asp:Label ID="LabelCatchPokemonLevel" runat="server" Text='<%#Eval("RandomLevel") %>'></asp:Label>
            <asp:Image runat="server" ImageUrl='<%# "Images/" + Eval("Image") %>' Width="100%" ID="ImageCatchPokemon" />
        </ItemTemplate>
    </asp:datalist>
    <h2>Click the Pokeball to catch it.</h2>
    <asp:ImageButton ID="ImageButtonPokeballCatch" runat="server" Height="61px" ImageUrl="~/Images/Pokeball.png" Width="63px" OnClick="ImageButtonPokeballCatch_Click" />
</asp:Content>

