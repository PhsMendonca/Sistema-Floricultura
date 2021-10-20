using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace floricultura
{
    class ClienteModel
    {
        private string RG;
        private string nome;
        private string telefone;
        private string endereco;

        public ClienteModel()
        {
            Nome = nome;
            RG1 = RG;
            Telefone = telefone;
            Endereco = endereco;
        }

        public string RG1 { get => RG; set => RG = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Endereco { get => endereco; set => endereco = value; }
    }
}
