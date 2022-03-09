using LAMS.DataAccess.Common.DTO;
using LAMS.DataAccess.Common.Models.Admin;
using LAMS.DataAccess.Common.Models.Work;
using LAMS.DataAccess.Common.Repositories.Work;
using LAMS.DataAccess.Common.Repositories.Worker;
using LAMS.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Repositories.Worker
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly DocContext _context;


        private bool _disposed;

        public WorkerRepository(DocContext context) => _context = context;

        public async Task<IEnumerable<OrderDb>> GetNewOrders()
        {
            return await _context.Orders.Where(o =>
                o.Status == "Новая"
            ).ToListAsync().ConfigureAwait(false);
        }
        public async Task<IEnumerable<OrderDb>> GetProcessingOrders()
        {
            return await _context.Orders.Where(o =>
                o.Status == "В обработке"
            ).ToListAsync().ConfigureAwait(false);
        }
        public async Task<IEnumerable<OrderDb>> GetWorkOrders()
        {
            return await _context.Orders.Where(o =>
                o.Status == "Выполняется"
            ).ToListAsync().ConfigureAwait(false);
        }
        public async Task<IEnumerable<OrderDb>> GetWaitOrders()
        {
            return await _context.Orders.Where(o =>
                o.Status == "Ожидает подтверждения"
            ).ToListAsync().ConfigureAwait(false);
        }
        public async Task<IEnumerable<OrderDb>> GetApproveOrders()
        {
            return await _context.Orders.Where(o =>
                o.Status == "Подтверждена"
            ).ToListAsync().ConfigureAwait(false);
        }
        public async Task<IEnumerable<OrderDb>> GetFinishOrders()
        {
            return await _context.Orders.Where(o =>
                o.Status == "Выполнена"
            ).ToListAsync().ConfigureAwait(false);
        }
        public async Task<int> FinishOrder(string id)
        {
            var info = await _context.Orders.FirstOrDefaultAsync(p => p.Id == id && p.Status == "Выполняется").ConfigureAwait(false);
            info.Status = "Выполнена";

            var entry = _context.Entry(info);
            entry.CurrentValues.SetValues(info);
            entry.Property(p => p.Status).IsModified = true;
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task<int> ProcessingOrder(string id)
        {
            var info = await _context.Orders.FirstOrDefaultAsync(p => p.Id == id && p.Status == "Новая").ConfigureAwait(false);
            info.Status = "В обработке";
         
            var entry = _context.Entry(info);
            entry.CurrentValues.SetValues(info);
            entry.Property(p => p.Status).IsModified = true;
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> WaitOrder(string id)
        {
            var info = await _context.Orders.FirstOrDefaultAsync(p => p.Id == id && p.Status == "В обработке").ConfigureAwait(false);
            info.Status = "Ожидает подтверждения";

            var entry = _context.Entry(info);
            entry.CurrentValues.SetValues(info);
            entry.Property(p => p.Status).IsModified = true;
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> WorkOrder(string id)
        {
            var info = await _context.Orders.FirstOrDefaultAsync(p => p.Id == id && p.Status == "Подтверждена").ConfigureAwait(false);
            info.Status = "Выполняется";

            var entry = _context.Entry(info);
            entry.CurrentValues.SetValues(info);
            entry.Property(p => p.Status).IsModified = true;
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> AddOrderMaterial(OrderMaterialDb orderMaterial)
        {
            _context.OrderMaterials.Add(orderMaterial);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return orderMaterial.Id;
        }
        public async Task<IEnumerable<OrderMaterialDb>> GetOrderMaterials(string IdOrder)
        {
            return await _context.OrderMaterials.Where(o =>
                o.IdOrder == IdOrder
            ).ToListAsync().ConfigureAwait(false);
        }
        public async Task<OrderMaterialDb> DelOrderMaterial(int Id)
        {
            OrderMaterialDb order = await _context.OrderMaterials.FirstOrDefaultAsync(p => p.Id == Id).ConfigureAwait(false);

            var result = _context.OrderMaterials.Remove(order);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<int> AddOrderWorkType(OrderWorkTypeDb orderWorkType)
        {
            _context.OrderWorkTypes.Add(orderWorkType);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return orderWorkType.Id;
        }
        public async Task<IEnumerable<OrderWorkTypeDb>> GetOrderWorkTypes(string IdOrder)
        {
            return await _context.OrderWorkTypes.Where(o =>
                o.IdOrder == IdOrder
            ).ToListAsync().ConfigureAwait(false);
        }
        public async Task<OrderWorkTypeDb> DelOrderWorkType(int Id)
        {
            OrderWorkTypeDb order = await _context.OrderWorkTypes.FirstOrDefaultAsync(p => p.Id == Id).ConfigureAwait(false);

            var result = _context.OrderWorkTypes.Remove(order);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<int> AddWorkerCost(OrderWorkerCostDb orderWorkerCost)
        {
            _context.OrderWorkerCosts.Add(orderWorkerCost);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return orderWorkerCost.Id;
        }
        public async Task<IEnumerable<OrderWorkerCostDb>> GetWorkerCosts(string IdOrder)
        {
            return await _context.OrderWorkerCosts.Where(o =>
                o.IdOrder == IdOrder
            ).ToListAsync().ConfigureAwait(false);
        }
        public async Task<OrderWorkerCostDb> DelWorkerCost(int Id)
        {
            OrderWorkerCostDb order = await _context.OrderWorkerCosts.FirstOrDefaultAsync(p => p.Id == Id).ConfigureAwait(false);

            var result = _context.OrderWorkerCosts.Remove(order);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }
        public async Task<double> GetWorkerCostsSum(string IdOrder)
        {
            IEnumerable<OrderWorkerCostDb> order = await _context.OrderWorkerCosts.Where(o =>
                o.IdOrder == IdOrder
            ).ToListAsync().ConfigureAwait(false);
          double sum=  order.Sum(o => o.Cost);
            return  sum;
        }
        public async Task<double> GetOrderMaterialsSum(string IdOrder)
        {
            IEnumerable<OrderMaterialDb> order = await _context.OrderMaterials.Where(o =>
                o.IdOrder == IdOrder
            ).ToListAsync().ConfigureAwait(false);
            double sum = order.Sum(o => o.Cost);
            return sum;
        }
        public async Task<double> GetOrderWorkTypesSum(string IdOrder)
        {
            IEnumerable<OrderWorkTypeDb> order = await _context.OrderWorkTypes.Where(o =>
                o.IdOrder == IdOrder
            ).ToListAsync().ConfigureAwait(false);
            double sum = order.Sum(o => o.Cost);
            return sum;
        }

        public async Task<double> GetOneCost(int Id)
        {
            MaterialDb one = await _context.Materials.FirstOrDefaultAsync(p => p.Id == Id).ConfigureAwait(false);
            double cost = one.OneCost;
            return one.OneCost;
        }
        public async Task<double> GetOneCostWorkType(int Id)
        {
            WorkTypeDb one = await _context.WorkTypes.FirstOrDefaultAsync(p => p.Id == Id).ConfigureAwait(false);
            double cost = one.OneCost;
            return one.OneCost;
        }

        public async Task<int> AddEvaluation(EvaluationDb evaluation)
        {
            evaluation.DateEvaluation = DateTime.UtcNow;
            _context.Evaluations.Add(evaluation);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return evaluation.Id;
        }
        public async Task<EvaluationDb> GetEvaluation(string Id)
        {
            EvaluationDb evaluation = await _context.Evaluations.FirstOrDefaultAsync(p => p.IdOrder == Id).ConfigureAwait(false);
            return evaluation;
        }
        public async Task<int> AddTextAsync(DocumentDb document)
        {
            _context.Documents.Add(document);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return document.Id;
        }
        public async Task<IEnumerable<DocumentDTO>> GetNamesOfTextsByIdAsync(string IdOrder)
        {
            List<DocumentDTO> textsArchive = await _context.Documents
                .Where(text => text.IdOrder == IdOrder && SqlFunctions.DataLength(text.Text) != 0 && !string.IsNullOrEmpty(text.Name))
                .OrderBy(t => t.Number)
                 .Select(m =>
                    new DocumentDTO
                    {
                        Id = m.Id,
                        Name = m.Name
                    })
                .ToListAsync();

            return textsArchive;
        }
        public DocumentDb GetTextById(int id)
        {
            return _context.Documents
                .FirstOrDefault(p => p.Id == id);
        }
        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                GC.SuppressFinalize(this);
            }
        }

        ~WorkerRepository()
        {
            Dispose();
        }
    }
}

