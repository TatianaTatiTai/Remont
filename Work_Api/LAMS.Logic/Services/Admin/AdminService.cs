using AutoMapper;
using LAMS.DataAccess.Common.Models.Admin;
using LAMS.DataAccess.Common.Repositories.Admin;
using LAMS.Logic.Common.Models.Admin;
using LAMS.Logic.Common.Models.Work;
using LAMS.Logic.Common.Services.Admin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LAMS.Logic.Services.Admin
{
    public class AdminService : IAdminService
    {
        private IMapper _mapper;
        private IAdminRepository _repo;

        public AdminService(IAdminRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<int> AddMaterial(MaterialBLL material)
        {
            try
            {
                if (!await _repo.IsMaterialAvailable(material.Material, material.Manufacturer, material.Description))
                {
                    // throws 409 conflict
                    return 0;
                }
                var id = await _repo.AddMaterial(_mapper.Map<MaterialDb>(material)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<MaterialBLL>> GetMaterials()
        {
            return await _repo.GetMaterials()
                .ContinueWith(t => _mapper.Map<IEnumerable<MaterialBLL>>(t.Result));
        }

        public async Task<int> AddWorkType(WorkTypeBLL workType)
        {
            try
            {
                if (!await _repo.IsWorkTypeAvailable(workType.WorkType))
                {
                    // throws 409 conflict
                    return 0;
                }
                var id = await _repo.AddWorkType(_mapper.Map<WorkTypeDb>(workType)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<WorkTypeBLL>> GetWorkTypes()
        {
            return await _repo.GetWorkTypes()
                .ContinueWith(t => _mapper.Map<IEnumerable<WorkTypeBLL>>(t.Result));
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
