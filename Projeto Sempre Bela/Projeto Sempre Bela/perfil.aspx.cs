using Mecanismo.Dao;
using Mecanismo.Dao.DaoAgendamento;
using Mecanismo.Dao.DaoServicos;
using Mecanismo.Enums;
using SempreBela.Dao.DaoAgendamento;
using System;
using System.Collections.Generic;
using System.Web.Optimization;
using System.Web.Security;
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

                // Adicionar os itens da lista de serviços ao ListBox
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

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            ServicosDao.InserirServico(servicoForm());
            AtualizarListBox();
            limparDados();
        }

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

                    Response.Write("Atualização bem-sucedida!");
                }
                else
                {
                    Response.Write("Serviço não encontrado.");
                }
            //}
            //catch (Exception ex)
            //{
            //    // Tratar exceções
            //    Response.Write("Erro durante a atualização: " + ex.Message);
            //}

            //// Obtém o índice do item selecionado no ListBox
            //int selectedIndex = lbxServicos.SelectedIndex;

            //if (selectedIndex >= 0)
            //{
            //    // Obtém o item selecionado
            //    ListItem selectedItem = lbxServicos.Items[selectedIndex];

            //    ServicosDao.EditarServico(servicoForm());
            //}
            //    ServicosDao.EditarServico(servicoForm());
            //    //limparDados();
            //    AtualizarListBox();
        }




        // Logout
        protected void btnSair_Click1(object sender, EventArgs e)
        {
            Session["IdUsuario"] = null;
            Session["Tipo"] = null;
            Session.Abandon();
            Response.Redirect("index.aspx");

        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            //string tipo = txtNomeServico.Text;

            //// Tenta excluir o serviço
            //bool exclusaoBemSucedida = ServicosDao.ExcluirServico(tipo);

            //if (exclusaoBemSucedida)
            //{
            //    AtualizarListBox();
            //    limparDados();
            //    msgSucesso.Visible = true;
            //}
            //else
            //{
            //    msgErro.Visible = true;

            //}
            ////ServicosDao.ExcluirServico(tipo);
            ////AtualizarListBox();
            ////limparDados();
            ///
            //try
            //{
            //    MsgExcluido();
            //    string tipo = txtNomeServico.Text;
            //    ServicosDao.ExcluirServico(tipo);
            //    AtualizarListBox();
            //    limparDados();


            //}
            //catch(Exception ex) 
            //{
            //    msgSucesso.Visible = false;
            //    msgErro.Visible = true;

            //}

            try
            {
                string tipo = txtNomeServico.Text;


                // Realiza a exclusão
                ServicosDao.ExcluirServico(tipo);
                MsgExcluido();
                AtualizarListBox();
                limparDados();

            }
            catch (Exception ex)
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

        protected void btnStatus_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Cancelado";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            btnStatus.ForeColor = System.Drawing.Color.Red; 
            btnStatus.Visible = false;
        }
    }
}