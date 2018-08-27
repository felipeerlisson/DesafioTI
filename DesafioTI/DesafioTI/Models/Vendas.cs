using System;

namespace DesafioTI.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public int IdItem { get; set; }
        public int Quantidade { get; set; }
        public int Cliente { get; set; }
    }
}