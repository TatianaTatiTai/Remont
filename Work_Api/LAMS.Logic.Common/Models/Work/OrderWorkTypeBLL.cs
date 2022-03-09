using LAMS.Logic.Common.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Common.Models.Work
{
   public class OrderWorkTypeBLL
    {
        public int Id { get; set; }

        public int IdWorkType { get; set; }
        public virtual WorkTypeBLL WorkType { get; set; }
        public string IdOrder { get; set; }
        public virtual OrderBLL Order { get; set; }

        public double Amount { get; set; }
        public double Cost { get; set; }
    }
}
