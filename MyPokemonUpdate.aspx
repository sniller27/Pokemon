﻿<%@ Page Title="My Pokémon Updates" Language="C#" MasterPageFile="~/Loginmenu.master" AutoEventWireup="true" CodeFile="MyPokemonUpdate.aspx.cs" Inherits="MyPokemonUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent1" Runat="Server">

    <asp:Label ID="LabelPositiveFeedback" runat="server" Text=""></asp:Label>
    <asp:Label ID="LabelNegativeFeedback" runat="server" Text=""></asp:Label>
    <h2>Update my Pokémon</h2>

    <asp:gridview runat="server" ID="GridviewUpdateCatches" AutoGenerateColumns="false" OnSelectedIndexChanged="GridviewUpdateCatches_SelectedIndexChanged" DataKeyNames="CatchId">

        <Columns>
                <%--<asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "Images/" + Eval("Image") %>' CssClass="mypokemonimage" />
                </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="CatchName" HeaderText="Nickname" SortExpression="CatchName" />
                <asp:BoundField DataField="Lvl" HeaderText="Level" SortExpression="Level" />
                <asp:BoundField DataField="CurrentExp" HeaderText="Current experience" SortExpression="age" />
                <asp:BoundField DataField="NextLvlExp" HeaderText="Experience to next level" SortExpression="gender" />
                <asp:BoundField DataField="PokemonGender" HeaderText="Gender" SortExpression="email" />
                <asp:BoundField DataField="CatchId" HeaderText="CatchId" SortExpression="CatchId" />
        </Columns>


    </asp:gridview>

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
        <asp:ListItem>male</asp:ListItem>
        <asp:ListItem>female</asp:ListItem>
    </asp:RadioButtonList>
    <asp:HiddenField ID="HiddenFieldCatchId" runat="server" />
    <br />
    <asp:Button ID="ButtonUpdatePokecatch" runat="server" Text="Update" OnClick="ButtonUpdatePokecatch_Click" />

</asp:Content>

