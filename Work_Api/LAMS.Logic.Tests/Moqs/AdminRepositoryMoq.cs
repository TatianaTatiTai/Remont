using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAMS.DataAccess.Common.Models.Admin;
using LAMS.DataAccess.Common.Models.Work;
using LAMS.DataAccess.Common.Repositories.Admin;
using LAMS.Logic.Common.Models.Work;

namespace LAMS.Logic.Tests.Moqs
{
    internal class AdminRepositoryMoq : IAdminRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public async Task<int> AddMaterial(MaterialDb material)
        {
            return material.Id;
        }

        public Task<IEnumerable<MaterialDb>> GetMaterials()
        {
            throw new NotImplementedException();
        }

        public Task<int> AddWorkType(WorkTypeDb workType)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkTypeDb>> GetWorkTypes()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsWorkTypeAvailable(string workType)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsMaterialAvailable(string material, string manufacturer, string description)
        {
            throw new NotImplementedException();
        }
    }
}