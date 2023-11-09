using Mecanismo.Dao;
using Mecanismo.Dao.DaoServicos;
using Mecanismo.Dao.DaoUsuarios;
using System;
using System.Data.SqlClient;

namespace SempreBela.Dao.DaoAgendamento
{
    public class Agendamento
    {
        private int idAgendamento;
        private DateTime dataAgendamento;
        private string localAgendamento;
        private int idManicure;
        private int idServico;
        private int idCliente;
        private Usuario manicure;
        private Usuario cliente;
        private Servico servico;

        // Propriedades
        public int IdAgendamento { get => idAgendamento; set => idAgendamento = value; }
        public DateTime DataAgendamento { get => dataAgendamento; set => dataAgendamento = value; }
        public string LocalAgendamento { get => localAgendamento; set => localAgendamento = value; }
        public int IdManicure { get => idManicure; set => idManicure = value; }
        public int IdServico { get => idServico; set => idServico = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public Usuario Manicure { get => manicure; set => manicure = value; }
        public Usuario Cliente { get => cliente; set => cliente = value; }
        public Servico Servico { get => servico; set => servico = value; }

        public static Agendamento MapAgendamento(SqlDataReader leitor)
        {
            return new Agendamento(
                idAgendamento: Convert.ToInt32(leitor["idAgendamento"]),
                dataAgendamento: DateTime.Parse(leitor["dataAgendamento"].ToString()),
                localAgendamento: leitor["localAgendamento"].ToString(),
                servico: Servico.MapServico(leitor),
                manicure: new Usuario(
                    idUsuario: (int)leitor["maIdUsuario"],
                    nome: leitor["maNome"].ToString(),
                    tipo: 1
                ),
                cliente: new Usuario(
                    idUsuario: (int)leitor["clIdUsuario"],
                    nome: leitor["clNome"].ToString(),
                    tipo: 2
                )
            );
        }


        // Construtor

        public Agendamento()
        {

        }

        public Agendamento(DateTime dataAgendamento, string localAgendamento, int idServico, int idManicure, int idCliente)
        {
            DataAgendamento = dataAgendamento;
            LocalAgendamento = localAgendamento;
            IdServico = idServico;
            IdManicure = idManicure;
            IdCliente = idCliente;
        }

        public Agendamento(int idAgendamento, DateTime dataAgendamento, string localAgendamento, Servico servico, Usuario manicure, Usuario cliente)
        {
            IdAgendamento = idAgendamento;
            DataAgendamento = dataAgendamento;
            LocalAgendamento = localAgendamento;
            Servico = servico;
            Manicure = manicure;
            Cliente = cliente;
        }
    }
}