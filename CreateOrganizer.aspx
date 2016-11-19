<%@ Page Title="Create Organizer" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="CreateOrganizer.aspx.cs" Inherits="CreateOrganizer" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <h2>Sign up</h2>

    <form id="createorganizerform" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Create Organizer"></asp:Label>
        <br />

        <asp:TextBox ID="TextBoxAlias" runat="server"></asp:TextBox>
        <asp:Label ID="LabelAlias" runat="server" Text="Alias"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        <asp:Label ID="LabelName" runat="server" Text="Name"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxAge" runat="server"></asp:TextBox>
        <asp:Label ID="LabelAge" runat="server" Text="Age"></asp:Label>
        <br />
        <asp:Label ID="LabelGender" runat="server" Text="Gender"></asp:Label>
        <br />
        <asp:RadioButtonList ID="RadioButtonListOrganizerGender" runat="server">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
        <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
        <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxPasswordRepeat" runat="server"></asp:TextBox>
        <asp:Label ID="LabelPasswordRepeat" runat="server" Text="Repeat password"></asp:Label>
        <br />
        <asp:dropdownlist runat="server" ID="DropdownlistCreateParticipant" AutoPostBack="True" OnSelectedIndexChanged="Unnamed1_SelectedIndexChanged">
            <asp:ListItem>Organizer</asp:ListItem>
            <asp:ListItem>Pokehunter</asp:ListItem>
        </asp:dropdownlist>
        <br />
        <asp:TextBox ID="TextBoxFavorite" runat="server"></asp:TextBox>
        <asp:Label ID="LabelFavoriteAdd" runat="server" Text="Favorite Pokémon"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="ButtonCreateOrganizer" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--accent" runat="server" Text="Button" OnClick="ButtonCreateOrganizer_Click" />
        <br />
        <br />
        <asp:Label ID="LabelAddOrganizerFeedback" runat="server"></asp:Label>
    </div>
    </form>

</asp:Content>
