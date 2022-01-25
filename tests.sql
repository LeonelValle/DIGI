create database DIGI

create table tb_Ensamble(id_ensamble int primary key identity(1,1), ensamble varchar(100))

create table tb_Operador(id_operador int primary key identity(1,1), nombre varchar(100), numeroempleado int)

create table tb_Orden(id_orden int primary key identity(1,1), orden float unique, cantidad int, fechaOrden date, FechaCierre date, id_operador int, id_ensamble int, rev varchar(5), consecutivo int, numerocaja int, TotalCajas bit, PiezaCaja int
foreign key(id_operador) references tb_Operador(id_operador),
foreign key(id_ensamble) references tb_ensamble(id_ensamble) on delete cascade on update cascade)


create table tb_caja(id_caja int primary key identity(1,1), caja varchar(255) unique, NCaja int)


create table tb_ModeloOrden(id_modeloOrden int primary key identity(1,1), Serialnumber varchar(255), scanmac varchar(100), scanimei varchar(255), qr varchar(255) ,id_orden int, checked bit, fecharegistro datetime, id_caja int, Problema varchar(255), turno varchar(20), revision varchar(5)
foreign key(id_orden) references tb_Orden(id_orden) on delete cascade on update cascade,
foreign key(id_caja) references tb_Caja(id_caja) on delete cascade on update cascade)


create table ConfiguracionSistema(id_cs int primary key identity(1,1), consecutivo int, nomenclatura varchar(50), numerocaja int, conexion varchar(100), TotalCajas bit, PiezaCaja int)

create table tb_Historial(id_historial int primary key identity(1,1), Serialnumber varchar(255), scanmac varchar(100), scanimei varchar(255), id_orden int, checked bit, fecharegistro datetime, id_caja int, Problema varchar(255), turno varchar(20), fechaCambio datetime,
foreign key(id_orden) references tb_Orden(id_orden) on delete cascade on update cascade,
foreign key(id_caja) references tb_Caja(id_caja) on delete cascade on update cascade)

create table tb_ModeloOrdenCaja(id_mocaja int primary key identity(1,1), SerialNumberCaja varchar(255), scanmacCaja varchar(255), scanimeiCaja varchar(255), qrCaja varchar(255), id_caja int, id_orden int,
foreign key(id_caja) references tb_Caja(id_caja) on delete cascade on update cascade,
foreign key(id_orden) references tb_Orden(id_orden) on delete cascade on update cascade)

create table tbUnion_MoCaja(id_Umocaja int primary key identity(1,1), id_modeloOrden int, id_mocaja int,
foreign key(id_modeloOrden) references tb_ModeloOrden(id_modeloOrden),
foreign key(id_mocaja) references tb_ModeloOrdenCaja(id_mocaja))


create table tb_SetUp(id_setup int primary key identity(1,1), serialnumber bit, serialnumberCaja bit, mac bit, macCaja bit, imei bit, imeiCaja bit, qr bit, qrCaja bit, id_orden int,
foreign key(id_orden) references tb_Orden(id_orden) on delete cascade on update cascade)


delete from tb_ModeloOrden
delete from tb_ModeloOrdenCaja

insert into tb_Ensamble values('ensamble01', true)
insert into tb_SetUp(serialnumber) values('false')


select * from tb_ModeloOrdenCaja
select * from tb_Ensamble
select * from ConfiguracionSistema
select * from tb_Orden
select * from tb_Operador
select * from tb_ModeloOrden
select * from tb_caja

select Serialnumber, scanmac, scanimei, o.orden, fecharegistro, c.caja, turno from tb_ModeloOrden mo, tb_Orden o, tb_caja c 
select COUNT(*) from tb_ModeloOrden
select mo.Serialnumber, mo.scanmac, mo.scanimei, o.orden, mo.fecharegistro, c.caja, mo.turno from tb_ModeloOrden mo, tb_Orden o, tb_caja c where mo.id_orden = o.id_orden and mo.id_caja = c.id_caja and mo.id_orden = 1

insert into tb_Operador values('Leonel Valle', 2891),('Juan Lopez', 2733)
insert into tb_orden (orden, cantidad, fechaOrden, id_operador, id_ensamble ,rev) values('1.1' , 50 , '06/26/2019' , 1 , 1, 'A')


create table #tb_Shipping(serialnumber varchar(255), mac varchar(255), imei varchar(255), qr varchar(255), serialnumberCaja varchar(255), macCaja varchar(255), imeiCaja varchar(255),
qrCaja varchar(255), orden float, fecharegistro datetime, caja varchar(255), turno varchar(50), revision varchar(5), numeroempleado int)

insert into #tb_Shipping(serialnumber, mac, imei,qr,serialnumberCaja,macCaja,imeiCaja,qrCaja,orden,fecharegistro,caja,turno,revision,numeroempleado) select mo.Serialnumber, mo.scanmac, mo.scanimei, mo.qr, moc.SerialNumberCaja, moc.scanmacCaja, moc.scanimeiCaja, moc.qrCaja, o.orden, 
mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrdenCaja moc, tb_ModeloOrden mo, tb_Orden o, tb_caja c, tbUnion_MoCaja u, 
tb_Operador op where mo.id_orden = o.id_orden and moc.id_orden = o.id_orden and mo.id_orden = moc.id_orden and mo.id_modeloOrden = u.id_modeloOrden and 
moc.id_mocaja = u.id_mocaja and c.id_caja = mo.id_caja and o.id_operador = op.id_operador and c.id_caja = 1


select mo.Serialnumber, mo.scanmac, mo.scanimei, mo.qr, moc.SerialNumberCaja, moc.scanmacCaja, moc.scanimeiCaja, moc.qrCaja, o.orden, 
mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrdenCaja moc, tb_ModeloOrden mo, tb_Orden o, tb_caja c, tbUnion_MoCaja u, 
tb_Operador op where mo.id_orden = o.id_orden and moc.id_orden = o.id_orden and mo.id_orden = moc.id_orden and mo.id_modeloOrden = u.id_modeloOrden and 
moc.id_mocaja = u.id_mocaja and c.id_caja = mo.id_caja and o.id_operador = op.id_operador and c.id_caja = 16
select * from #tb_Shipping
select * from tb_caja
select * from tb_ModeloOrden

drop table #tb_Shipping

go
create trigger Crear_Cajas on tb_ModeloOrden
after insert as begin 
--CAJAS
declare @id_Caja as int
declare @Caja as int
declare @Nomenclatura as varchar(5)
declare @NumeroCaja as int 
declare @Contador as int
declare @Limite as int 
declare @count as int
declare @con as int
declare @id_ModeloOrden as int
declare @id_Orden as int
declare @Ncaja as int
declare @ExisteCaja as int
--set @Ultima = (SELECT TOP 1 id_orden From (select Top 2 * from tb_ModeloOrden ORDER BY id_modeloOrden DESC) x ORDER BY id_modeloOrden)
set @id_Orden = (select id_orden from inserted)
set @id_ModeloOrden = (select id_modeloOrden from inserted)
--set @id_Caja = (select TOP 1 id_caja from tb_caja order by id_caja desc)
set @id_Caja = (select TOP 1 id_caja from tb_ModeloOrden where id_orden = @id_Orden order by id_caja desc)
set @Caja = (select consecutivo from ConfiguracionSistema where id_cs = 1)
set @Ncaja = (select NCaja from tb_caja where id_caja = @id_Caja)
set @Nomenclatura = (select nomenclatura from ConfiguracionSistema where id_cs = 1)
--set @Contador = (select numerocaja from ConfiguracionSistema where id_cs = 2)
set @Contador = (select numerocaja from tb_Orden where id_orden = @id_Orden)
--set @Limite = (select PiezaCaja from ConfiguracionSistema where id_cs = 3)
set @Limite = (select PiezaCaja from tb_Orden where id_orden = @id_Orden)
set @ExisteCaja =  (select result = NULLIF(COUNT(*),0) FROM tb_caja where id_caja = @id_Caja)
update ConfiguracionSistema set TotalCajas = 0 where id_cs = 2
--CAJAS
	if @Contador <= @Limite and @ExisteCaja = 1
		begin
			--set @count = @count + 1
			set @con = @con + 1				
			--update ConfiguracionSistema set numerocaja = @Contador where id_cs = 2
			update tb_Orden set numerocaja = @Contador where id_orden = @id_Orden
			update tb_ModeloOrden set id_caja = @id_Caja where id_modeloOrden = @id_ModeloOrden				
		end
	else
		begin
			set @caja = @caja + 1
			set @con = @con + 1
			set @Contador = 1
			--update ConfiguracionSistema set numerocaja = 1 where id_cs = 2
			update tb_Orden set numerocaja = 1 where id_orden = @id_Orden
			update ConfiguracionSistema set TotalCajas = 0 where id_cs = 2
			update ConfiguracionSistema set consecutivo = @Caja where id_cs = 1			
			insert into tb_caja (caja) values(@Nomenclatura + CONVERT(varchar,@caja))		
			set @id_Caja = (SELECT IDENT_CURRENT('tb_caja') as IdentCurrent)
			update tb_ModeloOrden set id_caja = @id_Caja where id_modeloOrden = @id_ModeloOrden
		end
	set @Contador = @Contador + 1
	--update ConfiguracionSistema set numerocaja = @Contador where id_cs = 2
	update tb_Orden set numerocaja = @Contador where id_orden = @id_Orden
END


go
create trigger HistoryChanges on tb_ModeloOrden
after update as begin
insert into tb_Historial select Serialnumber, scanmac, scanimei, id_orden, checked, fecharegistro, id_caja, Problema, turno, GETDATE() from deleted
End

select mo.Serialnumber, mo.scanmac, mo.scanimei, o.orden, e.ensamble ,mo.fecharegistro, c.caja, mo.turno, o.rev, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on mo.id_orden = o.id_orden join tb_caja c on mo.id_caja = c.id_caja join tb_Ensamble e on o.id_ensamble = e.id_ensamble join tb_Operador op on o.id_operador = op.id_operador join tb_ModeloOrdenCaja moc on mo.id_orden = moc.id_orden

select count() from tb_ModeloOrden where id_caja = 1

select mo.Serialnumber, mo.scanmac, mo.scanimei, mo.qr, moc.SerialNumberCaja, moc.scanmacCaja, moc.scanimeiCaja, moc.qrCaja from tb_ModeloOrdenCaja moc, tb_ModeloOrden mo, tb_Orden o, tbUnion_MoCaja u where mo.id_orden = o.id_orden and moc.id_orden = o.id_orden and mo.id_orden = moc.id_orden and mo.id_modeloOrden = u.id_modeloOrden and moc.id_mocaja = u.id_mocaja

select count(*) from tb_ModeloOrden where id_orden = 5 and id_caja = null

declare @ExisteCaja as int
set @ExisteCaja =  (select result = NULLIF(COUNT(*),0) FROM tb_caja where id_caja = 30)
select @ExisteCaja
select TOP 1 id_caja from tb_ModeloOrden where id_orden = 5 order by id_caja desc
select id_caja from tb_ModeloOrden where id_orden = 5

insert into tb_ModeloOrden(Serialnumber, scanmac, id_orden) values(71587 , 1234123, 1) 
insert into tb_ModeloOrden(Serialnumber, scanmac, id_orden) values(31213 , 18578, 5) 
INSERT INTO tb_ModeloOrden (Serialnumber, scanmac, scanimei, qr, id_orden, fecharegistro, turno, revision) VALUES('' , 'BR0R7TR70E70ES7B970BSESR7E9S0BT707E' , '984dsa4980sda4980ds984dsa894sa8d48sda' , '' , 1 , '7/9/2019 7:58:30 AM' , 'Morning' , 'A'); 
select * from tb_ModeloOrden
select * from tb_Orden
select * from tb_caja
select PiezaCaja from tb_Orden where id_orden = 1


SELECT TOP 1 id_orden From (select Top 2 * from tb_ModeloOrden ORDER BY id_modeloOrden DESC) x ORDER BY id_modeloOrden 
select TOP 1 (id_orden) from tb_ModeloOrden where id_orden = 1 order by id_modeloOrden desc
select id_caja from tb_ModeloOrden where id_orden = 1

select mo.Serialnumber, mo.scanmac, mo.scanimei, mo.qr, moc.SerialNumberCaja, moc.scanmacCaja, moc.scanimeiCaja, moc.qrCaja, o.orden, fecharegistro, c.caja, turno, revision from tb_ModeloOrden mo, tb_Orden o, tb_caja c, tb_ModeloOrdenCaja moc where mo.id_caja = c.id_caja and mo.id_orden = o.id_orden and o.id_orden = moc.id_orden and mo.id_orden = 1


INSERT INTO tb_ModeloOrden (Serialnumber, scanmac, scanimei, qr, id_orden, fecharegistro, turno, revision) VALUES('' , '231da08d4as8d48a4s98' , '' , '48d4as894da89s4d08a94d89a40' , 1 , '7/8/2019 7:49:27 AM' , 'Morning' , 'F'); SELECT SCOPE_IDENTITY();

select Serialnumber, scanmac, scanimei, qr, moc.SerialNumberCaja, moc.scanmacCaja, moc.scanimeiCaja, moc.qrCaja, o.orden, fecharegistro, c.caja, turno, revision from tb_ModeloOrden mo, tb_Orden o, tb_caja c, tb_ModeloOrdenCaja moc where mo.id_caja = c.id_caja and mo.id_orden = o.id_orden and mo.id_orden = moc.id_orden and mo.id_orden = 1

select mo.Serialnumber, mo.scanmac, mo.scanimei, mo.qr, moc.SerialNumberCaja, moc.scanmacCaja, moc.scanimeiCaja, moc.qrCaja, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision from tb_ModeloOrdenCaja moc, tb_ModeloOrden mo, tb_Orden o, tb_caja c, tbUnion_MoCaja u where mo.id_orden = o.id_orden and moc.id_orden = o.id_orden and mo.id_orden = moc.id_orden and mo.id_modeloOrden = u.id_modeloOrden and moc.id_mocaja = u.id_mocaja and c.id_caja = mo.id_caja and o.id_orden = 1


select mo.id_modeloOrden as ID, mo.Serialnumber, mo.scanmac as 'MAC Number', mo.scanimei as 'IMEI Number', mo.qr as QR, moc.SerialNumberCaja as 'Serial Number Caja', moc.scanmacCaja as 'MAC Number Caja', moc.scanimeiCaja as 'IMEI Number Caja', moc.qrCaja as 'QR Caja', o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision from tb_ModeloOrdenCaja moc, tb_ModeloOrden mo, tb_Orden o, tb_caja c, tbUnion_MoCaja u where mo.id_orden = o.id_orden and moc.id_orden = o.id_orden and mo.id_orden = moc.id_orden and mo.id_modeloOrden = u.id_modeloOrden and moc.id_mocaja = u.id_mocaja and c.id_caja = mo.id_caja