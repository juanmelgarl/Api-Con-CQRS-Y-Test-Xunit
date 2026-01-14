using ApiGestion.DTOS.Request;
using ApiGestion.Models;
using ApiGestion.Repository;
using ApiGestion.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ApiGestionTest
{
    public class IsMayorA0Test
    {
        private readonly Mock<IdueñoRepository> _repo;
        private readonly DueñoCommandServicec _commandService;

        public IsMayorA0Test()
        {
            _repo = new Mock<IdueñoRepository>();
            _commandService = new DueñoCommandServicec(_repo.Object);

        }
        [Fact]
        public async Task Crear()
        {
            var dueño = new CreateDTO();
            dueño.Nombre = "juan";
            dueño.Direccion = "nose";
            dueño.Telefono = 12312354;
            dueño.Email = "juanmelgar@gmail.com";
            _repo.Setup(r => r.Add(It.IsAny<Dueño>()))
         .Returns(Task.CompletedTask);
            await _commandService.CreateAsync(dueño);
            _repo.Verify(r => r.Add(It.IsAny<Dueño>()), Times.Once());  
        }
        
    }
}