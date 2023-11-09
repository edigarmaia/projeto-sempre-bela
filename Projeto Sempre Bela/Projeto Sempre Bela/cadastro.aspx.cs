using System;
using Mecanismo.Dao;
using SempreBela.DaoClientes;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mecanismo.Dao.DaoUsuarios;
using Mecanismo.Dao.DaoEnderecos;
using Mecanismo.Enums;
using System.ComponentModel;

namespace SempreBela
{
    public partial class cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void limparDados()
        {
            txtNome.Text = "";
            txtTelefone.Text = "";
            txtCpf.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
            txtRua.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            txtBairro.Text = "";
            txtCep.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";

        }
        private Usuario usuarioForm()
        {
            string nome = txtNome.Text;
            string telefone = txtTelefone.Text;
            string cpf = txtCpf.Text;
            string email = txtEmail.Text;
            string senha = txtSenha.Text;

            //Usar ternário deixa o código mais legível
            int tipo = rbCliente.Checked ? 1 : rbManicure.Checked ? 2 : 0;

            //int tipo = 0;
            //if (rbCliente.Checked)
            //{
            //    tipo = 1;
            //}
            //else if(rbManicure.Checked)
            //{
            //    tipo = 2;
            //}


            Usuario usuario = new Usuario(nome, telefone, cpf, email, senha, tipo);


            return usuario;
        }


        private Endereco enderecoForm(int usuarioId)
        {
            string rua = txtRua.Text;
            string numero = txtNumero.Text;
            string complemento = txtComplemento.Text;
            string bairro = txtBairro.Text;
            string cep = txtCep.Text;
            string cidade = txtCidade.Text;
            string estado = txtEstado.Text;


            Endereco endereco = new Endereco(rua, numero, complemento, bairro, cep, cidade, estado, usuarioId);

            return endereco;

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            //Retirei a condicional pq estavam fazendo a mesma coisa.
            var usuarioId = UsuariosDao.InserirUsuario(usuarioForm());
            EnderecoDao.InserirEndereco(enderecoForm(usuarioId));
            limparDados();

            Response.Redirect("perfil.aspx");
        }
    }
}