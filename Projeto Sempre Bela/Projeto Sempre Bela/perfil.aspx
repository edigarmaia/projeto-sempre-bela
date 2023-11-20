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


    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js"></script>



    <%--teste js--%>
    <script type="text/javascript">
        function confirmarExclusao() {
            return confirm("Tem certeza que deseja excluir este serviço?");
        }
    </script>
    <%-- <script>
        function capturarValorIdAgendamento(elementoBotao) {
            var linha = elementoBotao.parentNode.parentNode; // Obtém a linha (tr) que contém o botão clicado
            var tdIdAgendamento = linha.querySelector("#tdIdAgendamento"); // Encontra o elemento td com o ID tdIdAgendamento

            var valorIdAgendamento = tdIdAgendamento.innerText; // Obtém o valor do IdAgendamento na célula td

            // Utilize o valor do ID do agendamento conforme necessário
            console.log("Valor do IdAgendamento: ", valorIdAgendamento);
        }
    </script>--%>
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
                            <%--<th scope="col">Status</th>
                            <th scope="col"></th>--%>
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
                            <!-- Adicionando um atributo data com o ID do agendamento ao botão -->
                            
                            <%--<td id="txtId" runat="server" style="display: ;">'<%="agendamento.IdAgendamento"%></td>--%>

                    <%--        <td id="tdIdAgendamento" runat="server" style="display:none" data-id="tdIdAgendamento">Id</td>--%>

                            <%--<td id="tdIdAgendamento" runat="server" style="display:none" class="tdIdAgendamento" data-id='<%=agendamento.IdAgendamento%>'></td>--%>



                            <%--<td id="tdIdAgendamento" style="display:none" ><%=agendamento.IdAgendamento%></td>--%>

                            <td><%=agendamento.Servico.TipoServico%></td>
                            <td><%=agendamento.DataAgendamento.ToShortDateString()%></td>
                            <td><%=agendamento.DataAgendamento.ToString("HH:mm")%></td>
                            <%-- Utilizando CultureInfo para converter um tipo de dado a cultura de uma linguagem específica. 
                                    No caso, está convertendo o valor decimal de origem norte-americana (com .) para o padrão pt-BR (com ,) nas casas decimais --%>
                            <td>R$ <%=agendamento.Servico.ValorServico.ToString("N", System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR"))%></td>


                            <%--TENTATIVAS DE PEGAR O ID --%>

                            <%--                            <td><asp:Label ID="lblStatus" runat="server" Text="Aguardando"></asp:Label></td>--%>


                            <%--                            <td><asp:Label ID="lblIdAgendamento" runat="server" Style="display:none">'<%#Eval("IdAgendamento")%>'</asp:Label></td>--%>

                            <%-- <td><asp:Button ID="btnCancelarAgendamento" runat="server" Text="Cancelar" CssClass="btn btn-outline-danger" OnClick="btnCancelarAgendamento_Click"/></td>--%>

                            <%--                               <asp:Button ID="btnCancelarAgendamento" runat="server" Text="Cancelar" CssClass="btn btn-outline-danger" 
                                   CommandName="CancelarAgendamento" CommandArgument='<%#Eval("IdAgendamento")%>' OnClick="btnCancelarAgendamento_Click" />--%>

                            <%--<asp:Button ID="btnCancelarAgendamento" runat="server" Text="Cancelar" CssClass="btn btn-outline-danger" 
                                   CommandName="CancelarAgendamento" CommandArgument='<%#Eval("IdAgendamento")%>' OnClick="btnCancelarAgendamento_Click" />--%>

                              <td>
                               <%-- <asp:Button ID="btnCancelarAgendamento" runat="server" Text="Cancelar" CssClass="btn btn-outline-danger"
                                    OnClick="btnCancelarAgendamento_Click" />--%>

      <%--                            <asp:Button ID="Button1" runat="server" Text="Cancelar" CssClass="btn btn-outline-danger"
    OnClick="btnCancelarAgendamento_Click" CommandArgument='<%# Eval("IdAgendamento") %>' />


                                  <asp:Button ID="btnExemplo" runat="server" Text="Clique Aqui" OnClick="btnCancelarAgendamento_Click" />
<%--                  --%>                                                                       <%-- <asp:HiddenField ID="hiddenFieldIdAgendamento" runat="server" />--%>
<%--<asp:Button ID="btnCancelarAgendamento" runat="server" Text="Cancelar" CssClass="btn btn-outline-danger btnCancel" 
    OnClientClick="capturarIdAgendamento('<%= agendamento.IdAgendamento %>');" OnClick="btnCancelarAgendamento_Click1" />--%>

<%--<asp:HiddenField ID="hiddenIdAgendamento" runat="server" />--%>
                              <%--    <asp:Button ID="Button1" runat="server" Text="Cancelar" CssClass="btn btn-outline-danger" OnClick="btnCancelarAgendamento_Click" 
                                      CommandArgument='txtId' />--%>


<%--                                  <asp:Button ID="btnCancelarAgendamento" runat="server" Text="Cancelar" CssClass="btn btn-outline-danger" 
                                      OnClick="btnCancelarAgendamento_Click" CommandArgument='<%# agendamento.IdAgendamento %>' />--%>



<%--                                  <script>
                                      $(document).ready(function () {
                                          var nomeTextBox = $('#<%= tdIdAgendamento.ClientID %>'); // Acesso ao TextBox pelo ClientID
                                          nomeTextBox.val('Novo Valor'); // Definir um novo valor no TextBox
                                      });

                                  </script>--%>

                            </td>
                        </tr>
                        <% } %>
                    </tbody>
                </table>
                <hr />


                <div>
                    <p>
                        <asp:Button ID="btnSair" runat="server" Value="Sair" Text="Sair" class="btn btn-outline-danger" OnClick="btnSair_Click1" />
                        <asp:Button ID="btnAlterarDados" runat="server" Value="Alterar" Text="Alterar" class="btn btn-outline-primary" />

                    </p>


                </div>
                <div id="sessaoManicure" visible="false" runat="server">
                    <h5>Serviços Oferecidos</h5>

                    <p>
                        <asp:ListBox ID="lbxServicos" runat="server" Width="400px" AutoPostBack="true" OnSelectedIndexChanged="lbxServicos_SelectedIndexChanged"></asp:ListBox>
                    </p>

                    <%--                    <p id="msgSucesso" style="color: rgb(0, 128, 0); text-align: center" visible="false" runat="server">Serviço excluído com sucesso!</p>--%>
                    <p id="msgErro" style="color: rgb(200, 0, 0);" visible="false" runat="server">Cancelado</p>
                    <div class="form-group">
                        <label for="">Nome Serviço</label>
                        <asp:TextBox type="text" class="form-control form-control-sm" ID="txtNomeServico" runat="server" placeholder="manicure"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rfvNomeServico" runat="server" ControlToValidate="txtNomeServico"
                            ErrorMessage="O nome do serviço é obrigatório." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        --%>
                    </div>
                    <div class="form-group">
                        <label for="">Valor</label>
                        <asp:TextBox type="text" class="form-control form-control-sm" ID="txtValorServico" runat="server" placeholder="00,00"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rfvValorServico" runat="server" ControlToValidate="txtValorServico"
   ErrorMessage="O valor do serviço é obrigatório." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                    </div>


                    <br />
                    <div>
                        <asp:Button ID="btnInserir" runat="server" Text="Inserir" class="btn btn-lg btn-success" OnClick="btnInserir_Click" />
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" class="btn btn-lg btn-primary" OnClick="btnEditar_Click" />
                        <asp:Button ID="btnExcluir" runat="server" Text="Excluir" class="btn btn-lg btn-danger" OnClick="btnExcluir_Click" OnClientClick=" return confirmarExclusao();" />


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
