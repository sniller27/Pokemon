<%@ Page Title="Welcome to the annual Pokémon event" Language="C#" MasterPageFile="~/Loginmenu.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderhead" Runat="Server">
    <%--css falbacks--%>
    <script src="http://s.codepen.io/assets/libs/modernizr.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent1" Runat="Server">

    <div class="bg"></div>
    <div class="jumbotron text-center">
      <h1>Welcome to Pokémon event 2016</h1>
      <p class="lead">Sign up now for free!</p>
    </div>

    <div class="container">
        <div class="row">
            <div class="jumbotron text-center jumofixheight">
                <h2>These are the current wild Pokémon</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                    <div class="carouselcontainer">
                        <div class="mycarousel">
                            <asp:datalist runat="server" id="datalistpokemoncarousel">
                                <ItemTemplate>
                                    <img class="mycarouselitem slide<%#Eval("PokemonId") %>" src="Images/<%#Eval("Image") %>" />
                                </ItemTemplate>
                            </asp:datalist>
                        </div>
                    </div>
                    <div class="next">Next</div>
                    <div class="prev">Prev</div>
            </div>
        </div>
    </div>

    <%--frontpage files--%>
    <script src="js/carousel.js"></script>
    <script src="js/parallax.js"></script>

</asp:Content>

