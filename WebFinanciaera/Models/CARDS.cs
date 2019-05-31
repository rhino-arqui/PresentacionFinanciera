using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFinanciaera.Models
{
    public partial class CARDS
    {
        public decimal CardNumber { get; set; }
        public string NameHolder { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public decimal Month { get; set; }
        public decimal Year { get; set; }
        public decimal Avaliable { get; set; }
        public string TipoDoc { get; set; }
        public decimal Doc { get; set; }
        public string Pass { get; set; }
    }
}