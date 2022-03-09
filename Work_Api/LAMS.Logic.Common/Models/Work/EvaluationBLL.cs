using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Common.Models.Work
{
   public class EvaluationBLL
    {
        public int Id { get; set; }

        public string IdOrder { get; set; }

        public string Evaluation { get; set; }

        public DateTime DateEvaluation { get; set; }
    }
}
