namespace Mecanismo.Dao.DaoEnderecos
{
    public class Endereco
    {
        private string rua;
        private string numero;
        private string complemento;
        private string bairro;
        private string cep;
        private string cidade;
        private string estado;
        private int idUsuario;

        public string Rua { get => rua; set => rua = value; }
        public string Numero { get => numero; set => numero = value; }
        public string Complemento { get => complemento; set => complemento = value; }
        public string Bairro { get => bairro; set => bairro = value; }
        public string Cep { get => cep; set => cep = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public string Estado { get => estado; set => estado = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }


        public Endereco(string rua, string numero, string complemento, string bairro, string cep, string cidade, string estado, int idUsuario)
        {
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
            IdUsuario = idUsuario;
         
        }

        public Endereco(string rua, string numero, string complemento, string bairro, string cep, string cidade, string estado)
        {
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
            

        }
    }
}
