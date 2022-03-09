using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Models.Work
{
    public class OrderWorkerCostDb
    {
        public int Id { get; set; }

        public string IdOrder { get; set; }
        public virtual OrderDb Order { get; set; }

        public int WorkersNumber { get; set; }
        public double Cost { get; set; }
    }
}
