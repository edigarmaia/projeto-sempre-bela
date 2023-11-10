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
            //Utilizando os inputs, valores capturados no select e o id do cliente logado para cadastrar um agendamento.
            AgendamentoDao.InserirAgendamento(new Agendamento(
                dataAgendamento: DateTime.Parse(txtDataAgendamento.Text),
                localAgendamento: txtLocalAgendamento.Text,
                idServico: int.Parse(ddlServico.SelectedValue),
                idManicure: int.Parse(ddlManicure.SelectedValue),
                idCliente: (int)Session["idUsuario"])
            );

            Response.Redirect("perfil.aspx");
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
    }
}