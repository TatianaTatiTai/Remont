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
    class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<MaterialBLL, MaterialDb>().ReverseMap();
            CreateMap<MaterialDb, MaterialBLL>();
        }
    }
}