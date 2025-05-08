
-- Script generado para la base de datos MenuX
-- Fecha de generación: 2025-05-08 04:06:29

-- ======================================
-- CREACIÓN DE LA BASE DE DATOS
-- ======================================
IF DB_ID('MenuX') IS NULL
    CREATE DATABASE MenuX;
GO

USE MenuX;
GO

-- ======================================
-- TABLA: Usuarios
-- ======================================
IF OBJECT_ID('Usuarios', 'U') IS NOT NULL
    DROP TABLE Usuarios;
GO

CREATE TABLE Usuarios (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    PasswordHash NVARCHAR(200) NOT NULL,
    Rol NVARCHAR(50) NOT NULL
);
GO

INSERT INTO Usuarios (Id, Nombre, Email, PasswordHash, Rol) VALUES
(NEWID(), 'Administrador', 'admin@menux.com', 'admin123', 'Admin'),
(NEWID(), 'Camarero Juan', 'juan@menux.com', '123456', 'Mesero');
GO

-- ======================================
-- TABLA: Reservas
-- ======================================
IF OBJECT_ID('Reservas', 'U') IS NOT NULL
    DROP TABLE Reservas;
GO

CREATE TABLE Reservas (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    NombreCliente NVARCHAR(100) NOT NULL,
    FechaReserva DATETIME NOT NULL,
    CantidadPersonas INT NOT NULL,
    Telefono NVARCHAR(20),
    Observaciones NVARCHAR(255)
);
GO

INSERT INTO Reservas (Id, NombreCliente, FechaReserva, CantidadPersonas, Telefono, Observaciones) VALUES
(NEWID(), 'Carlos López', '2025-05-10 19:00', 4, '3112223344', 'Mesa cerca de la ventana'),
(NEWID(), 'Ana Gómez', '2025-05-11 20:30', 2, '3101234567', NULL);
GO

-- ======================================
-- TABLA: Pedidos
-- ======================================
IF OBJECT_ID('Pedidos', 'U') IS NOT NULL
    DROP TABLE Pedidos;
GO

CREATE TABLE Pedidos (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    ClienteNombre NVARCHAR(100) NOT NULL,
    Fecha DATETIME NOT NULL
);
GO

-- ======================================
-- TABLA: PedidoItems
-- ======================================
IF OBJECT_ID('PedidoItems', 'U') IS NOT NULL
    DROP TABLE PedidoItems;
GO

CREATE TABLE PedidoItems (
    Id INT PRIMARY KEY IDENTITY(1,1),
    NombreProducto NVARCHAR(100) NOT NULL,
    Cantidad INT NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    PedidoId UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id) ON DELETE CASCADE
);
GO

-- ======================================
-- EJEMPLO DE UN PEDIDO CON ITEMS
-- ======================================
DECLARE @pedidoId UNIQUEIDENTIFIER = NEWID();
INSERT INTO Pedidos (Id, ClienteNombre, Fecha) VALUES (@pedidoId, 'Laura Torres', GETDATE());

INSERT INTO PedidoItems (NombreProducto, Cantidad, Precio, PedidoId) VALUES
('Pizza Margarita', 2, 8.99, @pedidoId),
('Limonada', 2, 3.50, @pedidoId);
GO
