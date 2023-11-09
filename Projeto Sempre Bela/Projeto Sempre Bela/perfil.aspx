﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="SempreBela.perfil_manicure" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sempre Bela</title>

    <%--CSS--%>
    <link rel="stylesheet" href="CSS/estilo.css" />

    <%--Bootstrap--%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
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
                <li><a href="manicures.aspx">Manicures</a></li>
                <li><a href="agendamento.aspx">Agendamento</a></li>
                <li><a href="cadastro.aspx">Cadastro</a></li>
                <li><a href="perfil.aspx">Meu Perfil</a></li>
            </ul>
        </nav>
    </div>

    <%--Corpo--%>

    <div class="main">
        <div class="container">
            <form runat="server">            
                    <h3>Perfil <%=(Mecanismo.Enums.TipoPerfil)(int)Session["tipo"] %> </h3>
                    <br />
                    <h6>Olá, <%=Session.Keys.Count > 0 ? Session["nome"] : "Usuário"%></h6>
                    <h6>Serviços agendados</h6>
                    <table class="table table-borderless">
                        <thead>
                            <tr>
                                <th scope="col">Nome da Manicure</th>
                                <th scope="col">Serviço</th>
                                <th scope="col">Data</th>
                                <th scope="col">Hora</th>
                                <th scope="col">Valor</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody>
                            <%-- Utilizando foreach para mapear os serviços. Variável "Agendamentos" é fornecida de forma global diretamente do arquivo perfil.aspx.cs--%>
                            <% foreach (var agendamento in Agendamentos)
                                {%>
                            <tr>
                                <td>
                                    <%-- Operação ternária para identificar se na tabela deve ser exibida o nome da manicure ou do cliente --%>

                                    <%=Tipo == Mecanismo.Enums.TipoPerfil.Cliente ?
                                          agendamento.Manicure.Nome : agendamento.Cliente.Nome 
                                    %>
                                </td>
                                <td><%=agendamento.Servico.TipoServico%></td>
                                <td><%=agendamento.DataAgendamento.ToShortDateString()%></td>
                                <td><%=agendamento.DataAgendamento.ToString("HH:mm")%></td>
                                <%-- Utilizando CultureInfo para converter um tipo de dado a cultura de uma linguagem específica. 
                                    No caso, está convertendo o valor decimal de origem norte-americana (com .) para o padrão pt-BR (com ,) nas casas decimais --%>
                                <td>R$ <%=agendamento.Servico.ValorServico.ToString("N", System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR"))%></td>
                                <td><asp:Button ID="btnPagar" runat="server" Text="Pagar" class="btn btn-primary" /></td>
                            </tr>
                            <% } %>
                        </tbody>
                    </table>
                    <hr />

                                <div><p><asp:Button ID="btnSair" runat="server" Value="Sair" Text="Sair" class="btn btn-lg btn-secondary" OnClick="btnSair_Click1" />
</p>
                </div>
                <div id="sessaoManicure" visible="false" runat="server">
                    <h5>Serviços Oferecidos</h5>
                    listar aqui os serviços
                     <p>
                         <asp:ListBox ID="lbxServicos" runat="server" Width="400px" AutoPostBack="true" OnSelectedIndexChanged="lbxServicos_SelectedIndexChanged"></asp:ListBox>
                     </p>
                    <br />
                    <div class="form-group">
                        <label for="">Nome Serviço</label>
                        <asp:TextBox type="text" class="form-control form-control-sm" ID="txtNomeServico" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="">Valor R$</label>
                        <asp:TextBox type="text" class="form-control form-control-sm" ID="txtValorServico" runat="server"></asp:TextBox>
                    </div>


                    <br />
                    <br />
                    <div>
                        <asp:Button ID="btnInserir" runat="server" Text="Inserir" class="btn btn-lg btn-success" OnClick="btnInserir_Click" />
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" class="btn btn-lg btn-primary" OnClick="btnEditar_Click" />
                        <asp:Button ID="btnExcluir" runat="server" Text="Excluir" class="btn btn-lg btn-danger" OnClick="btnEditar_Click" />

                        <div />
                    </div>
                    <br />
                </div>
            </form>
        </div>
    </div>

    <footer>
        
        <p>&copy2023 Sempre Bela - Todos os Direitos Reservados!</p>
    </footer>
</body>

</html>
