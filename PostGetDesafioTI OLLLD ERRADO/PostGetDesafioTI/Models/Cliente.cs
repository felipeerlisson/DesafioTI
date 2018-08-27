using System;

namespace PostGetDesafioTI.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Endereço { get; set; }
        public int QuantidadeDeCompras { get; set; }
    }
}