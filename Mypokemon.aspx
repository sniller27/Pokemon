<%@ Page Title="Pokémon catches" Language="C#" MasterPageFile="~/Loginmenu.master" AutoEventWireup="true" CodeFile="Mypokemon.aspx.cs" Inherits="Mypokemon" %>

<%-- Add content controls here --%>
<asp:Content id="Content11" ContentPlaceholderID="ChildContent1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-12 text-center-me">
                <asp:Label runat="server" id="Labelpositivefeedback" text="" font-bold="true" />
                <asp:Label runat="server" id="Labelnegativefeedback" text="" font-bold="true" />
    
               <br />

                <asp:gridview runat="server" id="gridviewUserReadpokemon" AutoGenerateColumns="false" OnRowDeleting="gridviewUserReadpokemon_RowDeleting" onrowcommand="gridviewUserReadpokemon_RowCommand" DataKeyNames="CatchId">
                    <Columns>

                            <asp:TemplateField HeaderText="Pokémon">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "Images/" + Eval("Image") %>' CssClass="mypokemonimage" />
                            </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="catchName" HeaderText="Name" SortExpression="alias" />
                            <asp:BoundField DataField="Lvl" HeaderText="Level" SortExpression="name" />
                            <asp:BoundField DataField="CurrentExp" HeaderText="Current exp." SortExpression="age" />
                            <asp:BoundField DataField="NextLvlExp" HeaderText="Exp to next level" SortExpression="gender" />
                            <asp:BoundField DataField="PokemonGender" HeaderText="Gender" SortExpression="email" />
                            <asp:BoundField DataField="Number" HeaderText="Pokedex number" SortExpression="password" />
                            <asp:BoundField DataField="Name" HeaderText="Official Pokemon name" SortExpression="password" />
                            <asp:BoundField DataField="NextEvolution" HeaderText="Next Evolution" SortExpression="password" />
                            <asp:buttonfield buttontype="Button" commandname="buttonlevelchange" text="Evolve" ControlStyle-CssClass="btn btn-primary buttonspace" HeaderText="Evolve"/>
                            <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="password" />
                            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger buttonspace" HeaderText="Delete" />
                            <asp:BoundField DataField="CatchId" SortExpression="CatchId" />

                    </Columns>
                </asp:gridview>
            </div>
        </div>
    </div>

</asp:Content>