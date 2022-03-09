using LAMS.DataAccess.Common.DTO;
using LAMS.DataAccess.Common.Models.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Repositories.Worker
{
    public interface IWorkerRepository : IDisposable
    {
        Task<IEnumerable<OrderDb>> GetNewOrders();
        Task<IEnumerable<OrderDb>> GetProcessingOrders();
        Task<IEnumerable<OrderDb>> GetWorkOrders();
        Task<IEnumerable<OrderDb>> GetWaitOrders();
        Task<IEnumerable<OrderDb>> GetApproveOrders();
        Task<IEnumerable<OrderDb>> GetFinishOrders();

        Task<int> ProcessingOrder(string id);
        Task<int> WaitOrder(string id);
        Task<int> WorkOrder(string id);
        Task<int> FinishOrder(string id);

        Task<int> AddOrderMaterial(OrderMaterialDb orderMaterial);
        Task<IEnumerable<OrderMaterialDb>> GetOrderMaterials(string IdOrder);
        Task<double> GetOrderMaterialsSum(string IdOrder);
        Task<double> GetOneCost(int Id);
        Task<double> GetOneCostWorkType(int Id);
        Task<OrderMaterialDb> DelOrderMaterial(int Id);

        Task<int> AddOrderWorkType(OrderWorkTypeDb orderWorkType);
        Task<IEnumerable<OrderWorkTypeDb>> GetOrderWorkTypes(string IdOrder);
        Task<double> GetOrderWorkTypesSum(string IdOrder);
        Task<OrderWorkTypeDb> DelOrderWorkType(int Id);

        Task<int> AddWorkerCost(OrderWorkerCostDb orderWorkerCost);
        Task<IEnumerable<OrderWorkerCostDb>> GetWorkerCosts(string IdOrder);
        Task<double> GetWorkerCostsSum(string IdOrder);
        Task<OrderWorkerCostDb> DelWorkerCost(int Id);


        Task<int> AddEvaluation(EvaluationDb evaluation);
        Task<EvaluationDb> GetEvaluation(string Id);


        Task<int> AddTextAsync(DocumentDb document);

        Task<IEnumerable<DocumentDTO>> GetNamesOfTextsByIdAsync(string IdOrder);
        DocumentDb GetTextById(int id);
    }
}
