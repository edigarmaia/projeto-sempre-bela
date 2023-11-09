using System;

namespace SempreBela
{
    public partial class servicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validação verificando se há valores guardados na sessão. Caso tenha, significa que o usuário está logado, caso não tenha, o usuário é redirecionado para o login. 
            //if (Session.Keys.Count == 0)
            //    Response.Redirect("login.aspx");
        }
    }
}