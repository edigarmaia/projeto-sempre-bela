using Mecanismo.Enums;
using SempreBela.Dao.DaoAgendamento;
using SempreBela.DaoClientes;
using System;
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
        
        public static bool ValidarAgendamento(int idManicure, DateTime dataAgendamento, out DateTime fimAgendamento)
        {
            string consultaSql = "SELECT TOP 1 dataAgendamento FROM agendamento WHERE idManicure = @idManicure AND dataAgendamento <= @dataAgendamento ORDER BY dataAgendamento DESC";

            using (SqlCommand comandoConsulta = new SqlCommand(consultaSql, Conexao.GetConexao()))
            {
                comandoConsulta.Parameters.AddWithValue("@idManicure", idManicure);
                comandoConsulta.Parameters.AddWithValue("@dataAgendamento", dataAgendamento);

                object result = comandoConsulta.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    DateTime dataTermino = (DateTime)result;

                    // Adiciona 30 minutos ao término do agendamento
                    fimAgendamento = dataTermino.AddMinutes(30);

                    // Verifica se o término é antes da data e hora selecionadas pelo cliente
                    if (fimAgendamento <= dataAgendamento)
                    {
                        fimAgendamento = DateTime.MinValue; // Define como mínimo para indicar que não há agendamento ativo
                        return false;
                    }
                }
                else
                {
                    fimAgendamento = DateTime.MinValue;
                    return false;
                }
            }

            return true;
        }

        // Método que exclui um agendamento
        public static bool ExcluirAgendamento(int id)
        {
            bool retorno = false;
            int resultado;

            try
            {
                // Query sql - Criação do comando
                string comandoSql = "DELETE FROM agendamento WHERE idAgendamento = @idAgendamento";
                //string comandoSql = "DELETE FROM agendamento WHERE agendamento.id = @id";
                SqlCommand comando = new SqlCommand(comandoSql, Conexao.GetConexao());

                // Criação do parâmetro
                SqlParameter agendamentoId = new SqlParameter("@idAgendamento", System.Data.SqlDbType.Int);

                // Definição do valor do parâmetro.
                agendamentoId.Value = id;

                // Atribuição do parâmetro ao comando
                comando.Parameters.Add(agendamentoId);

                // Compilação e execução do comando
                comando.Prepare();
                resultado = comando.ExecuteNonQuery();

                if (resultado != 0)
                {
                   retorno = true;
                }

                // Limpeza de recursos
                comando.Dispose();


            }
            catch (Exception ex)
            {
                // Tratar a exceção
                throw new Exception("Erro ao excluir agendamento", ex);
            }

            return retorno;
        }

    }

}
   