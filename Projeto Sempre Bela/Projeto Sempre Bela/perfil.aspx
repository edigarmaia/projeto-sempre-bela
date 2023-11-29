<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="SempreBela.perfil_manicure" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sempre Bela</title>

    <%--CSS--%>
    <link rel="stylesheet" href="CSS/estilo.css" />

    <%--Bootstrap--%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css"
        rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />


    <%--   <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js"></script>--%>



    <%--teste js--%>
    <%--    <link type="text/javascript" rel="JS/scripts.js" />--%>

    <script type="text/javascript">
        function confirmarExclusao() {
            return confirm("Tem certeza que deseja excluir este serviço?");
        }

    </script>
</head>

<body>



    <%--Menu--%>
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

    <%--Corpo--%>

    <div class="main">
        <div class="container">
            <form runat="server">
                <h3>Perfil <%=(Mecanismo.Enums.TipoPerfil)(int)Session["tipo"] %> </h3>
                <br />
                <h6>Olá, <%=Session.Keys.Count > 0 ? Session["nome"] : "Usuário"%></h6>
                <h4 style="text-align: center">Serviços agendados</h4>
                <table class="table table-borderless">
                    <thead>
                        <tr>
                            <th scope="col">Nome</th>
                            <th scope="col">Serviço</th>
                            <th scope="col">Data</th>
                            <th scope="col">Hora</th>
                            <th scope="col">Valor</th>
                            <th scope="col">Ações</th>
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

                            <%--<td id="tdIdAgendamento" runat="server" style="display:none" data-id="tdIdAgendamento">Id</td>--%>
                            <td><%=agendamento.Servico.TipoServico%></td>
                            <td><%=agendamento.DataAgendamento.ToShortDateString()%></td>
                            <td><%=agendamento.DataAgendamento.ToString("HH:mm")%></td>
                            <%-- Utilizando CultureInfo para converter um tipo de dado a cultura de uma linguagem específica. 
                                    No caso, está convertendo o valor decimal de origem norte-americana (com .) para o padrão pt-BR (com ,) nas casas decimais --%>
                            <td>R$ <%=agendamento.Servico.ValorServico.ToString("N", System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR"))%></td>
                             
                            <td>
                                <asp:Button ID="btnCancelarAgendamento" runat="server" Text="Cancelar" CssClass="btn btn-outline-danger" OnClick="btnCancelarAgendamento_Click" /></td>

                        </tr>
                        <% } %>
                    </tbody>

                </table>
                <hr />


                <div>
                    <p>
                        <asp:Button ID="btnSair" runat="server" Value="Sair" Text="Sair" class="btn btn-outline-danger" OnClick="btnSair_Click1" />
                    </p>


                </div>
                <div id="sessaoManicure" visible="false" runat="server">
                    <h5>Serviços Oferecidos</h5>

                    <p>
                        <asp:ListBox ID="lbxServicos" runat="server" Width="400px" Height="100px" AutoPostBack="true" OnSelectedIndexChanged="lbxServicos_SelectedIndexChanged"></asp:ListBox>
                    </p>

                    <p id="msgSucesso" style="color: rgb(0, 128, 0); text-align: center" visible="false" runat="server">Serviço excluído com sucesso!</p>
                    <p id="msgErro" style="color: rgb(200, 0, 0); text-align: center" visible="false" runat="server">Não é possível excluir o serviço devido a agendamentos associados!</p>

                    <div class="form-group">
                        <%--<label >Código</label>--%>
                        <asp:Textbox type="text" Visible="false" ID="txtIdServico" runat="server"></asp:Textbox>
                        </div>
                        
                    <div class="form-group">
                        <label for="">Nome Serviço</label>
                        <asp:TextBox type="text" class="form-control form-control-sm" ID="txtNomeServico" runat="server" placeholder="manicure"></asp:TextBox>
                       
                    </div>
                    <div class="form-group">
                        <label for="">Valor</label>
                        <asp:TextBox type="text" class="form-control form-control-sm" ID="txtValorServico" runat="server" placeholder="00,00"></asp:TextBox>
                       
                    </div>


                    <br />
                    <div> 
                       
                        <asp:Button ID="btnLimpar" runat="server" Text="Limpar" class="btn btn-lg btn-outline-secondary" OnClick="btnLimpar_Click"/>
                        <asp:Button ID="btnInserir" runat="server" Text="Inserir" class="btn btn-lg btn-outline-success" OnClick="btnInserir_Click" />
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" class="btn btn-lg btn-outline-primary" OnClick="btnEditar_Click" />
                        <asp:Button ID="btnExcluir" runat="server" Text="Excluir" class="btn btn-lg btn-outline-danger" OnClick="btnExcluir_Click"
                            OnClientClick=" return confirmarExclusao();" />

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

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js"></script>

</body>

</html>
