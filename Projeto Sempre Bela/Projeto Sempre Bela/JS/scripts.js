//function confirmarExclusao(idAgendamento) {
//    var confirmacao = confirm("Tem certeza que deseja excluir o agendamento?");
//    if (confirmacao) {
//        __doPostBack('<%= btnCancelar.UniqueID %>', ''); // Aciona o postback no botão
//    }
//    return false; // Retorna false para evitar o postback se o usuário clicar em "Cancelar" no diálogo de confirmação
//}

/*function pegarIdAgenda()*/


//<script>
//    $(document).ready(function() {
//        $('#txtTelefone').mask('(00) 00000-0000')
//    });
//</script>


// Pegar o id
function capturarValorIdAgendamento(elementoBotao) {
    var linha = elementoBotao.parentNode.parentNode;
    var tdIdAgendamento = linha.querySelector("#tdIdAgendamento");
    var valorIdAgendamento = tdIdAgendamento.innerText;

    console.log("Valor do IdAgendamento: ", valorIdAgendamento);

    document.getElementById('<%= idAgendamentoHiddenField.ClientID %>').value = valorIdAgendamento;


    $.ajax({
        type: 'POST', // ou 'GET' dependendo da sua configuração no servidor
        url: '/perfil.aspx/ExcluirAgendamento',
        data: { id: valorIdAgendamento },
        success: function (response) {
            console.log(response)
            // Lógica para lidar com a resposta do servidor (se necessário)
        },
        error: function (error) {
            console.log(error)
            // Lidar com erros, se houver
        }
    });


    //fetch('/AgendamentoDao/ExcluirAgendamento?id=' + valorIdAgendamento, {
    //    method: 'POST', // ou 'GET' dependendo da sua configuração no servidor
    //});
}

