using AutoMapper;
using LAMS.DataAccess.Common.Models.Work;
using LAMS.DataAccess.Common.Repositories.Work;
using LAMS.Logic.Common.Models.Work;
using LAMS.Logic.Common.Services.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Services.Work
{
   public class WorkService : IWorkService
    {
        private IMapper _mapper;
        private IWorkRepository _repo;

        public WorkService(IWorkRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<string> AddOrder(OrderBLL order)
        {
            try
            {
                var id = await _repo.AddOrder(_mapper.Map<OrderDb>(order)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<OrderBLL>> GetUserOrders(string UserId)
        {
            return await _repo.GetUserOrders(UserId)
                .ContinueWith(t => _mapper.Map<IEnumerable<OrderBLL>>(t.Result));
        }

        public async Task<OrderBLL> DelOrder(string Id)
        {
            return await _repo.DelOrder(Id)
                .ContinueWith(t => _mapper.Map<OrderBLL>(t.Result));
        }

        public async Task<int> ApproveOrder(string id)
        {
            return await _repo.ApproveOrder(_mapper.Map<string>(id)).ContinueWith(t => t.Result);
        }  
        public async Task<int> RejectOrder(string id)
        {
            return await _repo.RejectOrder(_mapper.Map<string>(id)).ContinueWith(t => t.Result);
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
