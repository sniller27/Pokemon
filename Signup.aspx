<%@ Page Title="" Language="C#" MasterPageFile="~/Mastermenu.master" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="Signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">

    

    <div class="container">
        <div class="col-md-12">
            <asp:Label ID="Label1" runat="server" Text="Sign Up" Font-Size="30px"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            Alias<br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            Name<br />
            Gender<asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
            <asp:textbox runat="server"></asp:textbox>
            Age<br />
            <asp:textbox runat="server"></asp:textbox>
            Email<br />
            <asp:textbox runat="server"></asp:textbox>
            Password<br />
            <asp:textbox runat="server"></asp:textbox>
            Confirm password<br />
            <asp:button runat="server" text="Button" />

        </div>
    </div>

</asp:Content>

