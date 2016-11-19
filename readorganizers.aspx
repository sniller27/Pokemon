<%@ Page Title="Organizers" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="readorganizers.aspx.cs" Inherits="readorganizers" %>

<asp:Content ID="Content4" ContentPlaceHolderID="content" Runat="Server">
    
    <form id="form1" runat="server">
   
    <div>
        <h2>Organizers</h2>
    
        <asp:Label ID="LabelReadOrganizersInfo" runat="server"></asp:Label>
    
        <br />
        <asp:TextBox ID="TextBoxReadOrganizers" runat="server" Height="145px" TextMode="MultiLine" Width="734px"></asp:TextBox>
        
        <h2>Pokehunters</h2>
        <asp:Label ID="LabelReadPokehunterInfo" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxReadPokehunters" runat="server" Height="145px" TextMode="MultiLine" Width="734px"></asp:TextBox>

        <br />
        <asp:ListBox ID="ListBoxReadPokehunters" runat="server" Height="113px" Width="732px" AutoPostBack="True" OnSelectedIndexChanged="ListBoxReadPokehunters_SelectedIndexChanged"></asp:ListBox>

        <br />
        <asp:GridView ID="GridView1" runat="server" Width="730px">
        </asp:GridView>

    </div>

        <div>
            <h2>Change information</h2>
            <asp:TextBox ID="TextBoxUpdateAlias" runat="server"></asp:TextBox>
            <asp:Label ID="LabelUpdateAlias" runat="server" Text="Alias"></asp:Label>
            <br />
            <asp:TextBox ID="TextBoxUpdateName" runat="server"></asp:TextBox>
            <asp:Label ID="LabelUpdateName" runat="server" Text="Name"></asp:Label>
            <br />
            <asp:TextBox ID="TextBoxUpdateAge" runat="server"></asp:TextBox>
            <asp:Label ID="LabelUpdateAge" runat="server" Text="Age"></asp:Label>
            <br />
            <asp:Label ID="LabelUpdateGender" runat="server" Text="Gender"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
            <asp:TextBox ID="TextBoxUpdateEmail" runat="server"></asp:TextBox>
            <asp:Label ID="LabelUpdateEmail" runat="server" Text="Email"></asp:Label>
            <br />
            <br />
            <asp:Button ID="ButtonUpdate" runat="server" Text="Button" CssClass="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--accent" OnClick="ButtonUpdate_Click" />
            <br />



        </div>
    </form>
</asp:Content>

