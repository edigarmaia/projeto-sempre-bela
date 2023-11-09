using Mecanismo.Enums;
using SempreBela.Dao.DaoAgendamento;
using SempreBela.DaoClientes;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Mecanismo.Dao.DaoAgendamento
{
    public class AgendamentoDao
    {
        public static bool InserirAgendamento(Agendamento agendamento)
        {
            bool resultado = false;
            int retorno;

            string comandoSql = "INSERT INTO agendamento (dataAgendamento, localAgendamento, idManicure, idServico, idCliente) " +
                "VALUES (@dataAgendamento, @localAgendamento, @idManicure, @idServico, @idCliente)";

            SqlCommand comando = new SqlCommand(comandoSql, Conexao.GetConexao());

            SqlParameter dataAgendamento = new SqlParameter("@dataAgendamento", SqlDbType.DateTime);
            SqlParameter localAgendamento = new SqlParameter("@localAgendamento", SqlDbType.VarChar, 50);
            SqlParameter idManicure = new SqlParameter("@idManicure", SqlDbType.Int);
            SqlParameter idServico = new SqlParameter("@idServico", SqlDbType.Int);
            SqlParameter idCliente = new SqlParameter("@idCliente", SqlDbType.Int);

            dataAgendamento.Value = agendamento.DataAgendamento;
            localAgendamento.Value = agendamento.LocalAgendamento;
            idManicure.Value = agendamento.IdManicure;
            idServico.Value = agendamento.IdServico;
            idCliente.Value = agendamento.IdCliente;

            // Defina os parâmetros
            comando.Parameters.Add(dataAgendamento);
            comando.Parameters.Add(localAgendamento);
            comando.Parameters.Add(idManicure);
            comando.Parameters.Add(idServico);
            comando.Parameters.Add(idCliente);

            comando.Prepare();
            retorno = comando.ExecuteNonQuery();

            if (retorno > 0)
                resultado = true;
            
            comando.Dispose();

            return resultado;
        }

        public static List<Agendamento> ListarAgendamentosPorUsuario(int usuarioId, TipoPerfil tipoPerfil)
        {
            var agendamentos = new List<Agendamento>();

            // Utilizando alias para diferenciar os campos referentes à Manicure e ao Cliente, que são pertecentes a mesma tabela
            string comandoSql = $@"SELECT 
	                                AG.idAgendamento AS idAgendamento, 
                                	AG.localAgendamento AS localAgendamento,
	                                AG.dataAgendamento AS dataAgendamento, 
	                                MA.idUsuario AS maIdUsuario, 
	                                MA.nome AS maNome,
	                                CL.idUsuario AS clIdUsuario, 
	                                CL.nome AS clNome, 
	                                SE.idServico AS idServico, 
	                                SE.tipoServico AS tipoServico, 
	                                SE.valorServico AS valorServico
                                FROM agendamento AG
                                INNER JOIN servicos SE ON SE.idServico = AG.idServico
                                INNER JOIN usuarios MA ON MA.idUsuario = AG.idManicure AND MA.idTipoUsuario = 2
                                INNER JOIN usuarios CL ON CL.idUsuario = AG.idCliente AND CL.idTipoUsuario = 1
                                WHERE {(tipoPerfil == TipoPerfil.Manicure ? "MA.idUsuario" : "CL.idUsuario")} = @usuarioId";

            SqlCommand comando = new SqlCommand(comandoSql, Conexao.GetConexao());
            SqlParameter sqlParameter = new SqlParameter("@usuarioId", SqlDbType.Int);

            sqlParameter.Value = usuarioId;
            
            comando.Parameters.Add(sqlParameter);

            // Compila a instrução e a submete ao banco de dados
            comando.Prepare();
            SqlDataReader leitor = comando.ExecuteReader();

            // Recupera os dados retornados pelo banco de dados
            while (leitor.Read())
                agendamentos.Add(Agendamento.MapAgendamento(leitor));


            leitor.Close();
            comando.Dispose();

            return agendamentos;

        }

        //private bool ValidarAgendamento(string nomeManicure, DateTime dataAgendamento, DateTime horaAgendamento)
        //{
        //    try
        //    {
        //        using (SqlConnection conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\banco.mdf;Integrated Security=True"))
        //        {
        //            conexao.Open();

        //            // Verifique se a manicure está disponível na data e hora escolhidas
        //            string comandoSql = "SELECT COUNT(*) FROM agendamento WHERE nomeManicure = @NomeManicure AND DataAgendamento = @DataAgendamento AND HoraAgendamento = @HoraAgendamento";
        //            SqlCommand comando = new SqlCommand(comandoSql, conexao);

        //            comando.Parameters.AddWithValue("@NomeManicure", nomeManicure);
        //            comando.Parameters.AddWithValue("@DataAgendamento", dataAgendamento);
        //            comando.Parameters.AddWithValue("@HoraAgendamento", horaAgendamento);

        //            int agendamentosConflitantes = (int)comando.ExecuteScalar();

        //            // Se agendamentosConflitantes for zero, a data e hora estão disponíveis
        //            return agendamentosConflitantes == 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //tratar erros aqui
        //        return false;
        //    }

        //}
    }
}
   