using Mecanismo.Dao.DaoEnderecos;
using System.Data.SqlClient;

namespace Mecanismo.Dao.DaoUsuarios
{
    public class Usuario
    {
        private int idUsuario;
        private string nome;
        private string telefone;
        private string email;
        private string senha;
        private string cpf;
        private int tipo;
        private Endereco endereco;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Email { get => email; set => email = value; }
        public string Senha { get => senha; set => senha = value; }
        public int Tipo { get => tipo; set => tipo = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public Endereco Endereco { get => endereco; set => endereco = value; }


        public static Usuario MapCliente(SqlDataReader leitor)
        {
            return new Usuario(
                idUsuario: (int)leitor["idUsuario"],
                nome: leitor["nome"].ToString(),
                telefone: leitor["telefone"].ToString(),
                cpf: leitor["cpf"].ToString(),
                tipo: 1);
        }

        public static Usuario MapManicure(SqlDataReader leitor)
        {
            return new Usuario(
                idUsuario: (int)leitor["idUsuario"],
                nome: leitor["nome"].ToString(),
                telefone: leitor["telefone"].ToString(),
                cpf: leitor["cpf"].ToString(),
                tipo: 2);
        }

        public Usuario()
        {

        }

        public Usuario(int idUsuario, string nome, int tipo)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Tipo = tipo;
        }

        public Usuario(int idUsuario, string nome, string telefone, string cpf, int tipo)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Telefone = telefone;
            Cpf = cpf;
            Tipo = tipo;
        }
        

        public Usuario(string nome, string telefone, string email, string senha, int tipo, Endereco endereco)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Senha = senha;
            Tipo = tipo;
            Endereco = endereco;
        }
        public Usuario(string nome, string telefone, string cpf,string email, string senha, int tipo)
        {
            Nome = nome;
            Telefone = telefone;
            Cpf = cpf;
            Email = email;
            Senha = senha;
            Tipo = tipo;
        }
    }
}
