<%@ Page Title="Welcome to Pokémon event 2016" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Welcome" %>

<asp:Content ID="Content4" ContentPlaceHolderID="content" Runat="Server">
      
    <div class="frontpagebox">

        <h2>Welcome to Pokémon event 2016</h2>

        <div class="contentcenter mdl-shadow--2dp">

            <form id="loginform" runat="server">

                <asp:Label ID="LabelPositiveFeedback" runat="server"></asp:Label>
                <asp:Label ID="LabelNegativeFeedback" runat="server"></asp:Label>
                <br />
                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                    <asp:TextBox ID="TextBoxAlias" runat="server" class="mdl-textfield__input"></asp:TextBox>
                    <asp:Label ID="LabelAliasLogin" runat="server" Text="Alias" AssociatedControlId="TextBoxAlias" class="mdl-textfield__label"></asp:Label>
                </div>
                <br />
                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                    <asp:TextBox ID="TextBoxPassword" runat="server" class="mdl-textfield__input"></asp:TextBox>
                    <asp:Label ID="LabelPasswordLogin" runat="server" Text="Password" AssociatedControlId="TextBoxPassword" class="mdl-textfield__label"></asp:Label>
                </div>
                <br />
                <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--accent" />

            </form>

        </div>

    </div>  



</asp:Content>

