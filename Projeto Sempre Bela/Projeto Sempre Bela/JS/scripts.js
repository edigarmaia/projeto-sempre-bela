﻿function confirmarExclusao(idAgendamento) {
    var confirmacao = confirm("Tem certeza que deseja excluir o agendamento?");
    if (confirmacao) {
        __doPostBack('<%= btnCancelar.UniqueID %>', ''); // Aciona o postback no botão
    }
    return false; // Retorna false para evitar o postback se o usuário clicar em "Cancelar" no diálogo de confirmação
}
