<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="alterarAgendamento.aspx.cs" Inherits="Projeto_Sempre_Bela.alterarAgendamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>Alterar Agendamento</title>

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
            <a href="index.aspx">
                <img class="logo" src="Imagens/logo_sempre_bela.jpeg" alt="Logo Sempre Bela" /></a>
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

    <form runat="server">
        <div class="main">
            <div class="container">


                <p>
                    Manicure:<asp:DropDownList ID="ddlManicure" runat="server" Width="290px" AutoPostBack="true"></asp:DropDownList>
                </p>

                <p>
                    Serviço: 
                   
                    <asp:DropDownList ID="ddlServico" runat="server" Width="300px"></asp:DropDownList>
                </p>
                <%--<p>
                    Valor: 
   
                    <asp:DropDownList ID="ddlValorServico" runat="server" Width="314px"></asp:DropDownList>
                </p>--%>
                <p>
                    Data:
                   
                    <asp:TextBox type="datetime-local" ID="txtDataAgendamento" runat="server" Width="315px" />
                </p>
                <p>
                    Local:<asp:TextBox ID="txtLocalAgendamento" runat="server" Width="315px" />
                </p>
                <p>
                    <asp:Button ID="btnAgendar" runat="server" Text="Agendar" class="btn btn-lg" Style="background-color: rgb(247, 76, 213);"/>
                </p>

            </div>

        </div>

    </form>



    <%--Rodape--%>
    <footer>
        <p>&copy2023 Sempre Bela - Todos os Direitos Reservados!</p>
    </footer>

</body>
</html>
