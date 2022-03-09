using LAMS.Logic.Common.Models.Admin;
using LAMS.Logic.Common.Models.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Common.Services.Admin
{
   public interface IAdminService : IDisposable
    {
        Task<int> AddMaterial(MaterialBLL material);
        Task<IEnumerable<MaterialBLL>> GetMaterials();

        Task<int> AddWorkType(WorkTypeBLL workType);
        Task<IEnumerable<WorkTypeBLL>> GetWorkTypes();
    }
}
