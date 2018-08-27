using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;


namespace DesafioTI.Models
{
    public class Item
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public int Estoque { get; set; }
    }


}  