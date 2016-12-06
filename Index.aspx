<%@ Page Title="Welcome to the annual Pokémon event" Language="C#" MasterPageFile="~/Loginmenu.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderhead" Runat="Server">
    <%--css fallbacks--%>
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
        <div class="row">
            <div class="col-md-12">
                <div class="text-center-me">
                    <h1 class="sponsortext">Sponsors</h1>
                    <div class="headerunderline"></div>
                </div>
            </div>
        </div>
        <div class="row">
            <asp:repeater ID="RepeaterFrontpage" runat="server">

            <HeaderTemplate>
            </HeaderTemplate>

            <ItemTemplate>

                <div class="col-md-2 sponsorboxes">
                    <image src="Images/sponsors/<%# Eval("LogoUrl") %>" alt="sponsor" />
                </div>



            </ItemTemplate>

            <FooterTemplate>
            </FooterTemplate>

            </asp:repeater>
        </div>
    </div>

    <%--frontpage files--%>
    <script src="js/carousel.js"></script>
    <script src="js/parallax.js"></script>

</asp:Content>

