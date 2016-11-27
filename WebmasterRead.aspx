<%@ Page Title="" Language="C#" MasterPageFile="~/Loginmenu.master" AutoEventWireup="true" CodeFile="WebmasterRead.aspx.cs" Inherits="WebmasterRead" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">

    <%--important javascript for fileupload --%>
    <script type="text/javascript">
    function UploadFile(fileUpload) {
        if (fileUpload.value != '') {
            document.getElementById("<%=btnUpload.ClientID %>").click();
        }
    }
    </script>


    <div class="container">
        <div class="row">
            <div class="col-md-9">
                <asp:Label ID="LabelSucces" runat="server"></asp:Label>
                <asp:Label ID="LabelError" runat="server"></asp:Label>

                <asp:GridView ID="GridViewPokemonTable" runat="server" AutoGenerateColumns="false" OnRowDeleting="GridViewPokemonTable_RowDeleting" DataKeyNames="PokemonId" OnSelectedIndexChanged="GridViewPokemonTable_SelectedIndexChanged">
                    <Columns>

                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="ImagePokemon" runat="server" ImageUrl='<%# "Images/" + Eval("Image") %>' CssClass="mypokemonimage" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="PokemonId" HeaderText="id" SortExpression="alias" />
                    <asp:BoundField DataField="Number" HeaderText="Pokedex nr." SortExpression="alias" />
                    <asp:BoundField DataField="Name" HeaderText="Pokemon name" SortExpression="alias" />
                    <asp:BoundField DataField="NextEvolution" HeaderText="Next evolution" SortExpression="alias" />
                    <asp:BoundField DataField="Image" HeaderText="Image file" SortExpression="alias" />
                    <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="alias" />
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" />

                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-md-3">

                <div class="row">

                    <div class="col-md-12">
                        <h2>Update Pokémon</h2>
                        <asp:label runat="server" text="Pokedex"></asp:label>
                        <br />
                        <asp:textbox runat="server" ID="TextboxPokedex"></asp:textbox>
                        <br />
                        <asp:label runat="server" text="Pokémon name:"></asp:label>
                        <br />
                        <asp:textbox runat="server" ID="TextboxPokemonName"></asp:textbox>
                        <br />
                        <asp:label runat="server" text="Next evolution:"></asp:label>
                        <br />
                        <asp:textbox runat="server" ID="TextboxNextEvolution"></asp:textbox>
                        <br />
                        <asp:label runat="server" text="Type:"></asp:label>
                        <br />
                        <asp:textbox runat="server" ID="TextboxType"></asp:textbox>
                        <br />
                        <asp:label runat="server" text="Image:"></asp:label>
                        <br />
                        <asp:dropdownlist runat="server" ID="DropdownlistImages"></asp:dropdownlist>
                        <br />
                        <br />
                        <asp:button runat="server" text="Update" ID="ButtonUpdate" OnClick="ButtonUpdate_Click" class="btn btn-primary" />
                    </div>

                    <div class="col-md-12">
                        <h2>Upload image</h2>
                        <asp:Image ID="ImageToUpload" runat="server" CssClass="mypokemonimage" />
                        <br />
                        <asp:Label ID="LabelChooseImage" runat="server"></asp:Label>
                        <asp:fileupload runat="server" ID="FileUploadImage"></asp:fileupload>
                        <br />
                        <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="Upload" Style="display: none" />
                        <asp:Button ID="ButtonUploadImage" runat="server" Text="Upload" class="btn btn-primary" OnClick="ButtonUploadImage_Click" />
                    </div>

                </div>

            </div>
        </div>
    </div>
</asp:Content>

