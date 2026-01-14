
using ApiGestion.DTOS.Request;
using ApiGestion.Models;
using ApiGestion.Repository;
using ApiGestion.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGestionTest
{
    public class DueñoCommandServiceTest
    {
        private readonly Mock<IdueñoRepository> _repo;
        private readonly DueñoCommandServicec _service;
        public DueñoCommandServiceTest()
        {
            _repo = new Mock<IdueñoRepository>();
            _service = new DueñoCommandServicec(_repo.Object);
        }
        [Fact]
        public async Task Crear_deberiaGuardar()
        {
            var dto = new CreateDTO
            {
                Nombre = "juan",
                Direccion = "nose",
                Dni = 12312354,
                Email = "juanmelgar@gmail.com",
                Telefono = 12312354
            };

            _repo
                .Setup(r => r.Add(It.IsAny<Dueño>()))
                .Returns(Task.CompletedTask);

            
            await _service.CreateAsync(dto);

            _repo.Verify(r => r.Add(It.IsAny<Dueño>()), Times.Once);
        }
    }
}
