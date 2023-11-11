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

        public static List<Servico> ListarServicosPorManicure(int idUsuario)
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

        // Metodo que edita ums serviço
        public static bool EditarServico(Servico servico)
        {
            bool resultado = false;

            try
            {
                int retorno;
                //string comandoSql = "UPDATE servicos SET valorServico = @valor WHERE tipoServico LIKE @tipo";
                string comandoSql = "UPDATE servicos SET tipoServico = @tipo, valorServico = @valor WHERE idServico = usuario.id";

                //string comandoSql = "UPDATE servicos SET valorServico = @valor WHERE tipoServico = @tipo";

                //string comandoSql = "UPDATE servicos SET tipoServico=@tipo, valorServico=@valor WHERE idServico LIKE @id";
                SqlCommand comando = new SqlCommand(comandoSql, Conexao.GetConexao());

                // Configuração dos parâmetros do comando SQL
                SqlParameter id = new SqlParameter("@id", System.Data.SqlDbType.Int, 0);
                SqlParameter tipo = new SqlParameter("@tipo", System.Data.SqlDbType.Text, 25);
                SqlParameter valor = new SqlParameter("@valor", System.Data.SqlDbType.Float);

                // Atribuição dos valores aos parâmetros do comando SQL
                id.Value = servico.IdServico;
                tipo.Value = servico.TipoServico;
                valor.Value = servico.ValorServico;

                // Adição dos parâmetros ao comando SQL
                comando.Parameters.Add(id);
                comando.Parameters.Add(tipo);
                comando.Parameters.Add(valor);

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

        public static bool ValidarExcluirServico(int idServico)
        {
            // Consulta para verificar se há agendamentos associados ao serviço
            string consultaAgendamentos = "SELECT COUNT(*) FROM agendamento WHERE idServico = @idServico";

            using (SqlConnection conexao = Conexao.GetConexao())
            using (SqlCommand comando = new SqlCommand(consultaAgendamentos, conexao))
            {
                comando.Parameters.AddWithValue("@idServico", idServico);

                // Obtém o número de agendamentos associados ao serviço
                int numeroAgendamentos = (int)comando.ExecuteScalar();

                // Se houver agendamentos, não permita a exclusão
                return numeroAgendamentos == 0;
            }
        }
        //public static bool ExcluirServico(string tipo)
        //{
        //    if (ValidarExcluirServico(int idServico))

        //    {
        //        // Comando SQL
        //        string comandoSql = "DELETE FROM servicos WHERE tipoServico LIKE @tipo";

        //        using (SqlConnection conexao = Conexao.GetConexao())
        //        using (SqlCommand comando = new SqlCommand(comandoSql, conexao))
        //        {
        //            // Configuração dos parâmetros do comando SQL
        //            SqlParameter tipoServico = new SqlParameter("@tipo", System.Data.SqlDbType.Text, 25);

        //            // Atribuição dos valores aos parâmetros do comando SQL
        //            tipoServico.Value = tipo;

        //            // Adição dos parâmetros ao comando SQL
        //            comando.Parameters.Add(tipoServico);

        //            // Executa o comando de exclusão
        //            int linhasAfetadas = comando.ExecuteNonQuery();

        //            // Retorna true se a exclusão foi bem-sucedida
        //            return linhasAfetadas > 0;
        //        }
        //    }else
        //    {
        //        // Se houver agendamentos, não permita a exclusão
        //        return false;
        //    }
        //}


        //public static bool ExcluirServico(string tipo)
        //{
        //    bool resultado = false;

        //    try
        //    {
        //        // Comando SQL
        //        string comandoSql = "DELETE FROM servicos WHERE tipoServico LIKE @tipo";

        //        using (SqlConnection conexao = Conexao.GetConexao())
        //        using (SqlCommand comando = new SqlCommand(comandoSql, conexao))
        //        {
        //            // Configuração dos parâmetros do comando SQL
        //            SqlParameter tipoServico = new SqlParameter("@tipo", System.Data.SqlDbType.Text, 25);

        //            // Atribuição dos valores aos parâmetros do comando SQL
        //            tipoServico.Value = tipo;

        //            // Adição dos parâmetros ao comando SQL
        //            comando.Parameters.Add(tipoServico);

        //            // Executa o comando e obtém o número de linhas afetadas
        //            int retorno = comando.ExecuteNonQuery();

        //            // Define o resultado com base no número de linhas afetadas
        //            resultado = retorno > 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Tratar a exceção apropriadamente, por exemplo, registrar a exceção ou lançar novamente
        //        throw new Exception("Erro ao excluir serviço", ex);
        //    }

        //    return resultado;
        //}

        public static bool ExcluirServico(string tipo)
        {
            bool resultado = false;

            try
            {
                // Comando SQL
                string comandoSql = "DELETE FROM servicos WHERE tipoServico LIKE @tipo";

                using (SqlConnection conexao = Conexao.GetConexao())
                using (SqlCommand comando = new SqlCommand(comandoSql, conexao))
                {
                    // Configuração dos parâmetros do comando SQL
                    SqlParameter tipoServico = new SqlParameter("@tipo", System.Data.SqlDbType.Text, 25);

                    // Atribuição dos valores aos parâmetros do comando SQL
                    tipoServico.Value = tipo;

                    // Adição dos parâmetros ao comando SQL
                    comando.Parameters.Add(tipoServico);

                    // Executa o comando e obtém o número de linhas afetadas
                    int retorno = comando.ExecuteNonQuery();

                    // Define o resultado com base no número de linhas afetadas
                    resultado = retorno > 0;
                }
            }
            catch (Exception ex)
            {
                // Tratar a exceção apropriadamente, por exemplo, registrar a exceção ou lançar novamente
                throw new Exception("Erro ao excluir serviço", ex);
            }

            return resultado;
        }


    }
}
