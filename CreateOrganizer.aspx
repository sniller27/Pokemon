<%@ Page Title="Sign up" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="CreateOrganizer.aspx.cs" Inherits="CreateOrganizer" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <div class="contentcenter mdl-shadow--2dp">
        <h2>Sign up</h2>
        <form id="createorganizerform" runat="server">
            <div>
                <asp:Label ID="LabelAddOrganizerFeedbackPositive" runat="server" CssClass="successcolor"></asp:Label>
                <asp:Label ID="LabelAddOrganizerFeedbackNegative" runat="server" CssClass="errorcolor"></asp:Label>

                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label longtextfield">
                    <asp:TextBox ID="TextBoxAlias" runat="server" class="mdl-textfield__input"></asp:TextBox>
                    <asp:Label ID="LabelAlias" runat="server" Text="Alias" AssociatedControlId="TextBoxAlias" class="mdl-textfield__label"></asp:Label>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxAlias" EnableClientScript="False" ErrorMessage="Fill in alias please" CssClass="errorcolor"></asp:RequiredFieldValidator>
                <br />
                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label longtextfield">
                    <asp:TextBox ID="TextBoxName" runat="server" class="mdl-textfield__input"></asp:TextBox>
                    <asp:Label ID="LabelName" runat="server" Text="Name" AssociatedControlId="TextBoxName" class="mdl-textfield__label"></asp:Label>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxName" EnableClientScript="False" ErrorMessage="Fill in name please" CssClass="errorcolor"></asp:RequiredFieldValidator>
                <br />
                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label longtextfield">
                    <asp:TextBox ID="TextBoxAge" runat="server" TextMode="Number" class="mdl-textfield__input"></asp:TextBox>
                    <asp:Label ID="LabelAge" runat="server" Text="Age" AssociatedControlId="TextBoxAge" class="mdl-textfield__label"></asp:Label>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxAge" EnableClientScript="False" ErrorMessage="Fill in age please" CssClass="errorcolor"></asp:RequiredFieldValidator>
                <br />

                 <%--HER--%>
                <asp:Label ID="LabelGender" runat="server" Text="Gender"></asp:Label>
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


                <br />
                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label longtextfield">
                    <asp:TextBox ID="TextBoxEmail" runat="server" TextMode="Email" class="mdl-textfield__input"></asp:TextBox>
                    <asp:Label ID="LabelEmail" runat="server" Text="Email" AssociatedControlId="TextBoxEmail" class="mdl-textfield__label"></asp:Label>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxEmail" EnableClientScript="False" ErrorMessage="Fill in your email please" CssClass="errorcolor"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please write your email properly" ValidationExpression="[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" CssClass="errorcolor" ControlToValidate="TextBoxEmail" EnableClientScript="False"></asp:RegularExpressionValidator>
                <br />
                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label longtextfield">
                    <asp:TextBox ID="TextBoxPassword" runat="server" class="mdl-textfield__input passwordstyle"></asp:TextBox>
                    <asp:Label ID="LabelPassword" runat="server" Text="Password" AssociatedControlId="TextBoxPassword" class="mdl-textfield__label"></asp:Label>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxPassword" EnableClientScript="False" ErrorMessage="Fill in your password please" CssClass="errorcolor"></asp:RequiredFieldValidator>
                <br />
                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label longtextfield">
                    <asp:TextBox ID="TextBoxPasswordRepeat" runat="server" class="mdl-textfield__input passwordstyle passwordstyle"></asp:TextBox>
                    <asp:Label ID="LabelPasswordRepeat" runat="server" Text="Password confirmation" AssociatedControlId="TextBoxPasswordRepeat" class="mdl-textfield__label"></asp:Label>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBoxPasswordRepeat" EnableClientScript="False" ErrorMessage="Repeat your password please" CssClass="errorcolor"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxPasswordRepeat" ControlToValidate="TextBoxPassword" EnableClientScript="False" ErrorMessage="Passwords must be identical" CssClass="errorcolor"></asp:CompareValidator>
                <br />
                <div class="mdl-select mdl-js-select mdl-select--floating-label leftalign longtextfield">
                    <asp:label runat="server" text="Role" ID="LabelChooseRole" AssociatedControlId="DropdownlistCreateParticipant"></asp:label>
                    <asp:dropdownlist runat="server" ID="DropdownlistCreateParticipant" AutoPostBack="True" OnSelectedIndexChanged="Unnamed1_SelectedIndexChanged" class="mdl-select__input">
                        <asp:ListItem>Organizer</asp:ListItem>
                        <asp:ListItem>Pokehunter</asp:ListItem>
                    </asp:dropdownlist>
                </div>
                <br />
                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label longtextfield">
                    <asp:TextBox ID="TextBoxFavorite" runat="server" class="mdl-textfield__input"></asp:TextBox>
                    <asp:Label ID="LabelFavoriteAdd" runat="server" Text="Favorite Pokémon" AssociatedControlId="TextBoxFavorite" class="mdl-textfield__label"></asp:Label>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCreateFavorite" runat="server" ControlToValidate="TextBoxFavorite" CssClass="errorcolor" EnableClientScript="False" Enabled="False" ErrorMessage="Please choose your favorite Pokémon"></asp:RequiredFieldValidator>
                <br />
                <br />
                <br />
                <asp:Button ID="ButtonCreateOrganizer" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--accent" runat="server" Text="Sign up" OnClick="ButtonCreateOrganizer_Click" />
                <br />
                <br />
            
            </div>
        </form>
    </div>

</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="afterscripts" Runat="Server">

    <%--extended script for dropdownlist (apparently not necessary)--%>
    <%--<script src="js/Dropdownlist.js"></script>--%>

</asp:Content>