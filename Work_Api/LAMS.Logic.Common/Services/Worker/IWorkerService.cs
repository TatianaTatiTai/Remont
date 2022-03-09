using LAMS.DataAccess.Common.Models.Work;
using LAMS.Logic.Common.Models.Work;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Common.Services.Worker
{
    public interface IWorkerService : IDisposable
    {
        Task<IEnumerable<OrderBLL>> GetNewOrders();
        Task<IEnumerable<OrderBLL>> GetProcessingOrders();
        Task<IEnumerable<OrderBLL>> GetWorkOrders();
        Task<IEnumerable<OrderBLL>> GetWaitOrders();
        Task<IEnumerable<OrderBLL>> GetApproveOrders();
        Task<IEnumerable<OrderBLL>> GetFinishOrders();

        Task<int> FinishOrder(string id);
        Task<int> ProcessingOrder(string id);
        Task<int> WaitOrder(string id);
        Task<int> WorkOrder(string id);

        Task<int> AddOrderMaterial(OrderMaterialBLL orderMaterial);
        Task<IEnumerable<OrderMaterialBLL>> GetOrderMaterials(string IdOrder);
        Task<double> GetOrderMaterialsSum(string IdOrder);
        Task<double> GetOneCost(int Id);
        Task<double> GetOneCostWorkType(int Id);
        Task<OrderMaterialBLL> DelOrderMaterial(int Id);

        Task<int> AddOrderWorkType(OrderWorkTypeBLL orderWorkType);
        Task<IEnumerable<OrderWorkTypeBLL>> GetOrderWorkTypes(string IdOrder);
        Task<double> GetOrderWorkTypesSum(string IdOrder);
        Task<OrderWorkTypeBLL> DelOrderWorkType(int Id);

        Task<int> AddWorkerCost(OrderWorkerCostBLL orderWorkerCost);
        Task<IEnumerable<OrderWorkerCostBLL>> GetWorkerCosts(string IdOrder);
        Task<double> GetWorkerCostsSum(string IdOrder);
        Task<OrderWorkerCostBLL> DelWorkerCost(int Id);


        Task<int> AddEvaluation(EvaluationBLL evaluation);
        Task<EvaluationBLL> GetEvaluation(string Id);


        Task<int> AddTextAsync(DocumentBLL document);


        Task<IEnumerable<DocumentBLL>> GetNamesOfTextsAsync(string IdOrder);
        DocumentDb GetTextById(int id);
    }
}
