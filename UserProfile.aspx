<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
    <form id="profileform" runat="server">
      
        <h2>Profile</h2>
        <asp:Label ID="LabelNegativeFeedback" runat="server"></asp:Label>
        <br />
        <asp:Label ID="LabelPositiveFeedback" runat="server"></asp:Label>
        <br />
        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
            <asp:TextBox ID="TextBoxAlias" runat="server" class="mdl-textfield__input"></asp:TextBox>
            <asp:Label ID="LabelAlias" runat="server" Text="Alias" AssociatedControlId="TextBoxAlias" class="mdl-textfield__label"></asp:Label>
        </div>
        <br />
        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
            <asp:TextBox ID="TextBoxName" runat="server" class="mdl-textfield__input"></asp:TextBox>
            <asp:Label ID="LabelName" runat="server" Text="Name" AssociatedControlId="TextBoxName" class="mdl-textfield__label"></asp:Label>
        </div>
        <br />
        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
            <asp:TextBox ID="TextBoxAge" runat="server" class="mdl-textfield__input"></asp:TextBox>
            <asp:Label ID="LabelAge" runat="server" Text="Age" AssociatedControlId="TextBoxAge" class="mdl-textfield__label"></asp:Label>
        </div>
        <br />
        <asp:Label ID="LabelGender" runat="server" Text="Gender"></asp:Label>
        <asp:RadioButtonList ID="RadioButtonListGender" runat="server">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:RadioButtonList>
        <br />

        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
            <asp:TextBox ID="TextBoxEmail" runat="server" class="mdl-textfield__input"></asp:TextBox>
            <asp:Label ID="LabelEmail" runat="server" Text="Email" AssociatedControlId="TextBoxEmail" class="mdl-textfield__label"></asp:Label>
        </div>
        <br />
        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
            <asp:TextBox ID="TextBoxPassword" runat="server" class="mdl-textfield__input"></asp:TextBox>
            <asp:Label ID="LabelPassword" runat="server" Text="Password" AssociatedControlId="TextBoxPassword" class="mdl-textfield__label"></asp:Label>
        </div>
        <br />
        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
            <asp:TextBox ID="TextBoxFavorite" runat="server" class="mdl-textfield__input"></asp:TextBox>
            <asp:Label ID="LabelFavorite" runat="server" Text="Favorite Pokémon" AssociatedControlId="TextBoxFavorite" class="mdl-textfield__label"></asp:Label>
        </div>
        <br />
        <asp:Button ID="ButtonUpdate" runat="server" Text="Update" OnClick="ButtonUpdate_Click" class="mdl-button mdl-js-button mdl-button--raised mdl-button--accent" />
        <br />
        <br />
        <hr />
        <br />
        <br />
        <p>WARNING: THIS WILL DELETE YOUR PROFILE!</p>
        <asp:Button ID="ButtonDelete" runat="server" Text="Delete profile" OnClick="ButtonDelete_Click" class="mdl-button mdl-js-button mdl-button--raised" />

    </form>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="afterscripts" Runat="Server">
    <script>

        //document.getElementById("content_RadioButtonListGender_0").className = 'class="mdl-radio__button"';

    </script>
</asp:Content>


