using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen.ApplicationCore.Domain
{
    public class Flower
    {
        
        public int FlowerId { get; set; }
       
        public string name { get; set; }
        public string color { get; set; }
        [DataType(DataType.Currency)]
        [Range(0,2000)]
        public float price { get; set; }
     

       
         public virtual Bouquet Bouquet { get; set; }
        [ForeignKey("Bouquet")]
        public int BouqFK { get; set; }

       
    }
}
