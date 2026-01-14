using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiGestion.Migrations
{
    /// <inheritdoc />
    public partial class InitlaEmpty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apliacion",
                columns: table => new
                {
                    IDaplicacionvacuna = table.Column<int>(type: "int", nullable: false),
                    IDvacuna = table.Column<int>(type: "int", nullable: false),
                    IDmascotas = table.Column<int>(type: "int", nullable: false),
                    IDtipovacuna = table.Column<int>(type: "int", nullable: false),
                    IDveterinario = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apliacion", x => x.IDaplicacionvacuna);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    IDconsultas = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Hora = table.Column<DateTime>(type: "datetime", nullable: false),
                    Motivo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    IDveterinario = table.Column<int>(type: "int", nullable: false),
                    IDmascota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.IDconsultas);
                });

            migrationBuilder.CreateTable(
                name: "Dueño",
                columns: table => new
                {
                    Iddueño = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dueño", x => x.Iddueño);
                });

            migrationBuilder.CreateTable(
                name: "Especialidad",
                columns: table => new
                {
                    IDespecialidad = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidad", x => x.IDespecialidad);
                });

            migrationBuilder.CreateTable(
                name: "Especie",
                columns: table => new
                {
                    idESPECIE = table.Column<int>(type: "int", nullable: false),
                    Perro = table.Column<bool>(type: "bit", nullable: false),
                    gato = table.Column<bool>(type: "bit", nullable: false),
                    loro = table.Column<bool>(type: "bit", nullable: false),
                    IDmascota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especie", x => x.idESPECIE);
                });

            migrationBuilder.CreateTable(
                name: "fotos",
                columns: table => new
                {
                    IDfoto = table.Column<int>(type: "int", nullable: false),
                    imagen = table.Column<byte[]>(type: "image", nullable: false),
                    IDmascota = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fotos", x => x.IDfoto);
                });

            migrationBuilder.CreateTable(
                name: "Mascota",
                columns: table => new
                {
                    IDmascota = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Raza = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Señas = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    IDdueño = table.Column<int>(type: "int", nullable: false),
                    IDraza = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascota", x => x.IDmascota);
                });

            migrationBuilder.CreateTable(
                name: "Medicamento",
                columns: table => new
                {
                    IDmedicamento = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    droga = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Presentacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamento", x => x.IDmedicamento);
                });

            migrationBuilder.CreateTable(
                name: "RAZA",
                columns: table => new
                {
                    IDraza = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Taamaño = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAZA", x => x.IDraza);
                });

            migrationBuilder.CreateTable(
                name: "tipovacuna",
                columns: table => new
                {
                    IDtipovacuna = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipovacuna", x => x.IDtipovacuna);
                });

            migrationBuilder.CreateTable(
                name: "TRATAMIENTO",
                columns: table => new
                {
                    IDtratamiento = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    IDconsultas = table.Column<int>(type: "int", nullable: false),
                    duracoin = table.Column<int>(type: "int", nullable: false),
                    dosis = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Observaciones = table.Column<string>(type: "text", nullable: false),
                    IDmedicamento = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRATAMIENTO", x => x.IDtratamiento);
                });

            migrationBuilder.CreateTable(
                name: "veterinario",
                columns: table => new
                {
                    IDveterinario = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Nummatricula = table.Column<int>(type: "int", nullable: false),
                    IDespecialidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veterinario", x => x.IDveterinario);
                });

            migrationBuilder.CreateTable(
                name: "VETERINARIOespecialidad",
                columns: table => new
                {
                    IDveterinarioespecialidad = table.Column<int>(type: "int", nullable: false),
                    IDveterinario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VETERINARIOespecialidad", x => x.IDveterinarioespecialidad);
                });

            migrationBuilder.InsertData(
                table: "Dueño",
                columns: new[] { "Iddueño", "Direccion", "Dni", "Email", "nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Calle Falsa 123", 12312354, "juansito@gmail.com", "Juansito", 1153432132 },
                    { 2, "Av. Siempre Viva 742", 30111222, "maria.lopez@gmail.com", "María López", 1145678901 },
                    { 3, "San Martín 500", 28999888, "carlos.perez@gmail.com", "Carlos Pérez", 1133345566 },
                    { 4, "Belgrano 250", 27888777, "ana.torres@gmail.com", "Ana Torres", 1122233344 },
                    { 5, "Mitre 100", 26777666, "luis.fernandez@gmail.com", "Luis Fernández", 1199988877 },
                    { 6, "Rivadavia 321", 25666555, "sofia.ramirez@gmail.com", "Sofía Ramírez", 1188877766 },
                    { 7, "Colón 50", 24555444, "martin.gonzalez@gmail.com", "Martín González", 1177766655 },
                    { 8, "Independencia 88", 23444333, "laura.diaz@gmail.com", "Laura Díaz", 1166655544 },
                    { 9, "Italia 12", 22333222, "pedro.sanchez@gmail.com", "Pedro Sánchez", 1155544433 },
                    { 10, "España 77", 21222111, "valentina.herrera@gmail.com", "Valentina Herrera", 1144433322 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apliacion");

            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Dueño");

            migrationBuilder.DropTable(
                name: "Especialidad");

            migrationBuilder.DropTable(
                name: "Especie");

            migrationBuilder.DropTable(
                name: "fotos");

            migrationBuilder.DropTable(
                name: "Mascota");

            migrationBuilder.DropTable(
                name: "Medicamento");

            migrationBuilder.DropTable(
                name: "RAZA");

            migrationBuilder.DropTable(
                name: "tipovacuna");

            migrationBuilder.DropTable(
                name: "TRATAMIENTO");

            migrationBuilder.DropTable(
                name: "veterinario");

            migrationBuilder.DropTable(
                name: "VETERINARIOespecialidad");
        }
    }
}
