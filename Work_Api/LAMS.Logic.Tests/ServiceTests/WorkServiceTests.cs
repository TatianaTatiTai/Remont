using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LAMS.DataAccess.Common.Models.Work;
using LAMS.DataAccess.Common.Repositories.Work;
using LAMS.Logic.Common.Models.Work;
using LAMS.Logic.Common.Services.Work;
using LAMS.Logic.Services.Work;
using LAMS.Logic.Tests.Moqs;
using Moq;
using NUnit.Framework;

namespace LAMS.Logic.Tests.ServiceTests
{
    [TestFixture]
    public class WorkServiceTests
    {
        private IMapper _mapper;
        private IWorkService _service;
        private IWorkRepository _repo;

        public WorkServiceTests()
        {
            _repo = new WorkRepositoryMoq();

            MapperConfiguration mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<DocumentBLL, DocumentDb>();
                config.CreateMap<DocumentDb, DocumentBLL>();
                config.CreateMap<OrderDb, OrderBLL>();
                config.CreateMap<OrderBLL, OrderDb>();
                config.CreateMap<OrderMaterialBLL, OrderMaterialDb>();
                config.CreateMap<OrderMaterialDb, OrderMaterialBLL>();
                config.CreateMap<EvaluationBLL, EvaluationDb>();
                config.CreateMap<EvaluationDb, EvaluationBLL>();
                config.CreateMap<OrderWorkerCostBLL, OrderWorkerCostDb>();
                config.CreateMap<OrderWorkerCostDb, OrderWorkerCostBLL>();
                config.CreateMap<OrderWorkTypeBLL, OrderWorkTypeDb>();
                config.CreateMap<OrderWorkTypeDb, OrderWorkTypeBLL>();
            });

            mappingConfig.CompileMappings();

            _mapper = mappingConfig.CreateMapper();

            _service = new WorkService(_repo, _mapper);
        }

        [Test]
        public async Task AddWorkDirectionReturnsOne()
        {
            // Arrange
            DocumentBLL document = new DocumentBLL()
            {
                Id = 1
            };

            // Act
            var result = await _service.AddDocument(document);

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public async Task GetDocumentsReturnsDocumentBLL()
        {
            // Arrange
            DocumentBLL direction = new DocumentBLL()
            {
                Id = 1
            };

            // Act
            var result = await _service.GetDocuments(document.Id.ToString());

            // Assert
            Assert.AreEqual(document.Id, result.FirstOrDefault().Id);
        }

        [Test]
        public async Task AddOrderReturnsOne()
        {
            // Arrange
            OrderBLL order = new OrderBLL()//создала фейковый обьект
            {
                Id = 4
            };

            // Act
            var result = await _service.AddOrder(order);//фейковый обьект отправляю в метод для тестирования

            // Assert
            Assert.AreEqual(1111, result);

        }

        [Test]
        public async Task OrderOrderReturnsOne()
        {
            // Arrange
            OrderWorkerCostBLL course = new OrderWorkerCostBLL();//создала фейковый обьект

            // Act
            var result = await _service.OrderOrder(order);//фейковый обьект отправляю в метод для тестирования

            // Assert
            Assert.AreEqual(1, result);


        }
    }
}