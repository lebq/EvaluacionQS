use BDEXAMEN
go

--REGISTROS EN TABLA CLIENTE
INSERT INTO CLIENTE(Nombres,Apellidos,Nic,Categoria) VALUES ('LUIS ENRIQUE','BALDEON QUISPE','lbaldeon','C'),
															('JOSE ALBERTO','RODRIGUEZ PRADO','jrodriguez','C'),
															('JOHN ALEXANDER','INFANTE SANCHEZ','jinfante','A'),
															('ANA MARIA','FERNANDEZ LOAYZA','afernandez','C'),
															('CARMEN ROSA','QUISPE ORELLANA','cquispe','B'),
															('BEATRIZ CAROLINA','SANTANA ARANDA','bsantana','A'),
															('JIMENA LIZ','PAREDES GOMEZ','jparedes','A')

--REGISTROS EN TABLA VENDEDOR
INSERT INTO VENDEDOR(Nombres,Apellidos,Dni,FechaIngreso) VALUES ('ANTONI SAMUEL','MADRID ALVARADO','75421523','2000-05-20'),
																('JAIME CARLOS','JUAREZ SAENZ','75482153','2001-12-24'),
																('JACK HUMBERTO','MEDINA MEDINA','75496325','2015-06-01'),
																('GLORIA MILAGROS','VILCHEZ ARIAS','78965235','2011-10-08'),
																('CINTYA HAYDE','SOLIS GARCIA','75201452','2012-06-05'),
																('MATHIAS LUIS','SORIN PACHECO','75632010','2019-07-07')

--REGISTROS EN TABLA PRODUCTO
INSERT INTO PRODUCTO(Descripcion,PrecioUnitario,Categoria) VALUES ('LECHE','2.00','LA'),
																('GASEOSA','2.50','GA'),
																('EMBUTIDO','2.40','EM'),
																('LEJIA','1.50','LI'),
																('GALLETA','1.00','GA'),
																('ARROZ','3.50','AR'),
																('AZUCAR','4.00','AZ'),
																('PAPEL','0.50','PA'),
																('DESODORANTE','1.00','DE')

--REGISTROS EN TABLA FACTURA
INSERT INTO FACTURA(Serie,Codigo,VendedorId,ClienteId,Fecha,Moneda) VALUES ('111','12345',2,3,'2021-01-20','SOL'),
																		('222','56789',1,2,'2021-02-13','SOL'),
																		('333','45872',4,1,'2021-01-05','DOL'),
																		('444','65423',2,4,'2021-03-16','DOL'),
																		('555','58726',5,3,'2021-04-28','DOL'),
																		('666','95236',2,5,'2021-03-02','SOL'),
																		('777','50256',1,3,'2021-03-10','SOL')

--REGISTROS EN TABLA DETALLE_FACTURA
INSERT INTO DETALLE_FACTURA(FacturaId,ProductoId,Cantidad,PrecioUnitario) VALUES (1,2,2,5),
																				(1,3,3,7.2),
																				(1,1,5,10),
																				(2,3,1,2.4),
																				(2,1,2,4),
																				(3,5,3,5),
																				(4,6,3,10.5),
																				(4,3,1,2.4),
																				(4,8,5,2.5),
																				(4,1,5,10)