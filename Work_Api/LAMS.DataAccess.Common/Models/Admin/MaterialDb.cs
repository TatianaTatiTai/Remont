using LAMS.DataAccess.Common.Models.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Models.Admin
{
  public class MaterialDb
    {
        public int Id { get; set; }
        public double OneCost { get; set; }

        public string Material { get; set; }

        public string Manufacturer { get; set; }

        public string Description { get; set; }

        public virtual ICollection<OrderMaterialDb> OrderMaterials { get; set; }
    }
}
