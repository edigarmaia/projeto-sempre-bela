using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;


namespace SempreBela.DaoClientes
{
    public class Conexao
    {

        // Atributo de escopo de classe (static) que armazena uma única conexão com o
        // banco de dados. Estamos usando um Padrão de Projeto Singleton.
        private static SqlConnection conn = null;

        // Banco sql server
        private static string connString = @"Data Source=.\SQLEXPRESS;Initial Catalog=bd_agencia;Integrated Security=True;TrustServerCertificate=True";

        // Padrão de Projeto Factory Method para terminar o padrão  Singleton. É o método
        // que devolve a mesma instância do objeto conn
        public static SqlConnection GetConexao()
        {
            conn = new SqlConnection(connString);
            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                conn = null;
                TextWriter erro = Console.Error;
                erro.WriteLine("********************* Depuração *****************\n" + ex.Message);
            }

            return conn;
        }
        public static void CloseConexao()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }

    }
}