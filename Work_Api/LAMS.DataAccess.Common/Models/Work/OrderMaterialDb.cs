using LAMS.DataAccess.Common.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Models.Work
{
   public class OrderMaterialDb
    {
        public int Id { get; set; }

        public int IdMaterial { get; set; }
        public virtual MaterialDb Material { get; set; }
        public string IdOrder { get; set; }
        public virtual OrderDb Order { get; set; }


        public int Amount { get; set; }
        public double Cost { get; set; }

    }
}
