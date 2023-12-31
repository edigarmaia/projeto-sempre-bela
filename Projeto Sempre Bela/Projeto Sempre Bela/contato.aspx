﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contato.aspx.cs" Inherits="SempreBela.contato" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sempre Bela</title>

    <%--CSS--%>
    <link rel="stylesheet" href="CSS/estilo.css" />

    <%--Bootstrap--%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css"
        rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />

    <!-- Referência para o jQuery -->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <!-- Referência para o jQuery Mask Plugin -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js"></script>

</head>
<body>
    <div class="menu">
        <nav>
            <a href="index.aspx">
                <img class="logo" src="Imagens/logo_sempre_bela.jpeg" alt="Logo Sempre Bela" /></a>
            <ul class="itens-menu">
                <%-- <% if (TipoPerfil == Mecanismo.Enums.TipoPerfil.Manicure)
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



    <div class="main">
        <form runat="server" action="https://formsubmit.co/507f677a0ae744dbf5c231affae53a49" method="POST">
            <h4 class="titulo_h4">Fale conosco</h4>
            <br />
            <div class="row">

                <div class="form-group">
                    <asp:TextBox type="text" class="form-control form-control-sm" ID="txtNome" runat="server" placeholder="Nome"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNome" ErrorMessage="O campo nome é obrigatório." 
                        Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:TextBox type="email" class="form-control form-control-sm" ID="txtEmail" runat="server" placeholder="E-mail" TextMode="Email"></asp:TextBox><br />
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="O e-mail não é válido." Display="Dynamic" ForeColor="Red"
                        ValidationExpression="^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"></asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                    <asp:TextBox type="text" class="form-control form-control-sm" ID="txtTelefone" runat="server" placeholder="Telefone"></asp:TextBox><br />
                    <asp:RegularExpressionValidator ID="regexTelefone" runat="server" ControlToValidate="txtTelefone" ErrorMessage="Telefone inválido. Use o formato (00) 00000-0000" 
                        Display="Dynamic" ForeColor="Red" ValidationExpression="^\(\d{2}\)\s\d{5}-\d{4}$">
                    </asp:RegularExpressionValidator>
                </div>
                <script>
                    $(document).ready(function () {
                        $('#<%= txtTelefone.ClientID %>').mask('(00) 00000-0000');
                      });
                </script>


                <div class="form-group">
                    <asp:TextBox type="text" class="form-control form-control-sm" ID="txtAssunto" runat="server" placeholder="Assunto"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAssunto"
                        ErrorMessage="O campo assunto é obrigatório." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>


            <div class="form-group">
                <label for="txtMensagem"></label>
                <asp:TextBox type="text" class="form-control form-control-sm" ID="txtMensagem" cols="20" Rows="4" TextMode="MultiLine" runat="server" placeholder="Digite sua mensagem"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMensagem"
                    ErrorMessage="O campo mensagem é obrigatório." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <br />

            <asp:Button ID="btnEnviar" type="button" class="btn btn-lg btn-block w-100" runat="server" Style="background-color: #FF5FBF;" Text="Enviar"/>

            <br />

            <input type="hidden" name="_next" value="https://localhost:44376/retornoForm.html"/>
            <input type="hidden" name="_captcha" value="false"/>



        </form>
    </div>
    <br />


    <footer>
        <p>&copy2023 Sempre Bela - Todos os Direitos Reservados!</p>
    </footer>
</body>

</html>
