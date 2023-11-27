<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SempreBela.index1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sempre Bela</title>

    <%--CSS--%>
    <link rel="stylesheet" href="CSS/estilo.css" />

    <%--Bootstrap--%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" 
        rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous"/>
</head>
<body>
    <div class="menu">
        <nav>
            <a href="index.aspx">
                <img class="logo" src="Imagens/logo_sempre_bela.jpeg" alt="Logo Sempre Bela" /></a>
            <ul class="itens-menu">
             <%--    <% if (TipoPerfil == Mecanismo.Enums.TipoPerfil.Manicure)
                    { %>
                <li><a href="servicos.aspx">Serviços</a></li>
                <% }
                    else if (TipoPerfil == Mecanismo.Enums.TipoPerfil.Cliente)
            {

            }
                    else
                    { %>
                <li><a href="agendamento.aspx">Agendamento</a></li>
                <% } %>--%>
                <li><a href="index.aspx">Home</a></li>
                <li><a href="servicos.aspx">Serviços</a></li>
                <li><a href="agendamento.aspx">Agendamento</a></li>
                <li><a href="contato.aspx">Contato</a></li>
                <li><a href="cadastro.aspx">Cadastro</a></li>
                 <li><a href="perfil.aspx">Meu Perfil</a></li>
            </ul>
        </nav>
    </div>


    
 

     <div class="index" style="width:900px">

        <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
           <%-- <ol class="carousel-indicators">
        <li data-target="#carouselExampleIndicators" data-slide-to="" class="active"></li>
        <li data-target="#carouselExampleIndicators" data-slide-to=""></li>
        <li data-target="#carouselExampleIndicators" data-slide-to=""></li>
      </ol>--%>
            <div class="carousel-inner" style="height: 25em;">
                <div class="carousel-item active">
                    <img src="Imagens/salao_img1.png" class="d-block w-100" alt="imagem carrosel 1"/>
                </div>
                <div class="carousel-item">
                    <img src="Imagens/salao_img2.png" class="d-block w-100" alt="imagem carrosel 2"/>
                </div>
                <div class="carousel-item">
                    <img src="Imagens/salao_img3.jpg" class="d-block w-100" alt="imagem carrosel 3"/>
                </div>
            </div>
            <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Anterior</span>
            </a>
            <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Próximo</span>
            </a>
        </div>
    </div>
       

    <div class="main" style="height: 50px;">
    </div>
    <!-- Segunda linha -->

    <h3>Novidades</h3>
    <br/>
    <div class="destaques">
        <div class="row">
            <div class="col-sm">
                <h6>Unhas Formais</h6>
                    <img src="Imagens/unhas_formais.jpeg"/><br /><br />
                <p>Estilo elegante em cada detalhe. Detalhes refinados que expressam sofisticação e elegância em cada unha.</p>
            </div>
            <div class="col-sm">
                <div class="col-sm">
                    <h6>Encontros Casuais</h6>
                    <img src="Imagens/unhas_formais2.jpg"/><br /><br />
                    <p>Um toque descontraído de charme em cada unha para encontros descontraídos.</p>
                </div>
            </div>
            <div class="col-sm">
                <div class="col-sm">
                    <h6>Unha Decorada Preto e Branco</h6>
                    <img src="Imagens/unha-decorada.jpg"/><br /><br />
                    <p>Contraste clássico em cada detalhe: unhas decoradas em preto e branco, elegância atemporal.</p>
                </div>
            </div>
        </div>
    </div>
    <br/>
    <br/>


    <h3>Depoimentos</h3><br/>
      <div class="container">
        <div class="row">
          
            <div class="col-sm">
                <p>             
                <img class="star" src="Imagens/cinco-estrelas.jpg"/><span>3 meses atrás</span></p>
                 <h6 class="feed"> 
                    "Minha visita à <b>Sempre Bela</b> foi incrível! A Manicure <b>Sofia</b> foi extremamente habilidosa e atenciosa. Amei o resultado, saí muito satisfeita! Com certeza voltarei!"
                </h6>
                <h5 class="feedback">Marina Rios</h5>
            
            </div>
    


          <div class="col-sm">
            <p>             
                <img class="star" src="Imagens/cinco-estrelas.jpg"/><span>2 meses atrás</span></p>
                   <h6 class="feed"> "Adorei a experiência com a <b>Sempre Bela!</b> A Manicure <b>Laura</b> foi incrível, cuidadosa e talentosa. 
                    Agradeço pela atenção, saí muito satisfeita! Recomendo!"</h6>
                <h5 class="feedback">Ana Santos</h5>
          </div>


          <div class="col-sm">
            <p>             
                <img class="star" src="Imagens/cinco-estrelas.jpg"/><span>5 meses atrás</span></p>
                <h6 class="feed">"A experiência na <b>Sempre Bela!</b> foi maravilhosa! A Manicure <b>Isabela</b> foi excepcional, atenta aos detalhes e super talentosa. Saí encantada com o resultado! Voltarei em breve!"
                </h6>
                <h5 class="feedback">Camila Moraes</h5>
          </div>
        </div>
      </div>
      <div class="divider"></div>
      <div class="container">
        <div class="row">
          
            <div class="col-sm">
                <p>             
                <img class="star" src="Imagens/cinco-estrelas.jpg"/><span>4 meses atrás</span></p>
                <h6 class="feed"> 
                    "Adorei minha ida à <b>Sempre Bela!</b>! A Manicure <b>Julia</b> foi fantástica, demonstrou grande habilidade e cuidado. Saí muito feliz com o resultado! Com certeza, recomendarei!"
                </h6>
                <h5 class="feedback">Gabriela Torres</h5>
           
            </div>



          <div class="col-sm">
            <p>             
                <img class="star" src="Imagens/cinco-estrelas.jpg"/><span>2 meses atrás</span>
                </p>
                   <h6 class="feed"> "Minha visita à <b>Sempre Bela!</b> foi ótima! A Manicure <b>Carla</b> foi incrível, atenciosa e habilidosa. Adorei o resultado, 
                       saí muito satisfeita! Com certeza, voltarei em breve!"</h6> 
                <h5 class="feedback">Beatriz Lima</h5>
          </div>


          <div class="col-sm">
            <p>             
                <img class="star" src="Imagens/cinco-estrelas.jpg"/><span>3 meses atrás</span></p>
                   <h6 class="feed"> "Uma experiência maravilhosa na <b>Sempre Bela!</b>! A Manicure <b>Ana</b> foi incrível, atenciosa e muito habilidosa. Saí encantada com o resultado! Recomendo com certeza!"
                </h6>
                <h5 class="feedback">Juliana Carvalho</h5>
          </div>
        </div>
      </div>


    <br />
    <br />
    <footer>

        <p>&copy2023 Sempre Bela - Todos os Direitos Reservados!</p>
    </footer>


    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

</body>
</html>
