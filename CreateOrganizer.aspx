<%@ Page Title="Create Organizer" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="CreateOrganizer.aspx.cs" Inherits="CreateOrganizer" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <h2>Sign up</h2>

    <form id="createorganizerform" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Create Organizer"></asp:Label>
        <br />

        <asp:TextBox ID="TextBoxAlias" runat="server"></asp:TextBox>
        <asp:Label ID="LabelAlias" runat="server" Text="Alias"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxAlias" EnableClientScript="False" ErrorMessage="Fill in alias please" CssClass="errorcolor"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        <asp:Label ID="LabelName" runat="server" Text="Name"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxName" EnableClientScript="False" ErrorMessage="Fill in name please" CssClass="errorcolor"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="TextBoxAge" runat="server" TextMode="Number"></asp:TextBox>
        <asp:Label ID="LabelAge" runat="server" Text="Age"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxAge" EnableClientScript="False" ErrorMessage="Fill in age please" CssClass="errorcolor"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="LabelGender" runat="server" Text="Gender"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="RadioButtonListOrganizerGender" EnableClientScript="False" ErrorMessage="Choose your gender please" CssClass="errorcolor"></asp:RequiredFieldValidator>
        <br />
        <asp:RadioButtonList ID="RadioButtonListOrganizerGender" runat="server">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:TextBox ID="TextBoxEmail" runat="server" TextMode="Email"></asp:TextBox>
        <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxEmail" EnableClientScript="False" ErrorMessage="Fill in your email please" CssClass="errorcolor"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please write your email properly" ValidationExpression="[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" CssClass="errorcolor" ControlToValidate="TextBoxEmail" EnableClientScript="False"></asp:RegularExpressionValidator>
        <br />
        <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="passwordstyle"></asp:TextBox>
        <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxPassword" EnableClientScript="False" ErrorMessage="Fill in your password please" CssClass="errorcolor"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="TextBoxPasswordRepeat" runat="server" CssClass="passwordstyle"></asp:TextBox>
        <asp:Label ID="LabelPasswordRepeat" runat="server" Text="Password confirmation"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBoxPasswordRepeat" EnableClientScript="False" ErrorMessage="Repeat your password please" CssClass="errorcolor"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxPasswordRepeat" ControlToValidate="TextBoxPassword" EnableClientScript="False" ErrorMessage="Passwords must be identical" CssClass="errorcolor"></asp:CompareValidator>
        <br />
        <asp:dropdownlist runat="server" ID="DropdownlistCreateParticipant" AutoPostBack="True" OnSelectedIndexChanged="Unnamed1_SelectedIndexChanged">
            <asp:ListItem>Organizer</asp:ListItem>
            <asp:ListItem>Pokehunter</asp:ListItem>
        </asp:dropdownlist>
        <br />
        <asp:TextBox ID="TextBoxFavorite" runat="server" Enabled="False"></asp:TextBox>
        <asp:Label ID="LabelFavoriteAdd" runat="server" Text="Favorite Pokémon"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCreateFavorite" runat="server" ControlToValidate="TextBoxFavorite" CssClass="errorcolor" EnableClientScript="False" Enabled="False" ErrorMessage="Please choose your favorite Pokémon"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        <asp:Button ID="ButtonCreateOrganizer" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--accent" runat="server" Text="Sign up" OnClick="ButtonCreateOrganizer_Click" />
        <br />
        <br />
        <asp:Label ID="LabelAddOrganizerFeedbackPositive" runat="server" CssClass="successcolor"></asp:Label>
        <asp:Label ID="LabelAddOrganizerFeedbackNegative" runat="server" CssClass="errorcolor"></asp:Label>
    </div>
    </form>

</asp:Content>
