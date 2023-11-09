using System;
using System.Data.SqlClient;

namespace Mecanismo.Dao.DaoServicos
{
    public class Servico
    {
        // atributos
        private int idServico;
        private string tipoServico;
        private decimal valorServico;
        private int idManicure;

        // Propriedades
        public int IdServico { get => idServico; set => idServico = value; }
        public string TipoServico { get => tipoServico; set => tipoServico = value; }
        public decimal ValorServico { get => valorServico; set => valorServico = value; }
        public int IdManicure { get => idManicure; set => idManicure = value; }

        public static Servico MapServico(SqlDataReader leitor)
        {
            return new Servico(Convert.ToInt32(leitor["idServico"]), leitor["tipoServico"].ToString(), Convert.ToDecimal(leitor["valorServico"]));
        }

        // Construtor
        public Servico(string tipoServico, decimal valorServico)
        {
            TipoServico = tipoServico;
            ValorServico = valorServico;
        }

        public Servico(int idServico, string tipoServico, decimal valorServico)
        {
            IdServico = idServico;
            TipoServico = tipoServico;
            ValorServico = valorServico;
        }
        public Servico(decimal valorServico)
        {
            ValorServico = valorServico;
        }
    }
}
