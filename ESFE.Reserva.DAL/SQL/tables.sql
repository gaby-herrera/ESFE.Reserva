CREATE DATABASE DbHotel;
GO
USE DbHotel;
GO

CREATE TABLE [Cliente] (
  [IdCliente] INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Nombre] VARCHAR(50) NOT NULL,
  [Apellido] VARCHAR(50) NOT NULL,
  [Telefono] VARCHAR(9) NOT NULL,
  [CorreoElectronico] VARCHAR(100),
  [Dui] VARCHAR(10) NOT NULL
)
GO

CREATE TABLE [EstadoH] (
  [IdEstadoH] INT PRIMARY KEY IDENTITY(1, 1),
  [Nombre] VARCHAR(50)
)
GO

CREATE TABLE [EstadoR] (
  [IdEstadoR] INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Nombre] VARCHAR(50) NOT NULL
)
GO

CREATE TABLE [TipoHabitacion] (
  [IdTipoHabitacion] INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Nombre] VARCHAR(50) NOT NULL
)
GO

CREATE TABLE [Temporada] (
  [IdTemporada] INT PRIMARY KEY IDENTITY(1, 1),
  [Nombre] VARCHAR(50)
)
GO

CREATE TABLE [Tarifa] (
  [IdTarifa] INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [IdTipoHabitacion] INT NOT NULL,
  [IdTemporada] INT NOT NULL,
  [Temporada] VARCHAR(50) NOT NULL,
  [Precio] DECIMAL(10,2) NOT NULL
)
GO

CREATE TABLE [Habitacion] (
  [IdHabitacion] INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [NumeroHabitacion] SMALLINT NOT NULL,
  [IdTipoHabitacion] INT NOT NULL,
  [IdEstadoH] INT NOT NULL
)
GO

CREATE TABLE [Reserva] (
  [IdReserva] INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [IdEstadoR] INT NOT NULL,
  [IdCliente] INT NOT NULL,
  [IdHabitacion] INT NOT NULL,
  [FechaInicio] DATE NOT NULL,
  [FechaFin] DATE NOT NULL,
  [IdTarifa] INT NOT NULL
)
GO

ALTER TABLE [Tarifa] ADD FOREIGN KEY ([IdTipoHabitacion]) REFERENCES [TipoHabitacion] ([IdTipoHabitacion])
GO

ALTER TABLE [Habitacion] ADD FOREIGN KEY ([IdTipoHabitacion]) REFERENCES [TipoHabitacion] ([IdTipoHabitacion])
GO

ALTER TABLE [Habitacion] ADD FOREIGN KEY ([IdEstadoH]) REFERENCES [EstadoH] ([IdEstadoH])
GO

ALTER TABLE [Reserva] ADD FOREIGN KEY ([IdCliente]) REFERENCES [Cliente] ([IdCliente])
GO

ALTER TABLE [Reserva] ADD FOREIGN KEY ([IdHabitacion]) REFERENCES [Habitacion] ([IdHabitacion])
GO

ALTER TABLE [Reserva] ADD FOREIGN KEY ([IdEstadoR]) REFERENCES [EstadoR] ([IdEstadoR])
GO

ALTER TABLE [Reserva] ADD FOREIGN KEY ([IdTarifa]) REFERENCES [Tarifa] ([IdTarifa])
GO

ALTER TABLE [Tarifa] ADD FOREIGN KEY ([IdTemporada]) REFERENCES [Temporada] ([IdTemporada])
GO
