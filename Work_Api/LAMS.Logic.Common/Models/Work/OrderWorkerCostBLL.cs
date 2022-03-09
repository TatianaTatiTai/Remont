using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Common.Models.Work
{
  public  class OrderWorkerCostBLL
    {
        public int Id { get; set; }

        public string IdOrder { get; set; }
        public virtual OrderBLL Order { get; set; }

        public int WorkersNumber { get; set; }
        public double Cost { get; set; }
    }
}
