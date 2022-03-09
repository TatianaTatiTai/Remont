using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Common.Models.Work
{
   public class OrderBLL
    {
        public string Id { get; set; }

        public string Fio { get; set; }

        public string Phone { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public string UserId { get; set; }

        public bool NeedEvaluation { get; set; }
    }
}
