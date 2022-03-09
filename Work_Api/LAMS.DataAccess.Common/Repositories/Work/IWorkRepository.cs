using LAMS.DataAccess.Common.Models.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Repositories.Work
{
  public  interface IWorkRepository : IDisposable
    {
        Task<string> AddOrder(OrderDb order);
        Task<IEnumerable<OrderDb>> GetUserOrders(string UserId);
        Task<OrderDb> DelOrder(string Id);


        Task<int> ApproveOrder(string id);
        Task<int> RejectOrder(string id);
    }
}
