using Mecanismo.Dao.DaoAgendamento;
using Mecanismo.Dao.DaoServicos;
using Mecanismo.Dao.DaoUsuarios;
using Mecanismo.Enums;
using SempreBela.Dao.DaoAgendamento;
using System;
using System.Web.UI.WebControls;

namespace SempreBela
{
    public partial class agendamento : System.Web.UI.Page
    {
        protected TipoPerfil TipoPerfil;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validação verificando se há valores guardados na sessão. Caso tenha, significa que o usuário está logado, caso não tenha, o usuário é redirecionado para o login. 
            if (Session.Keys.Count == 0)
                Response.Redirect("login.aspx");

            //Populando Select de manicures
            if (!IsPostBack)
            {
                ddlManicure.DataSource = UsuariosDao.ListarManicures();
                ddlManicure.DataTextField = "Nome";
                ddlManicure.DataValueField = "IdUsuario";
                ddlManicure.DataBind();
                ddlManicure.Items.Insert(0, new ListItem("Selecione uma manicure", "NA"));
            }
        }

        protected void btnAgendar_Click(object sender, EventArgs e)
        {
            DateTime dataAgendamento = DateTime.Parse(txtDataAgendamento.Text);
            string localAgendamento = txtLocalAgendamento.Text;
            int idServico = int.Parse(ddlServico.SelectedValue);
            int idManicure = int.Parse(ddlManicure.SelectedValue);
            int idCliente = (int)Session["idUsuario"];

            // Verificar se há um agendamento ativo que bloqueia os próximos 30 minutos
            DateTime fimAgendamento;
            if (AgendamentoDao.ValidarAgendamento(idManicure, dataAgendamento, out fimAgendamento))
            {
                MsgErro($"Já existe um agendamento ativo. O próximo horário disponível é a partir de {fimAgendamento.ToString("HH:mm")}");
            }
           
            else
            {
                AgendamentoDao.InserirAgendamento(new Agendamento(dataAgendamento, localAgendamento, idServico, idManicure, idCliente));
                Response.Redirect("perfil.aspx");
            }
            }

            protected void ddlManicure_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Evento de clique do select de manicures que, quando uma manicure é selecionada, o id relativo é capturado e é utilizado para filtrar o Select de serviços,
            //assim exibindo somente os serviços cadastrados pela manicure em questão.
            ddlServico.DataSource = ServicosDao.ListarServicosPorManicure(int.Parse(ddlManicure.SelectedValue));
            ddlServico.DataTextField = "TipoServico";
            ddlServico.DataValueField = "IdServico";
            ddlServico.DataBind();
            ddlServico.Items.Insert(0, new ListItem("Selecione um serviço", "NA"));
        }

      
        private void MsgErro(string mensagem = "Erro no agendamento.")
        {
            lblErro.Text = mensagem;
            lblErro.Visible = true;
        }

    }
}