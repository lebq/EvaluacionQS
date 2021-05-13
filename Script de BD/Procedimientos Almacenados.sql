use BDEXAMEN
go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_Procedimiento_1')
DROP PROCEDURE usp_Procedimiento_1
GO

CREATE PROC usp_Procedimiento_1
as
begin
	select
		c.Nombres as [NombreCliente],
		c.Apellidos as [ApellidoCliente],
		v.Nombres as [NombreVendedor],
		v.Apellidos as [ApellidoVendedor],
		f.Fecha,
		SUM(df.PrecioUnitario) as [ValorFactura]
	from DETALLE_FACTURA df
	inner join FACTURA f 
	on df.FacturaId = f.FacturaId
	inner join CLIENTE c
	on f.ClienteId = c.ClienteId
	inner join VENDEDOR v
	on f.VendedorId = v.VendedorId
	group by c.Nombres, c.Apellidos,v.Nombres, v.Apellidos, f.Fecha
	order by ValorFactura desc
	
end
go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_Procedimiento_2')
DROP PROCEDURE usp_Procedimiento_2
GO

CREATE PROC usp_Procedimiento_2
as
begin
	select 
		c.ClienteId,
		c.Nombres,
		c.Apellidos,
		c.Nic,
		c.Categoria
	from FACTURA f
	right join CLIENTE c
	on f.ClienteId = c.ClienteId
	where c.Categoria = 'A' and f.FacturaId is null
end
go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_Procedimiento_3')
DROP PROCEDURE usp_Procedimiento_3
GO

CREATE PROC usp_Procedimiento_3
as
begin
	select * from PRODUCTO
end
go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_Procedimiento_4')
DROP PROCEDURE usp_Procedimiento_4
GO

CREATE PROC usp_Procedimiento_4
as
begin
	select
		VendedorId,
		Nombres,
		Apellidos,
		Dni,
		FechaIngreso
	from VENDEDOR
	where YEAR(FechaIngreso) = 2019
end
go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_Procedimiento_5')
DROP PROCEDURE usp_Procedimiento_5
GO

CREATE PROC usp_Procedimiento_5(
@FacturaId int,
@ProductoId int,
@Cantidad decimal(18,5),
@PrecioTotal  decimal(18,5)
)as
begin
	IF (@ProductoId != 0)
	begin
		if (@Cantidad > 0)
		begin
			insert into DETALLE_FACTURA(FacturaId,ProductoId,Cantidad,PrecioUnitario) values (
		@FacturaId,@ProductoId,@Cantidad,@PrecioTotal
		)
		end
	end
end
go