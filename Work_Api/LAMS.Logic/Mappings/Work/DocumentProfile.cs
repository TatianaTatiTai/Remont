using AutoMapper;
using LAMS.DataAccess.Common.DTO;
using LAMS.DataAccess.Common.Models.Work;
using LAMS.Logic.Common.Models.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Mappings.Work
{
   public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<DocumentBLL, DocumentDb>()
                .ForMember(m => m.Order, opt => opt.Ignore());

            CreateMap<DocumentDb, DocumentBLL>();

            CreateMap<DocumentBLL, DocumentDTO>().ReverseMap();
            CreateMap<DocumentDTO, DocumentBLL>();

        }
    }
}
