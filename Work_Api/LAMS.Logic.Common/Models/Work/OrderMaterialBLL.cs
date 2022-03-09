using LAMS.Logic.Common.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Common.Models.Work
{
   public class OrderMaterialBLL
    {
        public int Id { get; set; }

        public int IdMaterial { get; set; }
        public virtual MaterialBLL Material { get; set; }
        public string IdOrder { get; set; }
        public virtual OrderBLL Order { get; set; }

        public int Amount { get; set; }

        public double Cost { get; set; }
    }
}
