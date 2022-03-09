using LAMS.Logic.Common.Models.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Common.Services.Work
{
   public interface IWorkService : IDisposable
    {
        Task<string> AddOrder(OrderBLL order);
        Task<IEnumerable<OrderBLL>> GetUserOrders(string UserId);
        Task<OrderBLL> DelOrder(string Id);


        Task<int> ApproveOrder(string id);
        Task<int> RejectOrder(string id);
    }
}
