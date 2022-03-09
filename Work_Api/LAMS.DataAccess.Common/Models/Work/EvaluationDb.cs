using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Models.Work
{
   public class EvaluationDb
    {
        public int Id { get; set; }

        public string IdOrder { get; set; }
        public virtual OrderDb Order { get; set; }

        public string Evaluation { get; set; }

        public DateTime DateEvaluation { get; set; }
    }
}
