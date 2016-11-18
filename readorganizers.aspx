<%@ Page Title="Organizers" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="readorganizers.aspx.cs" Inherits="readorganizers" %>

<asp:Content ID="Content4" ContentPlaceHolderID="content" Runat="Server">
    <h2>Organizers</h2>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LabelReadOrganizersInfo" runat="server"></asp:Label>
    
        <br />
        <asp:TextBox ID="TextBoxReadOrganizers" runat="server" Height="145px" TextMode="MultiLine" Width="734px"></asp:TextBox>
    
    </div>
    </form>
</asp:Content>

