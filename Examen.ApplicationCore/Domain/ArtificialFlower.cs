using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
  
    public class ArtificialFlower : Flower
    {
       public string material { get; set; }
        public DateTime ManuFactureDate { get; set; }
    }
}
