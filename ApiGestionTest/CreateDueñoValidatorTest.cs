using ApiGestion.DTOS.Request;
using ApiGestion.Validatins;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGestionTest
{
    public class CreateDueñoValidatorTest
    {
        private readonly CreateDueñoValidator _validator;

        public CreateDueñoValidatorTest()
        {
            _validator = new CreateDueñoValidator();
        }
        [Fact]

        public void Nombrefallido()
        {
            var dto = new CreateDTO { Nombre = "" };
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.Nombre);
        }
        [Fact]

        public void Nombredemasde30caracteres()
        {
            var dto = new CreateDTO { Nombre = new string('a', 31) };
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.Nombre);
        }
        [Fact]

        public void Dnideberiafallar()
        {
            var dto = new CreateDTO { Dni = 0 };
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.Dni);
        }
        [Fact]
        public void Direcciondeberiafallar()
        {
            var dto = new CreateDTO { Direccion = "" };
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.Direccion);

        }
        [Fact]
        public void Direccionodeberiafallar()
        {
            var dto = new CreateDTO { Direccion = "Juanmarengo" };
            var result = _validator.TestValidate(dto);
            result.ShouldNotHaveValidationErrorFor(c => c.Direccion);
        }
        [Fact]
        public void Dtonodeberiafallar()
        {
            var dto = new CreateDTO { Nombre = "Juan melgar", Direccion = "nose", Dni = 12123545, Email = "juansito123gmail.com", Telefono = 321232132 };
            var result = _validator.TestValidate(dto);
            result.ShouldNotHaveAnyValidationErrors();

        }

    }
    }
