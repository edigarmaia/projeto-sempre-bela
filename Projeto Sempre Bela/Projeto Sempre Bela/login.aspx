<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SempreBela.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Sempre Bela</title>

    <%--CSS--%>
    <link rel="stylesheet" href="CSS/estilo.css" />

    <%--Bootstrap--%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous"/>
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
            </ul>
        </nav>
    </div>



        <div id="form">
            <form class="px-4 py-3" runat="server">
                <h2 class="title">Login</h2>

                <label class="label" for="Nome" runat="server">E-mail </label>
                <div class="input">
                    <asp:TextBox type="email" class="form-control form-control-sm" placeholder="E-mail" ID="txtEmail" runat="server"></asp:TextBox>
                </div>

                <label class="label" for="Senha" runat="server">Senha </label>
                <div class="input">
                    <asp:TextBox type="password" class="form-control form-control-sm" placeholder="Insira a senha" ID="txtSenha" runat="server"></asp:TextBox>
                </div>

               

                <div id="btn">
                    <asp:Button ID="btnLogin" runat="server" Text="Entrar" Class="btn1 btn-lg w-100" Style="background-color: #FF5FBF;" OnClick="btnLogin_Click" />
                </div>
                <br />

                <p id="msgErro" style="color: rgb(200, 0, 0)" visible="false" runat="server">Usuário ou senha incorretos</p>

            </form>
            <div class="dropdown-divider" id="final"></div>
            <!-- linkar tela -->
            <a class="item" href="cadastro.aspx">Não tem uma conta? Então cadastre-se</a>
            <br />
          
          
        </div>

    <footer>
        
        <p>&copy2023 Sempre Bela - Todos os Direitos Reservados!</p>
    </footer>


</body>
</html>
