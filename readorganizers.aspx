﻿<%@ Page Title="Participants" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="readorganizers.aspx.cs" Inherits="readorganizers" %>

<asp:Content ID="Content4" ContentPlaceHolderID="content" Runat="Server">
    
    <div class="boxmodelbox bigbox">
        <h2>Participants</h2>
        <br />
        <form id="participantform" runat="server">
   
            <div>
                <asp:Label ID="LabelUpdateFeedbackPositive" runat="server" CssClass="successcolor" Font-Size="20px"></asp:Label>
                <asp:Label ID="LabelUpdateFeedbackNegative" runat="server" CssClass="errorcolor" Font-Size="20px"></asp:Label>
                <h3>Organizers</h3>
    
                <asp:Label ID="LabelReadOrganizersInfo" runat="server"></asp:Label>

                <asp:GridView ID="GridViewOrganizers" runat="server" Width="730px" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewOrganizers_SelectedIndexChanged" OnRowDeleting="GridViewOrganizers_RowDeleting" datakeynames="alias">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="mdl-button mdl-js-button mdl-button--raised mdl-button--accent mdl-js-ripple-effect" />
                        <asp:BoundField DataField="alias" HeaderText="Alias" SortExpression="alias" />
                        <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                        <asp:BoundField DataField="age" HeaderText="Age" SortExpression="age" />
                        <asp:BoundField DataField="gender" HeaderText="Gender" SortExpression="gender" />
                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                        <asp:BoundField DataField="password" HeaderText="Password" SortExpression="password" />
                        <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ControlStyle-CssClass="mdl-button mdl-js-button mdl-button--raised" />
                    </Columns>
                </asp:GridView>
            
                <br />

                <h3>Pokehunters</h3>
                <asp:Label ID="LabelReadPokehuntersInfo" runat="server"></asp:Label>

                <asp:GridView ID="GridViewPokehunters" runat="server" Width="730px" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewPokehunters_SelectedIndexChanged" OnRowDeleting="GridViewPokehunters_RowDeleting" datakeynames="alias">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="mdl-button mdl-js-button mdl-button--raised mdl-button--accent mdl-js-ripple-effect" />
                        <asp:BoundField DataField="alias" HeaderText="Alias" SortExpression="alias" />
                        <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                        <asp:BoundField DataField="age" HeaderText="Age" SortExpression="age" />
                        <asp:BoundField DataField="gender" HeaderText="Gender" SortExpression="gender" />
                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                        <asp:BoundField DataField="password" HeaderText="Password" SortExpression="password" />
                        <asp:BoundField DataField="FavoritePokemon" HeaderText="Favorite Pokemon" SortExpression="FavoritePokemon" />
                        <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ControlStyle-CssClass="mdl-button mdl-js-button mdl-button--raised" />
                    </Columns>
                </asp:GridView>
            </div>

            <br />

            <div class="whitebackground boxmodelbox smallbox mdl-shadow--2dp">
                <h2>Change information</h2>
                <br />

                <asp:Label ID="LabelUpdateInfoFor" runat="server"></asp:Label>
                <asp:Label ID="LabelUpdateInfoAlias" runat="server"></asp:Label>
                <asp:Label ID="LabelUpdateShowType" runat="server"></asp:Label>
                <br />
                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label longtextfield">
                    <asp:TextBox ID="TextBoxUpdateAlias" runat="server" class="mdl-textfield__input"></asp:TextBox>
                    <asp:Label ID="LabelUpdateAlias" runat="server" Text="Alias" AssociatedControlId="TextBoxUpdateAlias" class="mdl-textfield__label"></asp:Label>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUpdateAlias" EnableClientScript="False" ErrorMessage="Fill in alias please" CssClass="errorcolor"></asp:RequiredFieldValidator>
                <br />
                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label longtextfield">
                    <asp:TextBox ID="TextBoxUpdateName" runat="server" class="mdl-textfield__input"></asp:TextBox>
                    <asp:Label ID="LabelUpdateName" runat="server" Text="Name" AssociatedControlId="TextBoxUpdateName" class="mdl-textfield__label"></asp:Label>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxUpdateName" EnableClientScript="False" ErrorMessage="Fill in name please" CssClass="errorcolor"></asp:RequiredFieldValidator>
                <br />
                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label longtextfield">
                    <asp:TextBox ID="TextBoxUpdateAge" runat="server" TextMode="Number" class="mdl-textfield__input"></asp:TextBox>
                    <asp:Label ID="LabelUpdateAge" runat="server" Text="Age" AssociatedControlId="TextBoxUpdateAge" class="mdl-textfield__label"></asp:Label>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxUpdateAge" EnableClientScript="False" ErrorMessage="Fill in age please" CssClass="errorcolor"></asp:RequiredFieldValidator>
                <br />

                <div id="genderdiv" runat="server">
                
                    <label class="radio" id="labelmale" runat="server">
                        <input id="radiomale" type="radio" name="radios" runat="server" />
                        <span class="outer"><span class="inner"></span></span>Male
                    </label>
                    <asp:HiddenField ID="HiddenFieldmale" runat="server" Value="Male" />

                    <label class="radio" id="labelfemale" runat="server">
                        <input id="radiofemale" type="radio" name="radios" runat="server" />
                        <span class="outer"><span class="inner"></span></span>Female
                    </label>
                    <asp:HiddenField ID="HiddenFieldfemale" runat="server" Value="Female" />
                
                </div>

                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label longtextfield">
                    <asp:TextBox ID="TextBoxUpdateEmail" runat="server" TextMode="Email" class="mdl-textfield__input"></asp:TextBox>
                    <asp:Label ID="LabelUpdateEmail" runat="server" Text="Email" AssociatedControlId="TextBoxUpdateEmail" class="mdl-textfield__label"></asp:Label>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxUpdateEmail" EnableClientScript="False" ErrorMessage="Fill in email please" CssClass="errorcolor"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxUpdateEmail" CssClass="errorcolor" EnableClientScript="False" ErrorMessage="Please write your email properly" ValidationExpression="[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"></asp:RegularExpressionValidator>
                <br />
                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label longtextfield">
                    <asp:TextBox ID="TextBoxUpdatePassword" runat="server" class="mdl-textfield__input"></asp:TextBox>
                    <asp:Label ID="LabelUpdatePassword" runat="server" Text="Password" AssociatedControlId="TextBoxUpdatePassword" class="mdl-textfield__label"></asp:Label>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxUpdatePassword" EnableClientScript="False" ErrorMessage="Fill in password please" CssClass="errorcolor"></asp:RequiredFieldValidator>
                <br />
                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label longtextfield">
                    <asp:TextBox ID="TextBoxUpdateFavorite" runat="server" class="mdl-textfield__input"></asp:TextBox>
                    <asp:Label ID="LabelUpdateFavorite" runat="server" Text="Favorite Pokémon" AssociatedControlId="TextBoxUpdateFavorite" class="mdl-textfield__label"></asp:Label>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUpdateFavorite" runat="server" ControlToValidate="TextBoxUpdateFavorite" CssClass="errorcolor" EnableClientScript="False" Enabled="False" ErrorMessage="Please choose your favorite Pokémon"></asp:RequiredFieldValidator>
                <br />
            
                <br />
                <asp:Button ID="ButtonUpdate" runat="server" Text="Update" CssClass="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--accent" OnClick="ButtonUpdate_Click" Enabled="False" />
                <br />
            </div>
        </form>

    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="afterscripts" Runat="Server">
    <script>

        //apply classes to tables
        document.getElementById("content_GridViewPokehunters").className = 'mdl-data-table mdl-js-data-table mdl-shadow--2dp';
        document.getElementById("content_GridViewOrganizers").className = 'mdl-data-table mdl-js-data-table mdl-shadow--2dp';

    </script>
</asp:Content>