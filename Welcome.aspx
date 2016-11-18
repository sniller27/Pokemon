<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>Welcome</h2>
         
        <a href="readorganizers.aspx">Organizers</a>
        <a href="CreateOrganizer.aspx">Create organizer</a>
        <a href="Default2.aspx">Pokehunters</a>
        <a href="Default2.aspx">Create pokehunter</a>
            
<%--        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton1_Click">Organizers</asp:LinkButton>
        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton1_Click">Create organizer</asp:LinkButton>
        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton1_Click">Pokehunters</asp:LinkButton>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Create pokehunter</asp:LinkButton>--%>

        <!--
        <asp:HyperLink ID="HyperLink2" runat="server">Organizers</asp:HyperLink>
        <asp:HyperLink ID="HyperLink3" runat="server">Create organizer</asp:HyperLink>
        <asp:HyperLink ID="HyperLink4" runat="server">Pokehunters</asp:HyperLink>
        <asp:HyperLink ID="HyperLink1" runat="server">Create pokehunter</asp:HyperLink>
        -->
    </div>
    </form>
</body>
</html>
