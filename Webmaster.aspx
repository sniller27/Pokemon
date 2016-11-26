<%@ Page Title="" Language="C#" MasterPageFile="~/Loginmenu.master" AutoEventWireup="true" CodeFile="Webmaster.aspx.cs" Inherits="Webmaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">

    <asp:Label ID="Labelpositivefeedback" runat="server"></asp:Label>
    <asp:Label ID="Labelnegativefeedback" runat="server"></asp:Label>
    <h2>Create Pokemon</h2>
    <asp:TextBox ID="TextBoxNumber" runat="server"></asp:TextBox><asp:Label ID="LabelNumber" runat="server" Text="Pokedex number"></asp:Label>
    <br />
    <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox><asp:Label ID="LabelName" runat="server" Text="Pokémon name"></asp:Label>
    <br />
    <asp:TextBox ID="TextBoxNextEvolution" runat="server"></asp:TextBox><asp:Label ID="LabelNextEvolution" runat="server" Text="Next evolution (empty field if none)"></asp:Label>
    <br />
    <asp:TextBox ID="TextBoxType" runat="server"></asp:TextBox><asp:Label ID="LabelType" runat="server" Text="Type"></asp:Label>
    <br />
    <br />
    <asp:Label ID="LabelChooseImage" runat="server" Text="Image"></asp:Label>
    <br />
    <asp:Image ID="ImageToUpload" runat="server" Height="152px" Width="189px" />
    <br />
    <br />
    <asp:FileUpload ID="FileUploadImage" runat="server" />
    <br />
    <br />
    <asp:Button ID="ButtonCreatePokemon" runat="server" Text="Create" OnClick="ButtonCreatePokemon_Click" />
    <br />
    <br />
    <br />
    <br />
    <br />

     <img id="image_upload_preview" src="http://placehold.it/100x100" alt="your image" />
    <input type='file' id="inputFile" />

    <%--Show uploaded image--%>
    <script>
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#image_upload_preview').attr('src', e.target.result);
                }

                reader.readAsDataURL(input.files[0]);
            }
        }

        $("#inputFile").change(function () {
            readURL(this);
        });
    </script>
</asp:Content>

