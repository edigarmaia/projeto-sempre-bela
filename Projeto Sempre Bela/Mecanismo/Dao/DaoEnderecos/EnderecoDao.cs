using SempreBela.DaoClientes;
using System.Data.SqlClient;

namespace Mecanismo.Dao.DaoEnderecos
{
    public class EnderecoDao
    {
        // Método que insere um endereço
        public static bool InserirEndereco(Endereco endereco)
        {
            bool resultado = false;
            int retorno;

            // Comando Sql
            string comandoSql = @"INSERT INTO enderecos (rua, numero, complemento, bairro, cep, cidade, estado, idUsuario)
                                VALUES (@rua, @numero, @complemento, @bairro, @cep, @cidade, @estado, @idUsuario);";


            // Comando
            SqlCommand comando = new SqlCommand(comandoSql, Conexao.GetConexao());

            // Configuração dos parâmetros do comando SQL
            SqlParameter ruaEndereco = new SqlParameter("@rua", System.Data.SqlDbType.Text, 50);
            SqlParameter numeroEndereco = new SqlParameter("@numero", System.Data.SqlDbType.Text, 10);
            SqlParameter complementoEndereco = new SqlParameter("@complemento", System.Data.SqlDbType.Text, 50);
            SqlParameter bairroEndereco = new SqlParameter("@bairro", System.Data.SqlDbType.Text, 30);
            SqlParameter cepEndereco = new SqlParameter("@cep", System.Data.SqlDbType.Text, 90);
            SqlParameter cidadeEndereco = new SqlParameter("@cidade", System.Data.SqlDbType.Text, 50);
            SqlParameter estadoEndereco = new SqlParameter("@estado", System.Data.SqlDbType.Text, 50);
            SqlParameter idUsuarioEndereco = new SqlParameter("@idUsuario", System.Data.SqlDbType.Int);

            // Atribuição dos valores aos parâmetros do comando SQL
            ruaEndereco.Value = endereco.Rua;
            numeroEndereco.Value = endereco.Numero;
            complementoEndereco.Value = endereco.Complemento;
            bairroEndereco.Value = endereco.Bairro;
            cepEndereco.Value = endereco.Cep;
            cidadeEndereco.Value = endereco.Cidade;
            estadoEndereco.Value = endereco.Estado;
            idUsuarioEndereco.Value = endereco.IdUsuario;
       

            // Adição dos parâmetros ao comando SQL
            comando.Parameters.Add(ruaEndereco);
            comando.Parameters.Add(numeroEndereco);
            comando.Parameters.Add(complementoEndereco);
            comando.Parameters.Add(bairroEndereco);
            comando.Parameters.Add(cepEndereco);
            comando.Parameters.Add(cidadeEndereco);
            comando.Parameters.Add(estadoEndereco);
            comando.Parameters.Add(idUsuarioEndereco);


            // Compila a instrução e a submete ao banco de dados
            comando.Prepare();
            retorno = comando.ExecuteNonQuery();

            if (retorno > 0)
            {
                resultado = true;
            }
            comando.Dispose();

            return resultado;

        }
    }
}



