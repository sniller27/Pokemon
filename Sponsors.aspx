<%@ Page Title="" Language="C#" MasterPageFile="~/Loginmenu.master" AutoEventWireup="true" CodeFile="Sponsors.aspx.cs" Inherits="Sponsors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderhead" Runat="Server">

    <%--important javascript for fileupload --%>
    <script type="text/javascript">
    function UploadFile(fileUpload) {
        if (fileUpload.value != '') {
            document.getElementById("<%=btnUpload.ClientID %>").click();
        }
    }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent1" Runat="Server">

    <div class="row">
        <div class="col-md-6">
            <h2>New sponsor</h2>
            <asp:Label ID="LabelAddPosFeedback" runat="server" CssClass="succescolor"></asp:Label>
            <asp:Label ID="LabelAddNegFeedback" runat="server" CssClass="errorcolor"></asp:Label>
            <br />
            <asp:TextBox ID="TextBoxAddCompanyName" runat="server"></asp:TextBox><asp:Label ID="LabelAddCompanyName" runat="server" Text="Company name"></asp:Label>
            <br />
            <asp:TextBox ID="TextBoxAddCompanyWebsite" runat="server"></asp:TextBox><asp:Label ID="LabelAddCompanyWebsite" runat="server" Text="Company website"></asp:Label>
            <br />
            <p>Company logo</p>
            <asp:Image ID="ImageCreate" runat="server" CssClass="mypokemonimage" />
            <asp:Label ID="LabelCreateChooseImage" runat="server"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUploadCreateImage" runat="server" />
            <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="Upload" Style="display: none" />
            <br />
            <asp:Button ID="ButtonCreateSponsor" runat="server" Text="Create" OnClick="ButtonCreateSponsor_Click" />
        </div>
        <div class="col-md-6">
            <h2>Edit sponsor</h2>
            <asp:Label ID="LabelUpPosFeedback" runat="server" CssClass="succescolor"></asp:Label>
            <asp:Label ID="LabelUpNegFeedback" runat="server" CssClass="errorcolor"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownListUpdateChooseSponser" runat="server" AutoPostBack="True"></asp:DropDownList>
            <br />
            <asp:TextBox ID="TextBoxUpdateCompanyName" runat="server"></asp:TextBox><asp:Label ID="LabelUpdateCompanyName" runat="server" Text="Company name"></asp:Label>
            <br />
            <asp:TextBox ID="TextBoxUpdateCompanyWebsite" runat="server"></asp:TextBox><asp:Label ID="LabelUpdateCompanyWebsite" runat="server" Text="Company website"></asp:Label>
            <br />
            <p>Company logo</p>
            <asp:Image ID="ImageUpdate" runat="server" CssClass="mypokemonimage" />
            <asp:Label ID="LabelUpdateChooseImage" runat="server"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUploadUpdateImage" runat="server" />
            <br />
            <asp:Button ID="ButtonUpdateSponsor" runat="server" Text="Update" OnClick="ButtonUpdateSponsor_Click" />

            <hr />
            <p>Warning: this will delete selected sponsor!</p>
            <asp:Button ID="ButtonDelete" runat="server" Text="Delete" CssClass="btn-danger" OnClick="ButtonDelete_Click" />
        </div>
    </div>

</asp:Content>

