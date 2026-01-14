using ApiGestion.Models;
using ApiGestion.Pagination;
using ApiGestion.Repository;
using ApiGestion.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGestionTest
{
    public class ListaTest
    {
        private readonly Mock<IdueñoRepository> _repo;
        private readonly DueñoQuerySerivce _query;
        public ListaTest()
        {
            _repo = new Mock<IdueñoRepository>();
            _query = new DueñoQuerySerivce(_repo.Object);
        }
        [Fact]
        public async Task Getall()
        {
            var data = new Dueño
            {
                Nombre = "juan",
                Direccion = "nose",
                Dni = 12312354,
                Email = "juuanmelgar831@gmail.com",
                Iddueño = 99,
                Telefono = 12312354
            };
            var datalist = new List<Dueño> { data }; 
            _repo.Setup(r => r.GetAll(It.IsAny<PaginationRequest>()))
                .ReturnsAsync(datalist);
            var result = await _query.GetAllAsync(new PaginationRequest());
            Assert.NotNull(result);
            Assert.Single(result);
          
            Assert.Equal("juan", result[0].Nombre);
        }
    }
}
