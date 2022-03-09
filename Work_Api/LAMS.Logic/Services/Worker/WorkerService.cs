using AutoMapper;
using LAMS.DataAccess.Common.Models.Work;
using LAMS.DataAccess.Common.Repositories.Worker;
using LAMS.Logic.Common.Models.Work;
using LAMS.Logic.Common.Services.Worker;
using Spire.Doc;
using Spire.Pdf;
using Spire.Xls;
using Spire.Xls.Converter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace LAMS.Logic.Services.Worker
{
    public class WorkerService : IWorkerService
    {
        private IMapper _mapper;
        private IWorkerRepository _repo;

        public WorkerService(IWorkerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderBLL>> GetNewOrders()
        {
            return await _repo.GetNewOrders()
                .ContinueWith(t => _mapper.Map<IEnumerable<OrderBLL>>(t.Result));
        }

        public async Task<IEnumerable<OrderBLL>> GetProcessingOrders()
        {
            return await _repo.GetProcessingOrders()
                .ContinueWith(t => _mapper.Map<IEnumerable<OrderBLL>>(t.Result));
        }

        public async Task<IEnumerable<OrderBLL>> GetWorkOrders()
        {
            return await _repo.GetWorkOrders()
                .ContinueWith(t => _mapper.Map<IEnumerable<OrderBLL>>(t.Result));
        }

        public async Task<IEnumerable<OrderBLL>> GetWaitOrders()
        {
            return await _repo.GetWaitOrders()
                .ContinueWith(t => _mapper.Map<IEnumerable<OrderBLL>>(t.Result));
        }
        public async Task<IEnumerable<OrderBLL>> GetApproveOrders()
        {
            return await _repo.GetApproveOrders()
                .ContinueWith(t => _mapper.Map<IEnumerable<OrderBLL>>(t.Result));
        }
        public async Task<IEnumerable<OrderBLL>> GetFinishOrders()
        {
            return await _repo.GetFinishOrders()
                .ContinueWith(t => _mapper.Map<IEnumerable<OrderBLL>>(t.Result));
        }
        public async Task<int> FinishOrder(string id)
        {
            return await _repo.FinishOrder(_mapper.Map<string>(id)).ContinueWith(t => t.Result);
        }
        public async Task<int> ProcessingOrder(string id)
        {
            return await _repo.ProcessingOrder(_mapper.Map<string>(id)).ContinueWith(t => t.Result);
        }
        public async Task<int> WaitOrder(string id)
        {
            return await _repo.WaitOrder(_mapper.Map<string>(id)).ContinueWith(t => t.Result);
        }
        public async Task<int> WorkOrder(string id)
        {
            return await _repo.WorkOrder(_mapper.Map<string>(id)).ContinueWith(t => t.Result);
        }

        public async Task<int> AddOrderMaterial(OrderMaterialBLL orderMaterial)
        {
            try
            {
                var id = await _repo.AddOrderMaterial(_mapper.Map<OrderMaterialDb>(orderMaterial)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<OrderMaterialBLL>> GetOrderMaterials(string IdOrder)
        {
            return await _repo.GetOrderMaterials(IdOrder)
                .ContinueWith(t => _mapper.Map<IEnumerable<OrderMaterialBLL>>(t.Result));
        }
        public async Task<OrderMaterialBLL> DelOrderMaterial(int Id)
        {
            return await _repo.DelOrderMaterial(Id)
                .ContinueWith(t => _mapper.Map<OrderMaterialBLL>(t.Result));
        }

        public async Task<int> AddOrderWorkType(OrderWorkTypeBLL orderWorkType)
        {
            try
            {
                var id = await _repo.AddOrderWorkType(_mapper.Map<OrderWorkTypeDb>(orderWorkType)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<OrderWorkTypeBLL>> GetOrderWorkTypes(string IdOrder)
        {
            return await _repo.GetOrderWorkTypes(IdOrder)
                .ContinueWith(t => _mapper.Map<IEnumerable<OrderWorkTypeBLL>>(t.Result));
        }
        public async Task<OrderWorkTypeBLL> DelOrderWorkType(int Id)
        {
            return await _repo.DelOrderWorkType(Id)
                .ContinueWith(t => _mapper.Map<OrderWorkTypeBLL>(t.Result));
        }

        public async Task<int> AddWorkerCost(OrderWorkerCostBLL orderWorkerCost)
        {
            try
            {
                var id = await _repo.AddWorkerCost(_mapper.Map<OrderWorkerCostDb>(orderWorkerCost)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<OrderWorkerCostBLL>> GetWorkerCosts(string IdOrder)
        {
            return await _repo.GetWorkerCosts(IdOrder)
                .ContinueWith(t => _mapper.Map<IEnumerable<OrderWorkerCostBLL>>(t.Result));
        }
        public async Task<OrderWorkerCostBLL> DelWorkerCost(int Id)
        {
            return await _repo.DelWorkerCost(Id)
                .ContinueWith(t => _mapper.Map<OrderWorkerCostBLL>(t.Result));
        }
        public async Task<double> GetWorkerCostsSum(string IdOrder)
        {
            return await _repo.GetWorkerCostsSum(_mapper.Map<string>(IdOrder)).ContinueWith(t => t.Result);
        }
        public async Task<double> GetOrderMaterialsSum(string IdOrder)
        {
            return await _repo.GetOrderMaterialsSum(_mapper.Map<string>(IdOrder)).ContinueWith(t => t.Result);
        }
        public async Task<double> GetOrderWorkTypesSum(string IdOrder)
        {
            return await _repo.GetOrderWorkTypesSum(_mapper.Map<string>(IdOrder)).ContinueWith(t => t.Result);
        }
        public async Task<double> GetOneCost(int Id)
        {
            return await _repo.GetOneCost(_mapper.Map<int>(Id)).ContinueWith(t => t.Result);
        }
        public async Task<double> GetOneCostWorkType(int Id)
        {
            return await _repo.GetOneCostWorkType(_mapper.Map<int>(Id)).ContinueWith(t => t.Result);
        }
        public async Task<int> AddEvaluation(EvaluationBLL evaluation)
        {
            try
            {
                var id = await _repo.AddEvaluation(_mapper.Map<EvaluationDb>(evaluation)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<EvaluationBLL> GetEvaluation(string Id)
        {
            return await _repo.GetEvaluation(Id)
                .ContinueWith(t => _mapper.Map<EvaluationBLL>(t.Result));
        }

        public async Task<int> AddTextAsync(DocumentBLL text)
        {
            return await _repo.AddTextAsync(_mapper.Map<DocumentDb>(text)).ContinueWith(t => t.Result);
        }
        public async Task<IEnumerable<DocumentBLL>> GetNamesOfTextsAsync(string IdOrder)
        {
            IEnumerable<DocumentBLL> textsInfo;

            textsInfo = await _repo.GetNamesOfTextsByIdAsync(IdOrder).ContinueWith(t => _mapper.Map<IEnumerable<DocumentBLL>>(t.Result));

            return textsInfo;
        }
        public DocumentDb GetTextById(int id)
        {
            return _repo.GetTextById(id);
        }
        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты).
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~DocumentService() {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        void IDisposable.Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}
