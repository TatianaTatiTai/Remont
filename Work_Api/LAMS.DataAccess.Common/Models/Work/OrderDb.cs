using LAMS.DataAccess.Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Models.Work
{
   public class OrderDb
    {
        public string Id { get; set; }
        public string Fio { get; set; }

        public string Phone { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public string UserId { get; set; }
        public virtual UserDb User { get; set; }


        public bool NeedEvaluation{ get; set; }

        public virtual ICollection<OrderMaterialDb> OrderMaterials { get; set; }
        public virtual ICollection<OrderWorkTypeDb> OrderWorkTypes { get; set; }
        public virtual ICollection<OrderWorkerCostDb> OrderWorkerCosts { get; set; }
        public virtual ICollection<EvaluationDb> Evaluations { get; set; }
        public virtual ICollection<DocumentDb> Documents { get; set; }
    }
}
