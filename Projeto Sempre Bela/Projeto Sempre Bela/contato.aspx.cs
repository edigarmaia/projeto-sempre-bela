using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SempreBela
{
    public partial class contato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void limparDados()
        {
            txtNome.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            txtAssunto.Text = "";
            txtMensagem.Text = "";
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if((txtNome.Text != null) && (txtEmail.Text != null) && (txtTelefone.Text != null) && (txtAssunto.Text != null) && (txtMensagem.Text != null))
            {
                limparDados();
                MsgEnviadoSucesso();
                //msgSucesso.Visible = true;
            }
            else
            {
                //msgErro.Visible = true;
                //msgSucesso.Visible = false;
            }
            
          
            
        }
        private void MsgEnviadoSucesso()
        {
            string script = "alert('Mensagem enviada com sucesso!');";
            ClientScript.RegisterStartupScript(this.GetType(), "MsgEnviadoSucesso", script, true);

        }
    }
}