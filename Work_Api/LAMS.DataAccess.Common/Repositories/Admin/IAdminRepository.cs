
using LAMS.DataAccess.Common.Models.Admin;
using LAMS.DataAccess.Common.Models.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Repositories.Admin
{
    public interface IAdminRepository : IDisposable
    {
        Task<int> AddMaterial(MaterialDb material);
        Task<IEnumerable<MaterialDb>> GetMaterials();
        Task<int> AddWorkType(WorkTypeDb workType);
        Task<IEnumerable<WorkTypeDb>> GetWorkTypes();

        Task<bool> IsWorkTypeAvailable(string workType);
        Task<bool> IsMaterialAvailable(string material, string manufacturer, string description);
    }
}
