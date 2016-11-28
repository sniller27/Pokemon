<%@ Page Title="Sign up" Language="C#" MasterPageFile="~/Loginmenu.master" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="Signup" %>







<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderhead" Runat="Server">

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ChildContent1" Runat="Server">

    <div class="container">
        <div class="col-md-12">
            <asp:Label ID="Label1" runat="server" Text="Sign Up" Font-Size="30px"></asp:Label>
            <br />
            <br />
            <div class="form-group">
                <asp:TextBox ID="TextBoxSignupAlias" runat="server" CssClass="form-control mediumfield"></asp:TextBox>
                Alias
            </div>
            <div class="form-group">
                <asp:TextBox ID="TextBoxSignupName" runat="server" CssClass="form-control mediumfield"></asp:TextBox>
                Name    
            </div>
            Gender
            <asp:RadioButtonList ID="RadioButtonListSignupGender" runat="server">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>

            <div class="form-group">
                <asp:textbox runat="server" ID="TextBoxSignupAge" CssClass="form-control mediumfield"></asp:textbox>
                Age
            </div>

            <div class="form-group">
                <asp:textbox runat="server" ID="TextBoxSignupEmail" CssClass="form-control mediumfield"></asp:textbox>
                Email
            </div>

            <div class="form-group">
            <asp:textbox runat="server" ID="TextBoxSignupPassword" CssClass="form-control mediumfield"></asp:textbox>
            Password    
            </div>

            <div class="form-group">
            <asp:textbox runat="server" ID="TextBoxSignupPasswordConfirm" CssClass="form-control mediumfield" TextMode="Password"></asp:textbox>
            Confirm password 
            </div>

            <br />

            <asp:button runat="server" text="Button" ID="buttonsignup" OnClick="buttonsignup_Click" class="btn btn-primary" />
            <br />
            <asp:Label ID="labelsignupfeedback" runat="server"></asp:Label>
        </div>
    </div>

</asp:Content>

