using LAMS.DataAccess.Common.Models.Work;
using LAMS.DataAccess.Common.Repositories.Work;
using LAMS.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Repositories.Work
{
  public  class WorkRepository : IWorkRepository
    {
        private readonly DocContext _context;


        private bool _disposed;

        public WorkRepository(DocContext context) => _context = context;
        public async Task<string> AddOrder(OrderDb order)
        {
            order.Id = Guid.NewGuid().ToString();
            _context.Orders.Add(order);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return order.Id;
        }
        public async Task<IEnumerable<OrderDb>> GetUserOrders(string UserId)
        {
            return await _context.Orders.Where(o =>
                o.UserId == UserId
            ).ToListAsync().ConfigureAwait(false);
        }
        public async Task<OrderDb> DelOrder(string Id)
        {
            OrderDb order = await _context.Orders.FirstOrDefaultAsync(p => p.Id == Id).ConfigureAwait(false);

            var result = _context.Orders.Remove(order);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<int> ApproveOrder(string id)
        {
            var info = await _context.Orders.FirstOrDefaultAsync(p => p.Id == id && p.Status == "Ожидает подтверждения").ConfigureAwait(false);
            info.Status = "Подтверждена";

            var entry = _context.Entry(info);
            entry.CurrentValues.SetValues(info);
            entry.Property(p => p.Status).IsModified = true;
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }      
        public async Task<int> RejectOrder(string id)
        {
            var info = await _context.Orders.FirstOrDefaultAsync(p => p.Id == id && p.Status == "Ожидает подтверждения").ConfigureAwait(false);
            info.Status = "Отклонена";

            var entry = _context.Entry(info);
            entry.CurrentValues.SetValues(info);
            entry.Property(p => p.Status).IsModified = true;
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                GC.SuppressFinalize(this);
            }
        }

        ~WorkRepository()
        {
            Dispose();
        }
    }
}
