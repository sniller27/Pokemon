<%@ Page Title="Organizers" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="readorganizers.aspx.cs" Inherits="readorganizers" %>

<asp:Content ID="Content4" ContentPlaceHolderID="content" Runat="Server">
    
    <form id="participantform" runat="server">
   
    <div>
        <h2>Organizers</h2>
    
        <asp:Label ID="LabelReadOrganizersInfo" runat="server"></asp:Label>
    
        <%--<asp:TextBox ID="TextBoxReadOrganizers" runat="server" Height="145px" TextMode="MultiLine" Width="734px"></asp:TextBox>--%>
        

        <asp:GridView ID="GridViewOrganizers" runat="server" Width="730px" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewOrganizers_SelectedIndexChanged" OnRowDeleting="GridViewOrganizers_RowDeleting" datakeynames="alias">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="alias" HeaderText="alias" SortExpression="alias" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="age" HeaderText="age" SortExpression="age" />
                <asp:BoundField DataField="gender" HeaderText="gender" SortExpression="gender" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
            </Columns>
            <%--<selectedrowstyle BackColor="lightblue"/>--%>

        </asp:GridView>
        
        <h2>Pokehunters</h2>
        <asp:Label ID="LabelReadPokehuntersInfo" runat="server"></asp:Label>

        <asp:GridView ID="GridViewPokehunters" runat="server" Width="730px" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewPokehunters_SelectedIndexChanged" OnRowDeleting="GridViewPokehunters_RowDeleting" datakeynames="alias">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="alias" HeaderText="alias" SortExpression="alias" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="age" HeaderText="age" SortExpression="age" />
                <asp:BoundField DataField="gender" HeaderText="gender" SortExpression="gender" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                <asp:BoundField DataField="FavoritePokemon" HeaderText="FavoritePokemon" SortExpression="FavoritePokemon" />
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
            </Columns>
            <%--<selectedrowstyle BackColor="lightblue"/>--%>
            
        </asp:GridView>

    </div>

        <div>
            <h2>Change information</h2>
            <asp:Label ID="LabelUpdateFeedbackPositive" runat="server" CssClass="successcolor" Font-Size="20px"></asp:Label>

            <asp:Label ID="LabelUpdateFeedbackNegative" runat="server" CssClass="errorcolor" Font-Size="20px"></asp:Label>
            <br />

            <asp:Label ID="LabelUpdateInfoFor" runat="server"></asp:Label>
            <asp:Label ID="LabelUpdateInfoAlias" runat="server"></asp:Label>
            <asp:Label ID="LabelUpdateShowType" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="TextBoxUpdateAlias" runat="server" Enabled="False"></asp:TextBox>
            <asp:Label ID="LabelUpdateAlias" runat="server" Text="Alias"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUpdateAlias" EnableClientScript="False" ErrorMessage="Fill in alias please" CssClass="errorcolor"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="TextBoxUpdateName" runat="server" Enabled="False"></asp:TextBox>
            <asp:Label ID="LabelUpdateName" runat="server" Text="Name"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxUpdateName" EnableClientScript="False" ErrorMessage="Fill in name please" CssClass="errorcolor"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="TextBoxUpdateAge" runat="server" TextMode="Number" Enabled="False"></asp:TextBox>
            <asp:Label ID="LabelUpdateAge" runat="server" Text="Age"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxUpdateAge" EnableClientScript="False" ErrorMessage="Fill in age please" CssClass="errorcolor"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="LabelUpdateGender" runat="server" Text="Gender"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="RadioButtonListUpdate" EnableClientScript="False" ErrorMessage="Choose your gender please" CssClass="errorcolor"></asp:RequiredFieldValidator>
            <asp:RadioButtonList ID="RadioButtonListUpdate" runat="server" Enabled="False">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
            <asp:TextBox ID="TextBoxUpdateEmail" runat="server" TextMode="Email" Enabled="False"></asp:TextBox>
            <asp:Label ID="LabelUpdateEmail" runat="server" Text="Email"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxUpdateEmail" EnableClientScript="False" ErrorMessage="Fill in email please" CssClass="errorcolor"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxUpdateEmail" CssClass="errorcolor" EnableClientScript="False" ErrorMessage="Please write your email properly" ValidationExpression="[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"></asp:RegularExpressionValidator>
            <br />
            <asp:TextBox ID="TextBoxUpdatePassword" runat="server" CssClass="passwordstyle" Enabled="False"></asp:TextBox>
            <asp:Label ID="LabelUpdatePassword" runat="server" Text="Password"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxUpdatePassword" EnableClientScript="False" ErrorMessage="Fill in password please" CssClass="errorcolor"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="TextBoxUpdateFavorite" runat="server" Enabled="False"></asp:TextBox>
            <asp:Label ID="LabelUpdateFavorite" runat="server" Text="Favorite Pokémon"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorUpdateFavorite" runat="server" ControlToValidate="TextBoxUpdateFavorite" CssClass="errorcolor" EnableClientScript="False" Enabled="False" ErrorMessage="Please choose your favorite Pokémon"></asp:RequiredFieldValidator>
            <br />
            
            <br />
            <asp:Button ID="ButtonUpdate" runat="server" Text="Update" CssClass="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--accent" OnClick="ButtonUpdate_Click" Enabled="False" />
            <br />

        </div>
    </form>
</asp:Content>

