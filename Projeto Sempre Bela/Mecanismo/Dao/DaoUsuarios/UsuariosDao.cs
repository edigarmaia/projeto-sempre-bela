using SempreBela.DaoClientes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Mecanismo.Dao.DaoUsuarios
{
    public class UsuariosDao
    {
        // Método que valida o login
        public static Usuario ValidarLogin(string email, string senha)
        {
            try
            {
                // Recuperando nome e tipo de usuário para manipular em outras partes do sistema.
                string comandoSql = "SELECT idUsuario, nome, idTipoUsuario FROM usuarios WHERE email = @Email AND senha = @Senha";
                SqlCommand comando = new SqlCommand(comandoSql, Conexao.GetConexao());

                comando.Parameters.AddWithValue("@Email", email);
                comando.Parameters.AddWithValue("@Senha", senha);

                var leitor = comando.ExecuteReader();

                while (leitor.Read())
                    //Utilizando construtor com parâmetro nomeado
                    return new Usuario(idUsuario: (int)leitor["idUsuario"], nome: leitor["nome"].ToString(), tipo: (int)leitor["idTipoUsuario"]);

                return null;
            }
            catch (Exception ex)
            {
                //tratar erros aqui
                return null;
            }

        }

        // Método que lista manicures
        public static List<Usuario> ListarManicures()
        {
            try
            {
                List<Usuario> manicures = new List<Usuario>();
                string comandoSql = "SELECT idUsuario, nome, telefone, cpf FROM usuarios WHERE idTipoUsuario = 2";
                SqlCommand comando = new SqlCommand(comandoSql, Conexao.GetConexao());

                var leitor = comando.ExecuteReader();

                while (leitor.Read())
                    manicures.Add(Usuario.MapManicure(leitor));

                return manicures;
            }
            catch (Exception ex)
            {
                //tratar erros aqui
                return null;
            }

        }


        // Validar cpf
        public static bool ValidaCpf(string cpf)
        {
            string comandoSql = "SELECT COUNT(*) FROM usuarios WHERE cpf = @cpf";
            using (SqlConnection conexao = Conexao.GetConexao())
            {
                using (SqlCommand comando = new SqlCommand(comandoSql, conexao))
                {
                    
                    SqlParameter cpfUsuario = new SqlParameter("@cpf", SqlDbType.VarChar, 11);
                    cpfUsuario.Value = cpf;
                    comando.Parameters.Add(cpfUsuario);

                    try
                    {
                        //conexao.Open();
                        int count = (int)comando.ExecuteScalar();
                        return count > 0;
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro ao validar CPF: " + ex.Message);
                    }
                }
            }
        }

        // Metodo que valida e-mail já cadastrado
        public static bool ValidaEmail(string email)
        {
            string comandoSql = "SELECT COUNT(*) FROM usuarios WHERE email = @email";
            using (SqlConnection conexao = Conexao.GetConexao())
            {
                using (SqlCommand comando = new SqlCommand(comandoSql, conexao))
                {
                    SqlParameter emailUsuario = new SqlParameter("@email", SqlDbType.VarChar, 50);
                    emailUsuario.Value = email;
                    comando.Parameters.Add(emailUsuario);

                    try
                    {
                        //conexao.Open();
                        int count = (int)comando.ExecuteScalar();
                        return count > 0;
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro ao validar e-mail: " + ex.Message);
                    }
                }
            }

        }


        // Método que insere um usuario
        public static int InserirUsuario(Usuario usuario)
        {

            // Comando Sql
            string comandoSql = @"INSERT INTO usuarios (nome, telefone, cpf, email, senha, idTipoUsuario) 
                                  VALUES (@nome, @telefone, @cpf, @email, @senha, @tipo); 
                                  SELECT SCOPE_IDENTITY();";

            // Comando
            SqlCommand comando = new SqlCommand(comandoSql, Conexao.GetConexao());

            // Configuração dos parâmetros do comando SQL
            SqlParameter nomeUsuario = new SqlParameter("@nome", System.Data.SqlDbType.Text, 50);
            SqlParameter telefoneUsuario = new SqlParameter("@telefone", System.Data.SqlDbType.Text, 20);
            SqlParameter cpfUsuario = new SqlParameter("@cpf", System.Data.SqlDbType.Text, 11);
            SqlParameter emailUsuario = new SqlParameter("@email", System.Data.SqlDbType.Text, 50);
            SqlParameter senhaUsuario = new SqlParameter("@senha", System.Data.SqlDbType.Text, 20);
            SqlParameter tipoUsuario = new SqlParameter("@tipo", System.Data.SqlDbType.Int);

            // Atribuição dos valores aos parâmetros do comando SQL
            nomeUsuario.Value = usuario.Nome;
            telefoneUsuario.Value = usuario.Telefone;
            cpfUsuario.Value = usuario.Cpf;
            emailUsuario.Value = usuario.Email;
            senhaUsuario.Value = usuario.Senha;
            tipoUsuario.Value = usuario.Tipo;

            // Adição dos parâmetros ao comando SQL
            comando.Parameters.Add(nomeUsuario);
            comando.Parameters.Add(telefoneUsuario);
            comando.Parameters.Add(cpfUsuario);
            comando.Parameters.Add(emailUsuario);
            comando.Parameters.Add(senhaUsuario);
            comando.Parameters.Add(tipoUsuario);


            // Compila a instrução e a submete ao banco de dados
            comando.Prepare();
            int idUsuario = Convert.ToInt32(comando.ExecuteScalar());

            comando.Dispose();

            return idUsuario;

        }
        
    }
}
    





