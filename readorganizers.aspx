<%@ Page Title="Organizers" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="readorganizers.aspx.cs" Inherits="readorganizers" %>

<asp:Content ID="Content4" ContentPlaceHolderID="content" Runat="Server">
    
    <form id="participantform" runat="server">
   
    <div>
        <h2>Organizers</h2>
    
        <asp:Label ID="LabelReadOrganizersInfo" runat="server"></asp:Label>
    
        <%--<asp:TextBox ID="TextBoxReadOrganizers" runat="server" Height="145px" TextMode="MultiLine" Width="734px"></asp:TextBox>--%>
        

        <asp:GridView ID="GridViewOrganizers" runat="server" Width="730px" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewOrganizers_SelectedIndexChanged" OnRowDeleting="OrganizerGridviewDeleteRow">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="alias" HeaderText="alias" SortExpression="alias" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="age" HeaderText="age" SortExpression="age" />
                <asp:BoundField DataField="gender" HeaderText="gender" SortExpression="gender" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        
        <h2>Pokehunters</h2>
        <asp:Label ID="LabelReadPokehuntersInfo" runat="server"></asp:Label>

        <asp:GridView ID="GridViewPokehunters" runat="server" Width="730px" OnSelectedIndexChanged="GridViewPokehunters_SelectedIndexChanged"  AutoGenerateColumns="False" onrowcommand="GridViewPokehunters_RowCommand" >
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="alias" HeaderText="alias" SortExpression="alias" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="age" HeaderText="age" SortExpression="age" />
                <asp:BoundField DataField="gender" HeaderText="gender" SortExpression="gender" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                <asp:BoundField DataField="FavoritePokemon" HeaderText="FavoritePokemon" SortExpression="FavoritePokemon" />

                <asp:ButtonField ButtonType="Button" commandname="Select" ShowHeader="True" Text="Delete" />

            </Columns>
            <selectedrowstyle BackColor="lightblue"/>
            
        </asp:GridView>

    </div>

        <div>
            <h2>Change information</h2>
            <asp:Label ID="LabelUpdateFeedback" runat="server"></asp:Label>

            <br />
            <br />

            <asp:Label ID="LabelUpdateInfoFor" runat="server"></asp:Label>
            <asp:Label ID="LabelUpdateInfoAlias" runat="server"></asp:Label>
            <asp:Label ID="LabelUpdateShowType" runat="server"></asp:Label>
            <br />
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
            <asp:RadioButtonList ID="RadioButtonListUpdate" runat="server">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
            <asp:TextBox ID="TextBoxUpdateEmail" runat="server"></asp:TextBox>
            <asp:Label ID="LabelUpdateEmail" runat="server" Text="Email"></asp:Label>
            <br />
            <asp:TextBox ID="TextBoxUpdatePassword" runat="server"></asp:TextBox>
            <asp:Label ID="LabelUpdatePassword" runat="server" Text="Password"></asp:Label>
            <br />
            <asp:TextBox ID="TextBoxUpdateFavorite" runat="server"></asp:TextBox>
            <asp:Label ID="LabelUpdateFavorite" runat="server" Text="Favorite Pokémon"></asp:Label>
            <br />
            
            <br />
            <br />
            <asp:Button ID="ButtonUpdate" runat="server" Text="Button" CssClass="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--accent" OnClick="ButtonUpdate_Click" />
            <br />

            <asp:gridview id="CustomersGridView" 
                allowpaging="true"
                autogeneratecolumns="true"
                autogenerateselectbutton="true"
                selectedindex="0"   
                runat="server"
                OnRowDeleting="CustomersGridView_RowDeleting">

                <selectedrowstyle BackColor="lightblue"/>

            </asp:gridview>
            <asp:button id="DeleteRowButton"
                text="Delete Record"
                onclick="DeleteRowButton_Click" 
                runat="server"/>
        </div>
    </form>
</asp:Content>

