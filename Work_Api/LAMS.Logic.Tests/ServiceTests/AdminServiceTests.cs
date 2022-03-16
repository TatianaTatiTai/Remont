using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LAMS.DataAccess.Common.Models.Admin;
using LAMS.DataAccess.Common.Repositories.Admin;
using LAMS.Logic.Common.Models.Admin;
using LAMS.Logic.Common.Models.Work;
using LAMS.Logic.Common.Services.Admin;
using LAMS.Logic.Services.Admin;
using LAMS.Logic.Tests.Moqs;
using NUnit.Framework;

namespace LAMS.Logic.Tests.ServiceTests
{
    [TestFixture]
    public class AdminServiceTests
    {
        private IAdminRepository _repo;
        private IAdminService _service;
        private IMapper _mapper;

        public AdminServiceTests()
        {
            _repo = new AdminRepositoryMoq();

            MapperConfiguration mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<MaterialBLL, MaterialDb>();
                config.CreateMap<MaterialDb, MaterialBLL>();
            });

            mappingConfig.CompileMappings();

            _mapper = mappingConfig.CreateMapper();

            _service = new AdminService(_repo, _mapper);
        }

        [Test]
        public async Task AddMaterialReturnsId()// что возвращает сервис
        {
            // Arrange
            MaterialBLL material = new MaterialBLL()// создается обьект класса material bll
            {
                Id = 1,
                Material = "Material1"
            };

            // Act
            var result = await _service.AddMaterial(material);

            // Assert
            Assert.AreEqual(material.Id, result);
        }
    }

}
