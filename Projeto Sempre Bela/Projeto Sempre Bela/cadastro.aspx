<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="SempreBela.cadastro" %>

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
    <div class="main">



        <div class="col-sm">
            <h4 class="titulo_h4">Cadastro</h4>
            <div>
                <form runat="server">

                    <div class="form-group">


                        <label for="inputName">Nome</label>
                        <asp:TextBox type="text" class="form-control form-control-sm" ID="txtNome" runat="server" Required="true" ToolTip="O campo nome é obrigatório."></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNome"
                            ErrorMessage="O campo nome é obrigatório." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        --%>
                    </div>
                    <div class="form-group">

                        <label for="inputPhone">Telefone</label>
                        <asp:TextBox type="tel" class="form-control form-control-sm" ID="txtTelefone" runat="server" Required="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="regexTelefone" runat="server"
                            ControlToValidate="txtTelefone"
                            ErrorMessage="Telefone inválido. Use o formato (00) 00000-0000" Display="Dynamic" ForeColor="Red"
                            ValidationExpression="^\(\d{2}\)\s\d{5}-\d{4}$">
                        </asp:RegularExpressionValidator>

                        <script>
                            $(document).ready(function () {
                                $('#<%= txtTelefone.ClientID %>').mask('(00) 00000-0000');
                            });
                        </script>
                    </div>


                    <div class="form-group">
                        <label for="inputCpf">CPF</label>
                        <asp:TextBox type="text" class="form-control form-control-sm" ID="txtCpf" runat="server" Required="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="regexCPF" runat="server" ControlToValidate="txtCPF" ErrorMessage="CPF inválido. Use o formato 000.000.000-00"
                            ValidationExpression="\d{3}\.\d{3}\.\d{3}-\d{2}">
                        </asp:RegularExpressionValidator>
                        <script>
                            $(document).ready(function () {
                                $('#<%= txtCpf.ClientID %>').mask('000.000.000-00');
                            });
                        </script>
                    </div>


                    <div class="form-group">
                        <label for="exampleInputEmail1">E-mail</label>
                        <asp:TextBox type="email" class="form-control form-control-sm" ID="txtEmail" runat="server" Required="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="O e-mail não é válido." Display="Dynamic"
                            ForeColor="Red" ValidationExpression="^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"></asp:RegularExpressionValidator>
                    </div>

                    <div class="form-group">
                        <label for="inputSenha">Senha</label>
                        <asp:TextBox type="password" class="form-control form-control-sm" ID="txtSenha" runat="server" Required="true"></asp:TextBox>
                        <%--<asp:RegularExpressionValidator ID="regexSenha" runat="server" ControlToValidate="txtSenha" ErrorMessage="A senha deve ter pelo menos 8 caracteres, incluindo letras maiúsculas, minúsculas, números e caracteres especiais."
                            ForeColor="Red" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$">
                        </asp:RegularExpressionValidator>--%>
                    </div>


                    <%--CEP--%>

                    <div class="form-group">
                        <label for="">CEP</label>
                        <asp:TextBox type="text" class="form-control form-control-sm" ID="txtCep" runat="server" Required="true" AutoPostBack="true" OnTextChanged="txtCep_TextChanged"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="regexCEP" runat="server" ControlToValidate="txtCep"
                            ValidationExpression="^\d{5}-\d{3}$">
                        </asp:RegularExpressionValidator>
                        <label id="lblCep" runat="server"></label>
                    </div>
                    <script>
                        $(document).ready(function () {
                            $('#<%= txtCep.ClientID %>').mask('00000-000');
        });
                    </script>




                    <div class="form-group">
                        <label for="">Rua</label>
                        <asp:TextBox type="text" ReadOnly="true" class="form-control form-control-sm" ID="txtRua" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRua"
                            ErrorMessage="O nome da rua é obrigatório." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        <label for="">Número</label>
                        <asp:TextBox type="text" class="form-control form-control-sm" ID="txtNumero" Required="true" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNumero"
                            ErrorMessage="O número é obrigatório." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        <label for="">Complemento</label>
                        <asp:TextBox type="text" class="form-control form-control-sm" ID="txtComplemento" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="">Bairro</label>
                        <asp:TextBox type="text" ReadOnly="true" class="form-control form-control-sm" ID="txtBairro" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBairro"
                            ErrorMessage="O nome do bairro é obrigatório." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <%--  <div class="form-group">
                        <label for="">CEP</label>
                        <asp:TextBox type="text" class="form-control form-control-sm" ID="txtCep" runat="server" AutoPostBack="true" OnTextChanged="txtCep_TextChanged"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="regexCEP" runat="server" ControlToValidate="txtCep" ErrorMessage="CEP inválido. Use o formato 00000-000."
                            ValidationExpression="^\d{5}-\d{3}$">
                        </asp:RegularExpressionValidator>
                    </div>
                    <script>
                        $(document).ready(function () {
                            $('#<%= txtCep.ClientID %>').mask('00000-000');
                });
                    </script>--%>

                    <div class="form-group">
                        <label for="">Cidade</label>
                        <asp:TextBox type="text" ReadOnly="true" class="form-control form-control-sm" ID="txtCidade" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCidade"
                            ErrorMessage="O nome da cidade é obrigatório." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        <label for="">Estado</label>
                        <asp:TextBox type="text" ReadOnly="true" class="form-control form-control-sm" ID="txtEstado" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="regexEstado" runat="server" ControlToValidate="txtEstado" ErrorMessage="Informe um estado válido usando duas letras (ex: SP, RJ, MG)."
                            ValidationExpression="^[A-Za-z]{2}$">

                        </asp:RegularExpressionValidator>
                    </div>
                    <br />

                    <p>
                        <asp:RadioButton ID="rbCliente" runat="server" GroupName="GrupoRadio" Text="Cliente" Checked="True" />
                    </p>
                    <p>
                        <asp:RadioButton ID="rbManicure" runat="server" GroupName="GrupoRadio" Text="Manicure" />
                    </p>



                    <asp:Button ID="btnCadastrar" OnClientClick="return validarCadastro();" runat="server" Text="Cadastrar" class="btn btn-lg btn-block w-100" Style="background-color: #FF5FBF;" OnClick="btnCadastrar_Click" />

                    <br />
                    <br />
                </form>
            </div>
        </div>




        <%--Rodape--%>
        <footer>
            <p>&copy2023 Sempre Bela - Todos os Direitos Reservados!</p>
        </footer>
</body>
</html>
