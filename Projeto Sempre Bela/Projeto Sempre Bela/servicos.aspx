<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="servicos.aspx.cs" Inherits="SempreBela.servicos" %>

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

    <%--Menu--%>
    <div class="menu">
        <nav>
            <a href="index.aspx"><img class="logo" src="Imagens/logo_sempre_bela.jpeg" alt="Logo Sempre Bela" /></a>
            <ul class="itens-menu">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="servicos.aspx">Serviços</a></li>
                <li><a href="agendamento.aspx">Agendamento</a></li>
                <li><a href="contato.aspx">Contato</a></li>
                <li><a href="cadastro.aspx">Cadastro</a></li>
               <li><a href="perfil.aspx">Meu Perfil</a></li>
            </ul>
        </nav>
    </div>

    <%--Corpo--%>


    <div class="main">

        <div class="container">
            <div class="row">
                <div class="col-sm">
                    <h4 class="titulo_h4">Manicure</h4>
                    <img src="Imagens/manicure_2.png" />

                    <div>
                        <p class="servicos">Transformando suas unhas em obras de arte, nossa equipe de manicure oferece um serviço excepcional, ressaltando a beleza e elegância das suas mãos. </p>
                    </div>
                </div>
                <div class="col-sm">
                    <h4 class="titulo_h4">Alongamento de unhas</h4>
                    <img src="Imagens/alonga.png" />

                    <div>
                        <p>Exiba unhas impecáveis e deslumbrantes com nossos serviços de alongamento, proporcionando um toque de sofisticação e estilo à sua rotina de cuidados pessoais. </p>
                    </div>
                </div>
                <div class="col-sm">
                    <h4 class="titulo_h4">Pedicure</h4>
                    <img src="Imagens/pedicure.png" />

                    <div>
                        <p>Relaxe e renove seus pés com o nosso serviço de pedicure, que cuida da saúde e da beleza dos seus pés, garantindo que você se sinta revigorado e com um visual impecável da cabeça aos pés.</p>
                    </div>
                </div>
            </div>
        </div>


        <!-- Segunda linha -->
        <div class="container">
            <div class="row">
                <div class="col-sm">
                    <h4 class="titulo_h4">Banho em acrílico</h4>
                    <img src="Imagens/banho_acrilico.png" />

                    <div>
                        <p>Experimente o luxo do banho de acrílico para unhas, uma técnica que oferece resistência, durabilidade e brilho impecável, transformando suas unhas com um toque de elegância e glamour. </p>
                    </div>
                </div>
                <div class="col-sm">
                    <h4 class="titulo_h4">Unhas de fibra de vidro</h4>
                    <img src="Imagens/fibra_vidro.png" />

                    <div>
                        <p>Revele a beleza natural das suas unhas com o serviço de aplicação de unhas de fibra de vidro, oferecendo resistência e um visual sofisticado, enquanto mantém a aparência elegante que você deseja. </p>
                    </div>
                </div>
                <div class="col-sm">
                    <h4 class="titulo_h4">Unhas de gel</h4>
                    <img src="Imagens/unhas_gel.png" />

                    <div>
                        <p>Descubra a beleza duradoura e a versatilidade das unhas de gel, que proporcionam um visual impecável e personalizado, perfeito para expressar sua individualidade e estilo. </p>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%--Rodapé--%>
    <footer>
        <!--
      <ul class="rodape">
        <li><a href="#">Home</a></li>
        <li><a href="#">Serviços</a></li>
        <li><a href="#">Manicures</a></li>
        <li><a href="#">Agendamento</a></li>
        <li><a href="#">Cadastro</a></li>
    </ul> -->

        <p>&copy2023 Sempre Bela - Todos os Direitos Reservados!</p>
    </footer>



</body>
</html>
