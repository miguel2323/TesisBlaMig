using System;
using System.Collections.Generic;
using System.Text;

namespace TesisBlaMig.Models
{
   public class Productos
    {
        public int ProductID { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }

        public string PriceFormated { get { return string.Format("{0:C2}", Price); } }
        public DateTime LastBuy { get; set; }
        public float Stock { get; set; }
        public string Remarks { get; set; }
        public int CategoryID { get; set; }

        public int TaxID { get; set; }

        public override string ToString()
        {

            return base.ToString();
        }
    }
}
