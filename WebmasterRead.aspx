<%@ Page Title="" Language="C#" MasterPageFile="~/Loginmenu.master" AutoEventWireup="true" CodeFile="WebmasterRead.aspx.cs" Inherits="WebmasterRead" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-9">
                <asp:Label ID="LabelSucces" runat="server"></asp:Label>
                <asp:Label ID="LabelError" runat="server"></asp:Label>

                <asp:GridView ID="GridViewPokemonTable" runat="server" AutoGenerateColumns="false" OnRowDeleting="GridViewPokemonTable_RowDeleting" DataKeyNames="PokemonId">
                    <Columns>

                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="ImagePokemon" runat="server" ImageUrl='<%# "Images/" + Eval("Image") %>' CssClass="mypokemonimage" />
                        </ItemTemplate>
                    </asp:TemplateField>

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
                        <asp:textbox runat="server"></asp:textbox>
                        <asp:textbox runat="server"></asp:textbox>
                        <asp:textbox runat="server"></asp:textbox>
                        <asp:textbox runat="server"></asp:textbox>
                        <asp:textbox runat="server"></asp:textbox>
                        <br />
                        <br />
                        <asp:button runat="server" text="Button" />
                    </div>

                    <div class="col-md-12">
                        <h2>Upload image</h2>
                        <asp:fileupload runat="server" ID="FileUploadImage"></asp:fileupload>
                        <br />
                        <br />
                        <asp:button runat="server" text="Button" ID="ButtonUploadImage" OnClick="ButtonUploadImage_Click" />
                    </div>

                </div>

            </div>
        </div>
    </div>
</asp:Content>

