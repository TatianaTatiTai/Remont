using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAMS.DataAccess.Common.Models.Work;
using LAMS.DataAccess.Common.Repositories.Work;

namespace LAMS.Logic.Tests.Moqs
{
    public class WorkRepositoryMoq : IWorkRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddOrder(OrderDb order)
        {
            return 1;
        }

        public async Task<IEnumerable<OrderDb>> GetOrders(string id)
        {
            return new List<OrderDb>()
            {
                new WorkRepositoryMoq()
                {
                Id = 1
                }
            };
        }

        public async Task<int> AddDocument(DocumentDb document)
        {
            return 1111;
        }

        public Task<IEnumerable<DocumentDb>> GetDocuments(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DocumentDb>> GetActiveDocuments()
        {
            throw new NotImplementedException();
        }

        public Task<DocumentDb> GetDocumentInfo(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DocumentDb> DelDocument(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> FinishCreateDocument(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> StartDocument(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> EndDocument(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditDocument(DocumentDb document)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddMaterial(OrderMaterialDb material)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderMaterialDb>> GetMaterials(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderMaterialDb> DelMaterial(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddEvaluation(EvaluationDb evaluation)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EvaluationDb>> GetEvaluations(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EvaluationDb> DelEvaluation(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddOrderWorkType(OrderWorkTypeDb order)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderWorkTypeDb>> GetOrderWorkTypes(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderWorkTypeDb> DelOrderWorkType(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> OrderOrder(OrderWorkerCostDb order)
        {
            return 1;
        }

        public async Task<bool> IsOrderOrder(int IdOrder, string IdUser)
        {
            return true;
        }

        public Task<IEnumerable<OrderWorkerCostDb>> GetOrderWorkerCosts(string id)
        {
            throw new NotImplementedException();
        }
    }
}