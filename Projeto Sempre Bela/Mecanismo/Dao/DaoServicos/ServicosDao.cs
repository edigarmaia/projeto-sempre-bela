using SempreBela.DaoClientes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Mecanismo.Dao.DaoServicos
{
    public class ServicosDao
    {

        // Método que insere um servico
        public static bool InserirServico(Servico servico)
        {
            bool resultado = false;
            int retorno;

            // Comando Sql
            string comandoSql = "INSERT INTO servicos (tipoServico, valorServico, idManicure) VALUES (@tipoServico, @valorServico, @idManicure)";

            // Comando
            SqlCommand comando = new SqlCommand(comandoSql, Conexao.GetConexao());

            // Configuração dos parâmetros do comando SQL
            SqlParameter tipoServico = new SqlParameter("@tipoServico", System.Data.SqlDbType.Text, 25);
            SqlParameter valorServico = new SqlParameter("@valorServico", System.Data.SqlDbType.Float);
            SqlParameter idManicure = new SqlParameter("@idManicure", System.Data.SqlDbType.Int);


            // Atribuição dos valores aos parâmetros do comando SQL
            tipoServico.Value = servico.TipoServico;
            valorServico.Value = servico.ValorServico;
            idManicure.Value = servico.IdManicure;

            // Adição dos parâmetros ao comando SQL
            comando.Parameters.Add(tipoServico);
            comando.Parameters.Add(valorServico);
            comando.Parameters.Add(idManicure);

            // Compila a instrução e a submete ao banco de dados
            comando.Prepare();
            retorno = comando.ExecuteNonQuery();

            if (retorno > 0)
                resultado = true;

            comando.Dispose();

            return resultado;
        }
        // Criar uma lista de serviços
        public static List<Servico> ListarServicos()
        {
            List<Servico> servicos = new List<Servico>();

            string comandoSql = "SELECT idServico, tipoServico, valorServico FROM servicos";
            SqlCommand comando = new SqlCommand(comandoSql, Conexao.GetConexao());

            // Compila a instrução e a submete ao banco de dados
            comando.Prepare();
            SqlDataReader leitor = comando.ExecuteReader();

            // Recupera os dados retornados pelo banco de dados
            while (leitor.Read())
                servicos.Add(Servico.MapServico(leitor));

            leitor.Close();
            comando.Dispose();

            return servicos;
        }

        // listar serviços por manicure, trazendo junto o valor do serviço
        public static List<Servico> ListarServicosPorManicure(int idUsuario)
        {
            List<Servico> servicos = new List<Servico>();

            //string comandoSql = "SELECT idServico, tipoServico, valorServico FROM servicos WHERE idManicure = @idUsuario";

            string comandoSql = "SELECT idServico, tipoServico + ' - R$ ' + FORMAT(valorServico, 'N2') AS tipoServico, valorServico FROM servicos WHERE idManicure = @idUsuario";
            SqlCommand comando = new SqlCommand(comandoSql, Conexao.GetConexao());

            SqlParameter idManicure = new SqlParameter("@idUsuario", System.Data.SqlDbType.Int);


            // Atribuição dos valores aos parâmetros do comando SQL
            idManicure.Value = idUsuario;

            // Adição dos parâmetros ao comando SQL
            comando.Parameters.Add(idManicure);

            // Compila a instrução e a submete ao banco de dados
            comando.Prepare();
            SqlDataReader leitor = comando.ExecuteReader();

            // Recupera os dados retornados pelo banco de dados
            while (leitor.Read())
                servicos.Add(Servico.MapServico(leitor));

            leitor.Close();
            comando.Dispose();

            return servicos;
        }
        
        // Listar serviços por manicure sem o valor
        public static List<Servico> ListarServicosManicureSemPreco(int idUsuario)
        {
            List<Servico> servicos = new List<Servico>();
            string comandoSql = "SELECT idServico, tipoServico, valorServico FROM servicos WHERE idManicure = @idUsuario";

            SqlCommand comando = new SqlCommand(comandoSql, Conexao.GetConexao());

            SqlParameter idManicure = new SqlParameter("@idUsuario", System.Data.SqlDbType.Int);


            // Atribuição dos valores aos parâmetros do comando SQL
            idManicure.Value = idUsuario;

            // Adição dos parâmetros ao comando SQL
            comando.Parameters.Add(idManicure);

            // Compila a instrução e a submete ao banco de dados
            comando.Prepare();
            SqlDataReader leitor = comando.ExecuteReader();

            // Recupera os dados retornados pelo banco de dados
            while (leitor.Read())
                servicos.Add(Servico.MapServico(leitor));

            leitor.Close();
            comando.Dispose();

            return servicos;

        }


     
        // Metodo que edita um serviço pelo id
        public static bool EditarServico(int id, string nome, decimal valor)
        {
            bool resultado = false;

            try
            {
                int retorno;
                string comandoSql = "UPDATE servicos SET tipoServico = @tipo, valorServico = @valor WHERE idServico = @id";

                SqlCommand comando = new SqlCommand(comandoSql, Conexao.GetConexao());

                // Configuração dos parâmetros do comando SQL
                SqlParameter idServico = new SqlParameter("@id", System.Data.SqlDbType.Int, 0);
                SqlParameter tipoServico = new SqlParameter("@tipo", System.Data.SqlDbType.Text, 25);
                SqlParameter valorServico = new SqlParameter("@valor", System.Data.SqlDbType.Float);

                // Atribuição dos valores aos parâmetros do comando SQL
                idServico.Value = id;
                tipoServico.Value = nome;
                valorServico.Value = valor;

                // Adição dos parâmetros ao comando SQL
                comando.Parameters.Add(idServico);
                comando.Parameters.Add(tipoServico);
                comando.Parameters.Add(valorServico);

                // Compila a instrução e a submete ao banco de dados
                comando.Prepare();
                retorno = comando.ExecuteNonQuery();

                if (retorno > 0)
                {
                    resultado = true;
                }
                comando.Dispose();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao atualizar serviço" + ex);
            }
            return resultado;
        }

        // Metodo que exclui um servico pelo id
        public static bool ExcluirServico(int id)
        {
            bool resultado = false;

            try
            {
                // Comando SQL
                string comandoSql = "DELETE FROM servicos WHERE idServico = @id";

                using (SqlConnection conexao = Conexao.GetConexao())
                using (SqlCommand comando = new SqlCommand(comandoSql, conexao))
                {
                    // Configuração dos parâmetros do comando SQL
                    SqlParameter idServico = new SqlParameter("@id", System.Data.SqlDbType.Int);

                    // Atribuição dos valores aos parâmetros do comando SQL
                    idServico.Value = id;

                    // Adição dos parâmetros ao comando SQL
                    comando.Parameters.Add(idServico);

                    // Executa o comando e obtém o número de linhas afetadas
                    int retorno = comando.ExecuteNonQuery();

                    // Define o resultado com base no número de linhas afetadas
                    resultado = retorno > 0;
                }
            }
            catch (Exception ex)
            {
                // Tratar a exceção
                throw new Exception("Erro ao excluir serviço", ex);
            }

            return resultado;
        }
    }

}
