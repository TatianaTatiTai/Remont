using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAMS.Logic.Common.Models.Admin;
using LAMS.Logic.Common.Models.Work;
using LAMS.Logic.Common.Services.Admin;

namespace LAMS.Logic.Tests.Moqs
{
    public class AdminServiceMoq : IAdminService
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> AddMaterial(MaterialBLL material)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MaterialBLL>> GetMaterials()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkTypeBLL>> WorkTypes()
        {
            throw new NotImplementedException();
        }

        public Task<int> ApproveWorkType(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> RejectWorkType(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> Block(string id)
        {
            throw new NotImplementedException();
        }

        public Task<string> Unblock(string id)
        {
            throw new NotImplementedException();
        }
    }
}