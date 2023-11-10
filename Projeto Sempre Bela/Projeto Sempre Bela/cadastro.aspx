<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="SempreBela.cadastro" %>

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

    <script type="text/javascript">
    function validarCadastro() {
        var nome = document.getElementById('<%= txtNome.ClientID %>').value;
        var telefone = document.getElementById('<%= txtTelefone.ClientID %>').value;
        var cpf = document.getElementById('<%= txtCpf.ClientID %>').value;
        var email = document.getElementById('<%= txtEmail.ClientID %>').value;
        var senha = document.getElementById('<%= txtSenha.ClientID %>').value;
        var rua = document.getElementById('<%= txtRua.ClientID %>').value;
        var numero = document.getElementById('<%= txtNumero.ClientID %>').value;
        var complemento = document.getElementById('<%= txtComplemento.ClientID %>').value;
        var bairro = document.getElementById('<%= txtBairro.ClientID %>').value;
        var cep = document.getElementById('<%= txtCep.ClientID %>').value;
        var cidade = document.getElementById('<%= txtCidade.ClientID %>').value;
        var estado = document.getElementById('<%= txtEstado.ClientID %>').value;

        if (nome.trim() === "") {
            alert("Por favor, insira um nome.");
            return false;
        }
        if (telefone.trim() === "") {
            alert("Por favor, insira um telefone.");
            return false;
        }

        // Adicione validações semelhantes para os outros campos conforme necessário...

        // Se todas as validações passarem, retorne true para permitir o envio do formulário
        return true;
    }
</script>


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
                        <label for="exampleInputName">Nome</label>
                        <asp:TextBox type="text" class="form-control form-control-sm" ID="txtNome" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPhone">Telefone</label>
                        <asp:TextBox type="tel" class="form-control form-control-sm" ID="txtTelefone" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="e">CPF</label>
                        <asp:TextBox type="text" class="form-control form-control-sm" ID="txtCpf" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="exampleInputEmail1">E-mail</label>
                        <asp:TextBox type="email" class="form-control form-control-sm" ID="txtEmail" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="exampleInputPassword1">Senha</label>
                        <asp:TextBox type="password" class="form-control form-control-sm" ID="txtSenha" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="">Rua</label>
                        <asp:TextBox type="text" class="form-control form-control-sm" ID="txtRua" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="">Número</label>
                        <asp:TextBox type="text" class="form-control form-control-sm" ID="txtNumero" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="">Complemento</label>
                        <asp:TextBox type="text" class="form-control form-control-sm" ID="txtComplemento" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="">Bairro</label>
                        <asp:TextBox type="text" class="form-control form-control-sm" ID="txtBairro" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="">CEP</label>
                        <asp:TextBox type="text" class="form-control form-control-sm" ID="txtCep" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="">Cidade</label>
                        <asp:TextBox type="text" class="form-control form-control-sm" ID="txtCidade" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="">Estado</label>
                        <asp:TextBox type="text" class="form-control form-control-sm" ID="txtEstado" runat="server"></asp:TextBox>
                    </div>
                    <br />

                    <p>
                        <asp:RadioButton ID="rbCliente" runat="server" GroupName="GrupoRadio" Text="Cliente" Checked="True" />
                    </p>
                    <p>
                        <asp:RadioButton ID="rbManicure" runat="server" GroupName="GrupoRadio" Text="Manicure" />
                    </p>



                    <asp:Button ID="btnCadastrar" OnClientClick="return validarCadastro();" runat="server" Text="Cadastrar" class="btn btn-lg btn-block w-100" Style="background-color: rgb(247, 76, 213);" OnClick="btnCadastrar_Click" />

                    <br />
                    <br />
                </form>
            </div>
        </div>

    </div>
    <%-- </div>--%>




    <%--Rodape--%>
    <footer>
        <p>&copy2023 Sempre Bela - Todos os Direitos Reservados!</p>
    </footer>

</body>
</html>
