<%@ Page Title="" Language="C#" MasterPageFile="~/Loginmenu.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

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

    <script>
        //parallax effect
        var jumboHeight = $('.jumbotron').outerHeight();
        function parallax() {
            var scrolled = $(window).scrollTop();
            $('.bg').css('height', (jumboHeight - scrolled) + 'px');
        }

        $(window).scroll(function (e) {
            parallax();
        });
    </script>

    <%--CAROUSEL--%>
    <script type="text/javascript">
        var mycarousel = $(".mycarousel"),
            currdeg  = 0;

        $(".next").on("click", { d: "n" }, rotate);
        $(".prev").on("click", { d: "p" }, rotate);

        function rotate(e){
          if(e.data.d=="n"){
            currdeg = currdeg - 60;
          }
          if(e.data.d=="p"){
            currdeg = currdeg + 60;
          }
          mycarousel.css({
            "-webkit-transform": "rotateY("+currdeg+"deg)",
            "-moz-transform": "rotateY("+currdeg+"deg)",
            "-o-transform": "rotateY("+currdeg+"deg)",
            "transform": "rotateY("+currdeg+"deg)"
          });
        }
    </script>

</asp:Content>

