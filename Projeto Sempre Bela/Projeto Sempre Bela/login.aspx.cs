using Mecanismo.Dao;
using Mecanismo.Dao.DaoUsuarios;
using SempreBela.DaoClientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SempreBela
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Recuperando valores dos TextBox
            var email = txtEmail.Text;
            var senha = txtSenha.Text;

            //Chamando a DAO para validar o login
            var login = UsuariosDao.ValidarLogin(email, senha);

            //Caso o login não seja feito com êxito, a propriedade de nome "msgErro" será renderizado no front, informando que o usuário ou a senha estão incorretos
            if (login == null)
            {
                msgErro.Visible = true;
                return;
            }

            //A sessão é responsável por salvar valores no navegador do cliente, permitindo assim que esses valores sejam recuperados e manipulados de qualquer lugar da aplicação
            //Setando as variáveis de sessão responsáveis pelo controle de acesso do sistema, sendo elas:
            Session["idUsuario"] = login.IdUsuario; // id do usuário logado
            Session["nome"] = login.Nome; // nome do usuário
            Session["tipo"] = login.Tipo; // tipo de usuário (Cliente e Manicure)

            //Redirecionando para a página principal
            Response.Redirect("perfil.aspx");
        }


    }
}