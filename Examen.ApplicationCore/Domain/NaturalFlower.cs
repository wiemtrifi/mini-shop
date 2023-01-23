using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class NaturalFlower : Flower
    {
        public string origine { get; set; }
        public bool savage { get; set; }
        [Range(1,4)]
        public int season { get; set; }

    }
}
