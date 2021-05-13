USE master
GO

IF NOT EXISTS(SELECT name FROM master.dbo.sysdatabases WHERE NAME = 'BDEXAMEN')
CREATE DATABASE BDEXAMEN
GO 

USE BDEXAMEN
GO

--(1) TABLA CLIENTE
if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'CLIENTE')
create table CLIENTE(
ClienteId int primary key identity(1,1),
Nombres varchar(50),
Apellidos varchar(50),
Nic varchar(12),
Categoria char(1)
)
GO

--(2) TABLA PRODUCTO
if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'PRODUCTO')
create table PRODUCTO(
ProductoId int primary key identity(1,1),
Descripcion varchar(50),
PrecioUnitario decimal(18,5),
Categoria char(2)
)
GO

--(3) TABLA VENDEDOR
if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'VENDEDOR')
create table VENDEDOR(
VendedorId int primary key identity(1,1),
Nombres varchar(50),
Apellidos varchar(50),
Dni char(8),
FechaIngreso date
)
GO

--(4) TABLA FACTURA
if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'FACTURA')
create table FACTURA(
FacturaId int primary key identity(1,1),
Serie varchar(3),
Codigo varchar(5),
VendedorId int references VENDEDOR(VendedorId),
ClienteId int references CLIENTE(ClienteId),
Fecha date,
Moneda char(3)
)
GO

--(5) TABLA DETALLE_FACTURA
if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'DETALLE_FACTURA')
create table DETALLE_FACTURA(
DetalleFacturaId int primary key identity(1,1),
FacturaId int references FACTURA(FacturaId),
ProductoId int references PRODUCTO(ProductoId),
Cantidad int,
PrecioUnitario decimal(18,5)
)
GO