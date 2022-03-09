using LAMS.DataAccess.Common.Models.Admin;
using LAMS.DataAccess.Common.Models.Work;
using LAMS.DataAccess.Common.Repositories.Admin;
using LAMS.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Repositories.Admin
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DocContext _context;

        public AdminRepository(DocContext context) => _context = context;

        public async Task<int> AddMaterial(MaterialDb material)
        {
            _context.Materials.Add(material);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return material.Id;
        }
        public async Task<IEnumerable<MaterialDb>> GetMaterials()
        {
            return await _context.Materials.OrderBy(o => o.Material).ToListAsync().ConfigureAwait(false);
        }

        public async Task<int> AddWorkType(WorkTypeDb workType)
        {
            _context.WorkTypes.Add(workType);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return workType.Id;
        }
        public async Task<IEnumerable<WorkTypeDb>> GetWorkTypes()
        {
            return await _context.WorkTypes.OrderBy(o => o.WorkType).ToListAsync().ConfigureAwait(false);
        }

        public async Task<bool> IsWorkTypeAvailable(string workType)
        {
            return !(await _context.WorkTypes.AnyAsync(u => u.WorkType == workType).ConfigureAwait(false));
        }

        public async Task<bool> IsMaterialAvailable(string material, string manufacturer, string description)
        {
            return !(await _context.Materials.AnyAsync(u => u.Material == material && u.Manufacturer == manufacturer && u.Description == description).ConfigureAwait(false));
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
        // ~DocumentRepository() {
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
