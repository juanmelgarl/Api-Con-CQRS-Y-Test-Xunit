using ApiGestion.Controllers;
using ApiGestion.DTOS.Request;
using ApiGestion.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGestionTest
{
    public class TestController
    {
        private readonly Mock<IDueñoQueryService> _service;
        private readonly Mock<IDueñoCommand> _Command;
        private readonly DueñoController _controller;

        public TestController()
        {
            _service = new Mock<IDueñoQueryService>();
            _Command = new Mock<IDueñoCommand>();
            _controller = new DueñoController(_Command.Object,_service.Object);
        }
        [Fact]
        public async Task CrearDtonull()
        {
            var result = await _controller.CrearDueño(null);
            Assert.IsType<BadRequestResult>(result.Result);
        }
        [Fact]

        public async Task CrearDtoValido()
        {
            var dto = new CreateDTO { Nombre = "juan", Direccion = "oose", Dni = 12312343, Email = "juanmelgar@gmail.com", Telefono = 12312323 };
            _Command.Setup(c => c.CreateAsync(dto));
            var result = await _controller.CrearDueño(dto);
            Assert.IsType<OkResult>(result.Result);
        }
        [Fact]
        public async Task ObtenerIdInvalido()
        {
            var result = await _controller.Obtenerporid(0);
            Assert.IsType<BadRequestResult>(result.Result);
        }
        [Fact]
        public async Task ObtenerIdVALIDO()
        {
            _service.Setup(q => q.GetForIdAsync(1))
                .ReturnsAsync(new ApiGestion.DTOS.Response.Dueñoresponse
                {
                    IDdueño = 1,
                    Nombre = "juan",
                    Direccion = "nose",
                    Dni = 12312354,
                    Email = "juanmelgar@melgar.com",
                    Telefono = 32432423
                });
            var result = await _controller.Obtenerporid(1);
            var ok = Assert.IsType<OkObjectResult>(result.Result);
            Assert.NotNull(ok.Value);
        }
        [Fact]
        public async Task ActualizarInvalido()
        {
             _Command.Setup(c => c.UpdateAsync(1,It.IsAny<UpdateDTO>()))
                .ReturnsAsync(false);
            var result = await _controller.Actualizar(new UpdateDTO(), 1);
            Assert.IsType<NotFoundResult>(result.Result);
        }


    }
}
