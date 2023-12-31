﻿using Mecanismo.Dao;
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
            int selectedIndex = lbxServicos.SelectedIndex;

            if (selectedIndex >= 0)
            {
                // Obtém o serviço selecionado na ListBox
                //Servico servicoSelecionado = ServicosDao.ListarServicosPorManicure(IdUsuario)[selectedIndex];
                Servico servicoSelecionado = ServicosDao.ListarServicosManicureSemPreco(IdUsuario)[selectedIndex];

                // Preenche os campos com os valores do serviço selecionado
                txtNomeServico.Text = servicoSelecionado.TipoServico;
                txtValorServico.Text = servicoSelecionado.ValorServico.ToString("N", System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR"));
                txtIdServico.Text = servicoSelecionado.IdServico.ToString();
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
            //List<Servico> servicos = ServicosDao.ListarServicosPorManicure(IdUsuario);
            List<Servico> servicos = ServicosDao.ListarServicosManicureSemPreco(IdUsuario);


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

        // Editar serviço pelo id
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            //try
            //{
            ServicosDao servicosDao = new ServicosDao();

            string nomeServico = txtNomeServico.Text.Trim();
            decimal valorServico = Convert.ToDecimal(txtValorServico.Text.Trim());

            //Buscar o Id do servico
            int idServico = Convert.ToInt32(txtIdServico.Text);
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
                int idServico = Convert.ToInt32(txtIdServico.Text.Trim());
                // Realiza a exclusão
                ServicosDao.ExcluirServico(idServico);
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


        //// Excluir um agendamento
        //protected void btnExcluirAgendamento_Click(object sender, EventArgs e)
        //{

        //    //inicio pegar id
        //    Button btn = (Button)sender;
        //    var arg = btn.CommandArgument;
        //    int idAgendamento = int.Parse(arg.ToString());
        //    Console.WriteLine(idAgendamento);
        //}

        private void MsgCancelarAgenda()
        {
            // Registrando um script do lado do cliente para exibir um alerta após o postback
            string script = "alert('Agendamento excluído com sucesso!');";
            ClientScript.RegisterStartupScript(this.GetType(), "MsgExcluidoAgenda", script, true);

        }
      
        protected void btnCancelarAgendamento_Click(object sender, EventArgs e)
        {
            MsgCancelarAgenda();
            Response.Redirect("perfil.aspx");
            //Button btn = (Button)sender;
            //string idAgendamento = btn.CommandArgument;

            //lblStatus.InnerText = idAgendamento;

            ////inicio pegar id
            //Button btn = (Button)sender;
            //var arg = btn.CommandArgument;
            //int idAgendamento2 = int.Parse(arg.ToString());
            //string idAgendamento = arg.ToString();
            //Console.WriteLine(idAgendamento2);
            //lblStatus.InnerText = idAgendamento.ToString();


        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            //txtNomeServico.Text = "";
            //txtValorServico.Text = "";
            limparDados();
        }
    }

}