<%@ Page Title="Participants" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="readpokehunters.aspx.cs" Inherits="readpokehunters" %>



<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
    
    <div class="boxmodelbox mediumbox">

        <form id="form1" runat="server">
    
            <h2>Attending Pokehunters</h2>
            <asp:Label ID="LabelReadPokehuntersInfo" runat="server"></asp:Label>

            <asp:GridView ID="GridViewPokehunters" runat="server" Width="730px" AutoGenerateColumns="False" datakeynames="alias">
                <Columns>
                    <asp:BoundField DataField="alias" HeaderText="Alias" SortExpression="alias" />
                    <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                    <asp:BoundField DataField="age" HeaderText="Age" SortExpression="age" />
                    <asp:BoundField DataField="FavoritePokemon" HeaderText="FavoritePokemon" SortExpression="FavoritePokemon" />
                </Columns>
            </asp:GridView>

        </form>

    </div>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="afterscripts" Runat="Server">
    <script>

        //apply classes to table
        document.getElementById("content_GridViewPokehunters").className = 'mdl-data-table mdl-js-data-table mdl-shadow--2dp';

    </script>
</asp:Content>
