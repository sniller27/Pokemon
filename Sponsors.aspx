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
            <div class="form-group">
                <asp:TextBox ID="TextBoxAddCompanyName" runat="server" class="form-control mediumfield"></asp:TextBox><asp:Label ID="LabelAddCompanyName" runat="server" Text="Company name"></asp:Label>
            </div>
            <br />
            <div class="form-group">
                <asp:TextBox ID="TextBoxAddCompanyWebsite" runat="server" class="form-control mediumfield"></asp:TextBox><asp:Label ID="LabelAddCompanyWebsite" runat="server" Text="Company website"></asp:Label>
            </div>
            <br />
            <p>Company logo</p>
            <div class="mypokemonimagebox">
                <asp:Image ID="ImageCreate" runat="server" CssClass="mypokemonimage" />
            </div>
            <asp:Label ID="LabelCreateChooseImage" runat="server"></asp:Label>
            <br />
            <span class="btn btn-default btn-file">
                Choose file<asp:FileUpload ID="FileUploadCreateImage" runat="server" />
            </span>
            <br />
            <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="Upload" Style="display: none" />
            <br />
            <asp:Button ID="ButtonCreateSponsor" runat="server" Text="Create" OnClick="ButtonCreateSponsor_Click" CssClass="btn btn-primary" />
        </div>
        <div class="col-md-6">
            <h2>Edit sponsor</h2>
            <asp:Label ID="LabelUpPosFeedback" runat="server" CssClass="succescolor"></asp:Label>
            <asp:Label ID="LabelUpNegFeedback" runat="server" CssClass="errorcolor"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownListUpdateChooseSponser" runat="server" AutoPostBack="True" class="form-control mydropdown"></asp:DropDownList>
            <br />
            <div class="form-group">
                <asp:TextBox ID="TextBoxUpdateCompanyName" runat="server" class="form-control mediumfield"></asp:TextBox><asp:Label ID="LabelUpdateCompanyName" runat="server" Text="Company name"></asp:Label>
            </div>
            <br />
            <div class="form-group">
                <asp:TextBox ID="TextBoxUpdateCompanyWebsite" runat="server" class="form-control mediumfield"></asp:TextBox><asp:Label ID="LabelUpdateCompanyWebsite" runat="server" Text="Company website"></asp:Label>
            </div>
            <br />
            <p>Company logo</p>
            <div class="mypokemonimagebox">
                <asp:Image ID="ImageUpdate" runat="server" CssClass="mypokemonimage" />
            </div>
            <asp:Label ID="LabelUpdateChooseImage" runat="server"></asp:Label>
            <br />
            <span class="btn btn-default btn-file">
                Choose file<asp:FileUpload ID="FileUploadUpdateImage" runat="server" />
            </span>
            <br />
            <br />
            <asp:Button ID="ButtonUpdateSponsor" runat="server" Text="Update" OnClick="ButtonUpdateSponsor_Click" CssClass="btn btn-primary" />

            <hr />
            <p>Warning: this will delete selected sponsor!</p>
            <asp:Button ID="ButtonDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="ButtonDelete_Click" />
        </div>
    </div>

</asp:Content>

