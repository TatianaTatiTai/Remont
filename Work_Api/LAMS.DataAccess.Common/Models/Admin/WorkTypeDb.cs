using LAMS.DataAccess.Common.Models.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Models.Admin
{
    public class WorkTypeDb
    {
        public int Id { get; set; }

        public double OneCost { get; set; }

        public string WorkType { get; set; }

        public virtual ICollection<OrderWorkTypeDb> OrderWorkTypes { get; set; }
    }
}
