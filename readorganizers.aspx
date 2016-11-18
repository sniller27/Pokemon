<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.master" AutoEventWireup="true" CodeFile="readorganizers.aspx.cs" Inherits="readorganizers" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LabelReadOrganizersInfo" runat="server"></asp:Label>
    
        <br />
        <asp:TextBox ID="TextBoxReadOrganizers" runat="server" Height="145px" TextMode="MultiLine" Width="734px"></asp:TextBox>
    
    </div>
    </form>
</asp:Content>

