using LAMS.DataAccess.Common.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Models.Work
{
   public class OrderWorkTypeDb
    {
        public int Id { get; set; }

        public int IdWorkType { get; set; }
        public virtual WorkTypeDb WorkType { get; set; }
        public string IdOrder { get; set; }
        public virtual OrderDb Order { get; set; }


        public double Amount { get; set; }
        public double Cost { get; set; }
    }
}
