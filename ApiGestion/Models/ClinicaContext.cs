using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiGestion.Models;

public partial class ClinicaContext : DbContext
{
    public ClinicaContext()
    {
    }

    public ClinicaContext(DbContextOptions<ClinicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Apliacion> Apliacions { get; set; }

    public virtual DbSet<Consulta> Consultas { get; set; }

    public virtual DbSet<Dueño> Dueños { get; set; }

    public virtual DbSet<Especialidad> Especialidads { get; set; }

    public virtual DbSet<Especie> Especies { get; set; }

    public virtual DbSet<Foto> Fotos { get; set; }

    public virtual DbSet<Mascotum> Mascota { get; set; }

    public virtual DbSet<Medicamento> Medicamentos { get; set; }

    public virtual DbSet<Raza> Razas { get; set; }

    public virtual DbSet<Tipovacuna> Tipovacunas { get; set; }

    public virtual DbSet<Tratamiento> Tratamientos { get; set; }

    public virtual DbSet<Veterinario> Veterinarios { get; set; }

    public virtual DbSet<Veterinarioespecialidad> Veterinarioespecialidads { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=JUANI\\SQLEXPRESS;Database=Clinica;Trusted_Connection=true;Encrypt=False;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Apliacion>(entity =>
        {
            entity.HasKey(e => e.Idaplicacionvacuna);

            entity.ToTable("Apliacion");

            entity.Property(e => e.Idaplicacionvacuna)
                .ValueGeneratedNever()
                .HasColumnName("IDaplicacionvacuna");
            entity.Property(e => e.Idmascotas).HasColumnName("IDmascotas");
            entity.Property(e => e.Idtipovacuna).HasColumnName("IDtipovacuna");
            entity.Property(e => e.Idvacuna).HasColumnName("IDvacuna");
            entity.Property(e => e.Idveterinario).HasColumnName("IDveterinario");
        });

        modelBuilder.Entity<Consulta>(entity =>
        {
            entity.HasKey(e => e.Idconsultas);

            entity.Property(e => e.Idconsultas)
                .ValueGeneratedNever()
                .HasColumnName("IDconsultas");
            entity.Property(e => e.Hora).HasColumnType("datetime");
            entity.Property(e => e.Idmascota).HasColumnName("IDmascota");
            entity.Property(e => e.Idveterinario).HasColumnName("IDveterinario");
            entity.Property(e => e.Motivo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Peso).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Dueño>(entity =>
        {
            entity.HasKey(e => e.Iddueño);

            entity.ToTable("Dueño");

            entity.Property(e => e.Iddueño).ValueGeneratedNever();
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });
        modelBuilder.Entity<Dueño>().HasData(new Dueño { Iddueño = 1, Nombre = "Juansito", Direccion = "Calle Falsa 123", Dni = 12312354, Email = "juansito@gmail.com", Telefono = 1153432132 }, new Dueño { Iddueño = 2, Nombre = "María López", Direccion = "Av. Siempre Viva 742", Dni = 30111222, Email = "maria.lopez@gmail.com", Telefono = 1145678901 }, new Dueño { Iddueño = 3, Nombre = "Carlos Pérez", Direccion = "San Martín 500", Dni = 28999888, Email = "carlos.perez@gmail.com", Telefono = 1133345566 }, new Dueño { Iddueño = 4, Nombre = "Ana Torres", Direccion = "Belgrano 250", Dni = 27888777, Email = "ana.torres@gmail.com", Telefono = 1122233344 }, new Dueño { Iddueño = 5, Nombre = "Luis Fernández", Direccion = "Mitre 100", Dni = 26777666, Email = "luis.fernandez@gmail.com", Telefono = 1199988877 }, new Dueño { Iddueño = 6, Nombre = "Sofía Ramírez", Direccion = "Rivadavia 321", Dni = 25666555, Email = "sofia.ramirez@gmail.com", Telefono = 1188877766 }, new Dueño { Iddueño = 7, Nombre = "Martín González", Direccion = "Colón 50", Dni = 24555444, Email = "martin.gonzalez@gmail.com", Telefono = 1177766655 }, new Dueño { Iddueño = 8, Nombre = "Laura Díaz", Direccion = "Independencia 88", Dni = 23444333, Email = "laura.diaz@gmail.com", Telefono = 1166655544 }, new Dueño { Iddueño = 9, Nombre = "Pedro Sánchez", Direccion = "Italia 12", Dni = 22333222, Email = "pedro.sanchez@gmail.com", Telefono = 1155544433 }, new Dueño { Iddueño = 10, Nombre = "Valentina Herrera", Direccion = "España 77", Dni = 21222111, Email = "valentina.herrera@gmail.com", Telefono = 1144433322 });

        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.HasKey(e => e.Idespecialidad);

            entity.ToTable("Especialidad");

            entity.Property(e => e.Idespecialidad)
                .ValueGeneratedNever()
                .HasColumnName("IDespecialidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Especie>(entity =>
        {
            entity.HasKey(e => e.IdEspecie);

            entity.ToTable("Especie");

            entity.Property(e => e.IdEspecie)
                .ValueGeneratedNever()
                .HasColumnName("idESPECIE");
            entity.Property(e => e.Gato).HasColumnName("gato");
            entity.Property(e => e.Idmascota).HasColumnName("IDmascota");
            entity.Property(e => e.Loro).HasColumnName("loro");
        });

        modelBuilder.Entity<Foto>(entity =>
        {
            entity.HasKey(e => e.Idfoto);

            entity.ToTable("fotos");

            entity.Property(e => e.Idfoto)
                .ValueGeneratedNever()
                .HasColumnName("IDfoto");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Idmascota).HasColumnName("IDmascota");
            entity.Property(e => e.Imagen)
                .HasColumnType("image")
                .HasColumnName("imagen");
        });

        modelBuilder.Entity<Mascotum>(entity =>
        {
            entity.HasKey(e => e.Idmascota);

            entity.Property(e => e.Idmascota)
                .ValueGeneratedNever()
                .HasColumnName("IDmascota");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Iddueño).HasColumnName("IDdueño");
            entity.Property(e => e.Idraza).HasColumnName("IDraza");
            entity.Property(e => e.Peso).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Raza)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Señas).IsUnicode(false);
        });

        modelBuilder.Entity<Medicamento>(entity =>
        {
            entity.HasKey(e => e.Idmedicamento);

            entity.ToTable("Medicamento");

            entity.Property(e => e.Idmedicamento)
                .ValueGeneratedNever()
                .HasColumnName("IDmedicamento");
            entity.Property(e => e.Droga)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("droga");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Presentacion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Raza>(entity =>
        {
            entity.HasKey(e => e.Idraza);

            entity.ToTable("RAZA");

            entity.Property(e => e.Idraza)
                .ValueGeneratedNever()
                .HasColumnName("IDraza");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Taamaño)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tipovacuna>(entity =>
        {
            entity.HasKey(e => e.Idtipovacuna);

            entity.ToTable("tipovacuna");

            entity.Property(e => e.Idtipovacuna)
                .ValueGeneratedNever()
                .HasColumnName("IDtipovacuna");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tratamiento>(entity =>
        {
            entity.HasKey(e => e.Idtratamiento);

            entity.ToTable("TRATAMIENTO");

            entity.Property(e => e.Idtratamiento)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("IDtratamiento");
            entity.Property(e => e.Dosis)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dosis");
            entity.Property(e => e.Duracoin).HasColumnName("duracoin");
            entity.Property(e => e.Idconsultas).HasColumnName("IDconsultas");
            entity.Property(e => e.Idmedicamento)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("IDmedicamento");
            entity.Property(e => e.Observaciones).HasColumnType("text");
        });

        modelBuilder.Entity<Veterinario>(entity =>
        {
            entity.HasKey(e => e.Idveterinario);

            entity.ToTable("veterinario");

            entity.Property(e => e.Idveterinario)
                .ValueGeneratedNever()
                .HasColumnName("IDveterinario");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Idespecialidad).HasColumnName("IDespecialidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Veterinarioespecialidad>(entity =>
        {
            entity.HasKey(e => e.Idveterinarioespecialidad);

            entity.ToTable("VETERINARIOespecialidad");

            entity.Property(e => e.Idveterinarioespecialidad)
                .ValueGeneratedNever()
                .HasColumnName("IDveterinarioespecialidad");
            entity.Property(e => e.Idveterinario).HasColumnName("IDveterinario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
