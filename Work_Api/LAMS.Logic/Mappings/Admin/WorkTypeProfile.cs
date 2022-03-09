using AutoMapper;
using LAMS.DataAccess.Common.Models.Admin;
using LAMS.Logic.Common.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Mappings.Admin
{
    class WorkTypeProfile : Profile
    {
        public WorkTypeProfile()
        {
            CreateMap<WorkTypeBLL, WorkTypeDb>().ReverseMap();
            CreateMap<WorkTypeDb, WorkTypeBLL>();
        }
    }
}
