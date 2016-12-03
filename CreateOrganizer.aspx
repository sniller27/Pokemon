<%@ Page Title="Create Organizer" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="CreateOrganizer.aspx.cs" Inherits="CreateOrganizer" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <h2>Sign up</h2>
    <form id="createorganizerform" runat="server">
        <div>
        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
            <asp:TextBox ID="TextBoxAlias" runat="server" class="mdl-textfield__input"></asp:TextBox>
            <asp:Label ID="LabelAlias" runat="server" Text="Alias" AssociatedControlId="TextBoxAlias" class="mdl-textfield__label"></asp:Label>
        </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxAlias" EnableClientScript="False" ErrorMessage="Fill in alias please" CssClass="errorcolor"></asp:RequiredFieldValidator>
        <br />
        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
            <asp:TextBox ID="TextBoxName" runat="server" class="mdl-textfield__input"></asp:TextBox>
            <asp:Label ID="LabelName" runat="server" Text="Name" AssociatedControlId="TextBoxName" class="mdl-textfield__label"></asp:Label>
        </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxName" EnableClientScript="False" ErrorMessage="Fill in name please" CssClass="errorcolor"></asp:RequiredFieldValidator>
        <br />
        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
            <asp:TextBox ID="TextBoxAge" runat="server" TextMode="Number" class="mdl-textfield__input"></asp:TextBox>
            <asp:Label ID="LabelAge" runat="server" Text="Age" AssociatedControlId="TextBoxAge" class="mdl-textfield__label"></asp:Label>
        </div>
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
        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
            <asp:TextBox ID="TextBoxEmail" runat="server" TextMode="Email" class="mdl-textfield__input"></asp:TextBox>
            <asp:Label ID="LabelEmail" runat="server" Text="Email" AssociatedControlId="TextBoxEmail" class="mdl-textfield__label"></asp:Label>
        </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxEmail" EnableClientScript="False" ErrorMessage="Fill in your email please" CssClass="errorcolor"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please write your email properly" ValidationExpression="[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" CssClass="errorcolor" ControlToValidate="TextBoxEmail" EnableClientScript="False"></asp:RegularExpressionValidator>
        <br />
        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
            <asp:TextBox ID="TextBoxPassword" runat="server" class="mdl-textfield__input passwordstyle"></asp:TextBox>
            <asp:Label ID="LabelPassword" runat="server" Text="Password" AssociatedControlId="TextBoxPassword" class="mdl-textfield__label"></asp:Label>
        </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxPassword" EnableClientScript="False" ErrorMessage="Fill in your password please" CssClass="errorcolor"></asp:RequiredFieldValidator>
        <br />
        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
            <asp:TextBox ID="TextBoxPasswordRepeat" runat="server" class="mdl-textfield__input passwordstyle passwordstyle"></asp:TextBox>
            <asp:Label ID="LabelPasswordRepeat" runat="server" Text="Password confirmation" AssociatedControlId="TextBoxPasswordRepeat" class="mdl-textfield__label"></asp:Label>
        </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBoxPasswordRepeat" EnableClientScript="False" ErrorMessage="Repeat your password please" CssClass="errorcolor"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxPasswordRepeat" ControlToValidate="TextBoxPassword" EnableClientScript="False" ErrorMessage="Passwords must be identical" CssClass="errorcolor"></asp:CompareValidator>
        <br />
        <div class="mdl-select mdl-js-select mdl-select--floating-label">
            <asp:label runat="server" text="Role" ID="LabelChooseRole" AssociatedControlId="DropdownlistCreateParticipant"></asp:label>
            <asp:dropdownlist runat="server" ID="DropdownlistCreateParticipant" AutoPostBack="True" OnSelectedIndexChanged="Unnamed1_SelectedIndexChanged" class="mdl-select__input">
                <asp:ListItem>Organizer</asp:ListItem>
                <asp:ListItem>Pokehunter</asp:ListItem>
            </asp:dropdownlist>
        </div>
        <br />
        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
            <asp:TextBox ID="TextBoxFavorite" runat="server" Enabled="False" class="mdl-textfield__input"></asp:TextBox>
            <asp:Label ID="LabelFavoriteAdd" runat="server" Text="Favorite Pokémon" AssociatedControlId="TextBoxFavorite" class="mdl-textfield__label"></asp:Label>
        </div>
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


<asp:Content ID="Content1" ContentPlaceHolderID="afterscripts" Runat="Server">
    <script>

        function MaterialSelect(element) {
            'use strict';

            this.element_ = element;
            this.maxRows = this.Constant_.NO_MAX_ROWS;
            // Initialize instance.
            this.init();
        }

        MaterialSelect.prototype.Constant_ = {
            NO_MAX_ROWS: -1,
            MAX_ROWS_ATTRIBUTE: 'maxrows'
        };

        MaterialSelect.prototype.CssClasses_ = {
            LABEL: 'mdl-textfield__label',
            INPUT: 'mdl-select__input',
            IS_DIRTY: 'is-dirty',
            IS_FOCUSED: 'is-focused',
            IS_DISABLED: 'is-disabled',
            IS_INVALID: 'is-invalid',
            IS_UPGRADED: 'is-upgraded'
        };

        MaterialSelect.prototype.onKeyDown_ = function (event) {
            'use strict';

            var currentRowCount = event.target.value.split('\n').length;
            if (event.keyCode === 13) {
                if (currentRowCount >= this.maxRows) {
                    event.preventDefault();
                }
            }
        };

        MaterialSelect.prototype.onFocus_ = function (event) {
            'use strict';

            this.element_.classList.add(this.CssClasses_.IS_FOCUSED);
        };

        MaterialSelect.prototype.onBlur_ = function (event) {
            'use strict';

            this.element_.classList.remove(this.CssClasses_.IS_FOCUSED);
        };

        MaterialSelect.prototype.updateClasses_ = function () {
            'use strict';
            this.checkDisabled();
            this.checkValidity();
            this.checkDirty();
        };

        MaterialSelect.prototype.checkDisabled = function () {
            'use strict';
            if (this.input_.disabled) {
                this.element_.classList.add(this.CssClasses_.IS_DISABLED);
            } else {
                this.element_.classList.remove(this.CssClasses_.IS_DISABLED);
            }
        };

        MaterialSelect.prototype.checkValidity = function () {
            'use strict';
            if (this.input_.validity.valid) {
                this.element_.classList.remove(this.CssClasses_.IS_INVALID);
            } else {
                this.element_.classList.add(this.CssClasses_.IS_INVALID);
            }
        };

        MaterialSelect.prototype.checkDirty = function () {
            'use strict';
            if (this.input_.value && this.input_.value.length > 0) {
                this.element_.classList.add(this.CssClasses_.IS_DIRTY);
            } else {
                this.element_.classList.remove(this.CssClasses_.IS_DIRTY);
            }
        };

        MaterialSelect.prototype.disable = function () {
            'use strict';

            this.input_.disabled = true;
            this.updateClasses_();
        };

        MaterialSelect.prototype.enable = function () {
            'use strict';

            this.input_.disabled = false;
            this.updateClasses_();
        };

        MaterialSelect.prototype.change = function (value) {
            'use strict';

            if (value) {
                this.input_.value = value;
            }
            this.updateClasses_();
        };

        MaterialSelect.prototype.init = function () {
            'use strict';

            if (this.element_) {
                this.label_ = this.element_.querySelector('.' + this.CssClasses_.LABEL);
                this.input_ = this.element_.querySelector('.' + this.CssClasses_.INPUT);

                if (this.input_) {
                    if (this.input_.hasAttribute(this.Constant_.MAX_ROWS_ATTRIBUTE)) {
                        this.maxRows = parseInt(this.input_.getAttribute(
                            this.Constant_.MAX_ROWS_ATTRIBUTE), 10);
                        if (isNaN(this.maxRows)) {
                            this.maxRows = this.Constant_.NO_MAX_ROWS;
                        }
                    }

                    this.boundUpdateClassesHandler = this.updateClasses_.bind(this);
                    this.boundFocusHandler = this.onFocus_.bind(this);
                    this.boundBlurHandler = this.onBlur_.bind(this);
                    this.input_.addEventListener('input', this.boundUpdateClassesHandler);
                    this.input_.addEventListener('focus', this.boundFocusHandler);
                    this.input_.addEventListener('blur', this.boundBlurHandler);

                    if (this.maxRows !== this.Constant_.NO_MAX_ROWS) {
                        // TODO: This should handle pasting multi line text.
                        // Currently doesn't.
                        this.boundKeyDownHandler = this.onKeyDown_.bind(this);
                        this.input_.addEventListener('keydown', this.boundKeyDownHandler);
                    }

                    this.updateClasses_();
                    this.element_.classList.add(this.CssClasses_.IS_UPGRADED);
                }
            }
        };

        MaterialSelect.prototype.mdlDowngrade_ = function () {
            'use strict';
            this.input_.removeEventListener('input', this.boundUpdateClassesHandler);
            this.input_.removeEventListener('focus', this.boundFocusHandler);
            this.input_.removeEventListener('blur', this.boundBlurHandler);
            if (this.boundKeyDownHandler) {
                this.input_.removeEventListener('keydown', this.boundKeyDownHandler);
            }
        };

        // The component registers itself. It can assume componentHandler is available
        // in the global scope.
        componentHandler.register({
            constructor: MaterialSelect,
            classAsString: 'MaterialSelect',
            cssClass: 'mdl-js-select',
            widget: true
        });

    </script>
</asp:Content>