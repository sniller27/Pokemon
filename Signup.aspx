<%@ Page Title="Sign up" Language="C#" MasterPageFile="~/Loginmenu.master" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="Signup" %>







<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderhead" Runat="Server">

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ChildContent1" Runat="Server">

    <div class="container">
        <div class="col-md-12">
            <asp:Label ID="Label1" runat="server" Text="Sign Up" Font-Size="30px"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBoxSignupAlias" runat="server"></asp:TextBox>
            Alias<br />
            <asp:TextBox ID="TextBoxSignupName" runat="server"></asp:TextBox>
            Name<br />
            Gender
            <asp:RadioButtonList ID="RadioButtonListSignupGender" runat="server">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
            <asp:textbox runat="server" ID="TextBoxSignupAge"></asp:textbox>
            Age<br />
            <asp:textbox runat="server" ID="TextBoxSignupEmail"></asp:textbox>
            Email<br />
            <asp:textbox runat="server" ID="TextBoxSignupPassword"></asp:textbox>
            Password<br />
            <asp:textbox runat="server" ID="TextBoxSignupPasswordConfirm"></asp:textbox>
            Confirm password
            <br />
            <br />
            <asp:button runat="server" text="Button" ID="buttonsignup" OnClick="buttonsignup_Click" class="btn btn-primary" />
            <br />
            <asp:Label ID="labelsignupfeedback" runat="server"></asp:Label>
        </div>
    </div>

</asp:Content>

