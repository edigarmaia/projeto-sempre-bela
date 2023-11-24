using Mecanismo.Dao;
using Mecanismo.Dao.DaoAgendamento;
using Mecanismo.Dao.DaoServicos;
using Mecanismo.Dao.DaoUsuarios;
using Mecanismo.Enums;
using SempreBela.Dao.DaoAgendamento;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Optimization;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SempreBela
{
    public partial class perfil_manicure : System.Web.UI.Page
    {
        protected TipoPerfil TipoPerfil;


        // Variáveis globais para serem utilizadas na classe toda e também no front
        protected List<Agendamento> Agendamentos = new List<Agendamento>();
        protected TipoPerfil Tipo;
        protected int IdUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Validação verificando se há valores guardados na sessão. Caso tenha, significa que o usuário está logado, caso não tenha, o usuário é redirecionado para o login
            if (Session.Keys.Count == 0)
                Response.Redirect("login.aspx");

            IdUsuario = (int)Session["idUsuario"];
            Tipo = (TipoPerfil)Session["tipo"];

            // Utilizando id e tipo de usuário para filtrar os agendamentos do usuário em questão
            Agendamentos = AgendamentoDao.ListarAgendamentosPorUsuario(IdUsuario, Tipo);

            if (Tipo == TipoPerfil.Manicure && !IsPostBack)
            {
                sessaoManicure.Visible = true;

                List<Servico> servicos = ServicosDao.ListarServicosPorManicure(IdUsuario);

                // Limpar o ListBox antes de adicionar os itens
                lbxServicos.Items.Clear();

                //Adicionar os itens da lista de serviços ao ListBox
                foreach (Servico servico in servicos)
                {
                    lbxServicos.Items.Add(new ListItem(servico.TipoServico, servico.ValorServico.ToString("N", System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR"))));
                }
            }

        }

        protected void lbxServicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtém o índice do item selecionado no ListBox
            int selectedIndex = lbxServicos.SelectedIndex;

            if (selectedIndex >= 0)
            {
                // Obtém o item selecionado
                ListItem selectedItem = lbxServicos.Items[selectedIndex];

                // Define o nome do serviço no TextBox txtNome
                txtNomeServico.Text = selectedItem.Text;

                // Define o valor do serviço no TextBox txtValor
                txtValorServico.Text = selectedItem.Value;
            }

        }



        private void limparDados()
        {
            txtNomeServico.Text = "";
            txtValorServico.Text = "";
        }

        private Servico servicoForm()
        {
            string nome = txtNomeServico.Text;
            decimal valor = Convert.ToDecimal(txtValorServico.Text);

            Servico servico = new Servico(nome, valor);

            //Adicionando id da manicure responsável pela criação do serviço
            servico.IdManicure = (int)Session["idUsuario"];

            return servico;
        }



        // Após inserir um novo serviço com sucesso, esta função para atualiza o ListBox
        // Após inserir um novo serviço com sucesso, esta função para atualiza o ListBox
        private void AtualizarListBox()
        {
            // Obtenha a lista de serviços atualizada
            List<Servico> servicos = ServicosDao.ListarServicosPorManicure(IdUsuario);

            // Limpe o ListBox
            lbxServicos.Items.Clear();

            // Adicione os itens da lista de serviços atualizada ao ListBox
            foreach (Servico servico in servicos)
            {
                lbxServicos.Items.Add(new ListItem(servico.TipoServico, servico.ValorServico.ToString("N", System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR"))));
            }
            //msgErro.Visible = false;
            //msgSucesso.Visible = false;
        }


        // Inserir serviço
        protected void btnInserir_Click(object sender, EventArgs e)
        {
            ServicosDao.InserirServico(servicoForm());
            AtualizarListBox();
            limparDados();
        }

        // Editar serviço
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            //try
            //{
            ServicosDao servicosDao = new ServicosDao();

            string nomeServico = txtNomeServico.Text.Trim();
            decimal valorServico = Convert.ToDecimal(txtValorServico.Text.Trim());

            //Buscar o Id do servico
            int idServico = servicosDao.BuscarIdServico(nomeServico);

            if (idServico > 0)
            {
                // Atualizar o serviço usando o ID
                ServicosDao.EditarServico(idServico, nomeServico, valorServico);
                limparDados();
                AtualizarListBox();


                // Lógica adicional após a atualização, se necessário

                Response.Write("");
            }
            else
            {
                Response.Write("x''");
            }


        }

        // Logout
        protected void btnSair_Click1(object sender, EventArgs e)
        {
            Session["IdUsuario"] = null;
            Session["Tipo"] = null;
            Session.Abandon();
            Response.Redirect("index.aspx");

        }

        // Excluir um serviço
        protected void btnExcluir_Click(object sender, EventArgs e)
        {

            try
            {
                string tipo = txtNomeServico.Text.Trim();


                // Realiza a exclusão
                ServicosDao.ExcluirServico(tipo);
                MsgExcluido();
                AtualizarListBox();
                limparDados();

            }
            catch (Exception)
            {
                MsgErro();

            }
        }


        private void MsgExcluido()
        {
            // Registrando um script do lado do cliente para exibir um alerta após o postback
            string script = "alert('Item excluído com sucesso!');";
            ClientScript.RegisterStartupScript(this.GetType(), "MsgExcluido", script, true);

        }
        private void MsgErro()
        {
            string script = "alert('Não é possível excluir o serviço devido a agendamentos associados!');";
            ClientScript.RegisterStartupScript(this.GetType(), "MsgExcluido", script, true);

        }


        // Excluir um agendamento
        protected void btnCancelar_Click(object sender, EventArgs e)
        {

            //// Obtém o botão clicado que acionou o evento
            //Button btnCancelar = (Button)sender;

            //// Obtém o CommandArgument que contém o ID do agendamento a ser cancelado
            //string idAgendamento = btnCancelar.CommandArgument;
            ////btnCancelar.CommandArgument = Agendamento.idAgendamento.ToString(); // Defina o ID do agendamento como CommandArgument


            //AgendamentoDao.ExcluirAgendamento(Convert.ToInt32(idAgendamento));

            ////btnCancelar.OnClientClick = $"return confirmarExclusao('{idAgendamento}')";
            //Response.Redirect("perfil.aspx");

            // METODO 2
            //Button btnCancelar = (Button)sender;
            //string idAgendamento = btnCancelar.CommandArgument;

            //if (!string.IsNullOrEmpty(idAgendamento))
            //{
            //    try
            //    {
            //        int id = Convert.ToInt32(idAgendamento);
            //        AgendamentoDao.ExcluirAgendamento(id);

            //        // Atualize a página ou a tabela de agendamentos após a exclusão, se necessário
            //        Response.Redirect("perfil.aspx");
            //    }
            //    catch (Exception ex)
            //    {
            //        // Trate qualquer exceção aqui
            //        throw new Exception("Erro ao excluir" + ex);
            //    }
            //}

            // METODO 3
            //Agendamento agendamento = new Agendamento();

            //Button btn = (Button)sender;
            //string idAgendamento = btn.CommandArgument;


            //int idAgendamento = Convert.ToInt32(btnCancelarAgenda.Attributes["data-agendamento-id"]);

            // Obtém o ID do agendamento a partir do CommandArgument do botão
            //int idAgendamento = Convert.ToInt32("data-agendamento-id");
            //int idAgendamento = Convert.ToInt32(btnCancelar.CommandArgument);
            //string idAgendamento = btnCancelar.CommandArgument;

            //try
            //{
            //    // Chama o método ExcluirAgendamento da classe AgendamentoDao
            //    bool excluiuComSucesso = AgendamentoDao.ExcluirAgendamento(Convert.ToInt32(idAgendamento));

            //    if (excluiuComSucesso)
            //    {
            //        // Se a exclusão foi bem-sucedida, você pode atualizar a interface ou
            //        // qualquer outra ação necessária ap/ós a exclusão
            //        // AtualizarTabelaAgendamentos(); // Por exemplo, atualizar a tabela de agendamentos
            //        Response.Redirect("perfil.aspx");

            //    }
            //    else
            //    {
            //        // Trate aqui caso a exclusão não tenha sido bem-sucedida
            //    }
            //}
            //catch (Exception ex)
            //{
            //// Trate qualquer exceção aqui
            //throw new Exception("Erro ao excluir" + ex);
            //}

        }

        protected void btnCancelarAgendamento_Click(object sender, EventArgs e)
        {

        }

    }
    
}