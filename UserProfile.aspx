<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
    <form id="profileform" runat="server">
      
        <h2>Profile</h2>
        <asp:Label ID="LabelNegativeFeedback" runat="server"></asp:Label>
        <br />
        <asp:Label ID="LabelPositiveFeedback" runat="server"></asp:Label>
        <br />

        <asp:TextBox ID="TextBoxAlias" runat="server"></asp:TextBox><asp:Label ID="LabelAlias" runat="server" Text="Alias"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox><asp:Label ID="LabelName" runat="server" Text="Name"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxAge" runat="server"></asp:TextBox><asp:Label ID="LabelAge" runat="server" Text="Age"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxGender" runat="server"></asp:TextBox><asp:Label ID="LabelGender" runat="server" Text="Gender"></asp:Label>
        <asp:RadioButtonList ID="RadioButtonListGender" runat="server">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox><asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox><asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxFavorite" runat="server"></asp:TextBox><asp:Label ID="LabelFavorite" runat="server" Text="Favorite Pokémon"></asp:Label>
        <br />
        <asp:Button ID="ButtonUpdate" runat="server" Text="Update" OnClick="ButtonUpdate_Click" />
        <br />
        <br />
        <hr />
        <br />
        <br />
        <p>WARNING: THIS WILL DELETE YOUR PROFILE!</p>
        <asp:Button ID="ButtonDelete" runat="server" Text="Delete profile" />

    </form>
</asp:Content>

