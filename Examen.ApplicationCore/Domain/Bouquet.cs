using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public enum BouquetType
    {
        Round,
        Concial
    }
    public class Bouquet
    {
        [Key]
        public int BouquetCode { get; set; }
       
        public string AccompagingMessage { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        public BouquetType BouquetType { get; set; }

        //one 
       public virtual Customer Customer { get; set; }
       [ForeignKey("Customer")]
        public string custFK { get; set; }

        public virtual List<Flower> flowers { get; set; }
    }
}
