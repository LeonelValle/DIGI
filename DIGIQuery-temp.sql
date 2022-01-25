
create table tb_Ensamble(id_ensamble int primary key identity(1,1), ensamble varchar(100))

create table tb_Operador(id_operador int primary key identity(1,1), nombre varchar(100), numeroempleado int)

create table tb_Orden(id_orden int primary key identity(1,1), orden float unique, cantidad int, fechaOrden date, FechaCierre date, id_operador int, id_ensamble int, 
rev varchar(5), consecutivo int, numerocaja int, TotalCajas bit, PiezaCaja int, id_caja int
foreign key(id_operador) references tb_Operador(id_operador),
foreign key(id_ensamble) references tb_ensamble(id_ensamble) on delete cascade on update cascade,
foreign key(id_caja) references tb_Caja(id_caja) on delete cascade on update cascade)

alter table tb_Orden add id_caja int , foreign key(id_caja) references tb_Caja(id_caja)

create table tb_caja(id_caja int primary key identity(1,1), caja varchar(255) unique)

alter table tb_caja add id_orden int

create table tb_ModeloOrden(id_modeloOrden int primary key identity(1,1), Serialnumber varchar(255), scanmac varchar(100), scanimei varchar(255), partnumber varchar(255), id_orden int, checked bit, fecharegistro datetime, id_caja int, Problema varchar(255), turno varchar(20), revision varchar(5)
foreign key(id_orden) references tb_Orden(id_orden) on delete cascade on update cascade,
foreign key(id_caja) references tb_Caja(id_caja) on delete cascade on update cascade)

alter table tb_ModeloOrden add partnumber varchar(255)
alter table tb_ModeloOrdenCaja add partnumberCaja varchar(255)

create table ConfiguracionSistema(id_cs int primary key identity(1,1), consecutivo int, nomenclatura varchar(50), numerocaja int, conexion varchar(100), TotalCajas bit, PiezaCaja int)

create table tb_Historial(id_historial int primary key identity(1,1), Serialnumber varchar(255), scanmac varchar(100), scanimei varchar(255), id_orden int, checked bit, fecharegistro datetime, id_caja int, Problema varchar(255), turno varchar(20), fechaCambio datetime,
foreign key(id_orden) references tb_Orden(id_orden) on delete cascade on update cascade,
foreign key(id_caja) references tb_Caja(id_caja) on delete cascade on update cascade)

create table tb_ModeloOrdenCaja(id_mocaja int primary key identity(1,1), SerialNumberCaja varchar(255), scanmacCaja varchar(255), scanimeiCaja varchar(255),   partnumberCaja varchar(255), id_caja int, id_orden int,
foreign key(id_caja) references tb_Caja(id_caja) on delete cascade on update cascade,
foreign key(id_orden) references tb_Orden(id_orden) on delete cascade on update cascade)

create table tbUnion_MoCaja(id_Umocaja int primary key identity(1,1), id_modeloOrden int, id_mocaja int,
foreign key(id_modeloOrden) references tb_ModeloOrden(id_modeloOrden),
foreign key(id_mocaja) references tb_ModeloOrdenCaja(id_mocaja))


create table tb_SetUp(id_setup int primary key identity(1,1), serialnumber bit, serialnumberCaja bit, mac bit, macCaja bit, imei bit, imeiCaja bit,  id_orden int,
foreign key(id_orden) references tb_Orden(id_orden) on delete cascade on update cascade)

create table tb_Shipping(id_shipping int primary key identity(1,1), salesorder varchar(50), shipping_date datetime,ensamble varchar(255), serialnumber varchar(255), mac varchar(255), imei varchar(255), serialnumberCaja varchar(255), macCaja varchar(255), imeiCaja varchar(255),
 orden float, fecharegistro datetime, caja varchar(255), turno varchar(50), revision varchar(5), numeroempleado int)

alter table tb_SetUp add partnumber bit
alter table tb_SetUp add partnumberCaja bit

create table tb_Duplicates(duplacates int primary key identity(1,1), ensamble varchar(255), Serialnumber varchar(255), scanmac varchar(255), scanimei varchar(255), SerialnumberCaja varchar(255),
scanmacCaja varchar(255), scanimeiCaja varchar(255), Orden float, fecharegistro datetime, caja varchar(50), turno varchar(10), revision varchar(5), numeroempleado int)


/*
GO
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
declare @PiezaCaja as int
--set @Ultima = (SELECT TOP 1 id_orden From (select Top 2 * from tb_ModeloOrden ORDER BY id_modeloOrden DESC) x ORDER BY id_modeloOrden)
set @id_Orden = (select id_orden from inserted)
set @PiezaCaja = (select PiezaCaja from tb_Orden where id_orden = @id_Orden)
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
			insert into tb_caja (caja, NCaja) values(@Nomenclatura + CONVERT(varchar,@caja), @PiezaCaja)		
			set @id_Caja = (SELECT IDENT_CURRENT('tb_caja') as IdentCurrent)
			update tb_ModeloOrden set id_caja = @id_Caja where id_modeloOrden = @id_ModeloOrden
		end
	set @Contador = @Contador + 1
	--update ConfiguracionSistema set numerocaja = @Contador where id_cs = 2
	update tb_Orden set numerocaja = @Contador where id_orden = @id_Orden
END
*/

go
create trigger HistoryChanges on tb_ModeloOrden
after update as begin
insert into tb_Historial select Serialnumber, scanmac, scanimei, id_orden, checked, fecharegistro, id_caja, Problema, turno, GETDATE() from deleted
End

select * from tb_caja where caja = 'MW1909100001' --1344
select * from tb_ModeloOrden where id_caja is not null
exec sp_CrearTablaTest 391
select * from tb_Shipping
select ensamble as Assambly, serialnumber as SerialNumber, mac as MAC_Address, imei as IMEI_Number, serialnumberCaja as Box_SerialNumber, macCaja as Box_MACAddress, imeiCaja as Box_IMEINumber, orden as WorkOrder, fecharegistro as Date_Register, shipping_date = GETDATE() ,caja as BoxID, turno as Shift, revision as Revision, numeroempleado as EMP_IDNUMBER from tb_Shipping
--Store procedure de pruebas para regresar datos de Shipping
go
create procedure sp_CrearTablaTest
@id_caja as int
as begin 

DECLARE @ensamble varchar(255) -- or the appropriate type
Declare @serialnumber varchar(255)
Declare @scanmac varchar(255)
Declare @scanimei varchar(255)
Declare @SerialNumberCaja varchar(255)
Declare @scanmacCaja varchar(255)
Declare @scanimeiCaja varchar(255)
Declare @orden varchar(255)
Declare @fecharegistro datetime
Declare @caja varchar(255)
Declare @turno varchar(255)
Declare @revision varchar(255)
Declare @numeroempleado int


DECLARE the_cursor CURSOR FAST_FORWARD
FOR select distinct e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, moc.SerialNumberCaja, moc.scanmacCaja, moc.scanimeiCaja, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado 
	from tb_ModeloOrden mo left join tb_Orden o on o.id_orden = mo.id_orden left join tb_Ensamble e on e.id_ensamble = o.id_ensamble left join tb_caja c on c.id_caja = mo.id_caja left join tb_Operador op on op.id_operador = o.id_operador left join tb_ModeloOrdenCaja moc on moc.id_caja = c.id_caja and moc.id_orden = o.id_orden inner join tbUnion_MoCaja u on u.id_modeloOrden = mo.id_modeloOrden and u.id_mocaja = moc.id_mocaja 
	where c.id_caja = @id_caja order by c.caja asc

OPEN the_cursor
FETCH NEXT FROM the_cursor INTO @ensamble, @serialnumber, @scanmac, @scanimei, @SerialNumberCaja, @scanmacCaja,@scanimeiCaja, @orden, @fecharegistro, @caja, @turno, @revision,  @numeroempleado

WHILE @@FETCH_STATUS = 0
BEGIN
    
	insert into tb_Shipping(ensamble, serialnumber, mac, imei,serialnumberCaja,macCaja,imeiCaja,orden,fecharegistro,shipping_date,caja,turno,revision,numeroempleado) 
	values(@ensamble, @serialnumber, @scanmac, @scanimei, @SerialNumberCaja, @scanmacCaja,@scanimeiCaja, @orden, @fecharegistro, GETDATE(),@caja, @turno, @revision,  @numeroempleado)

	--update tb_orden set Restantes = (select cantidad - (select COUNT(*) from tb_ModeloOrden where id_orden = @oneid ) as Restante from tb_Orden where id_orden = @oneid) where id_orden = @oneid

    FETCH NEXT FROM the_cursor INTO @ensamble, @serialnumber, @scanmac, @scanimei, @SerialNumberCaja, @scanmacCaja,@scanimeiCaja, @orden, @fecharegistro, @caja, @turno, @revision,  @numeroempleado
end
end

--Store procedure para crear las tabla que va a contener los datos de shipping 
go
create procedure sp_CrearTabla
as begin
SET NOCOUNT ON; 
SET FMTONLY OFF;
create table tb_Shipping(id_shipping int primary key identity(1,1), salesorder varchar(50), shipping_date datetime,ensamble varchar(255), serialnumber varchar(255), mac varchar(255), imei varchar(255), serialnumberCaja varchar(255), macCaja varchar(255), imeiCaja varchar(255), orden float, fecharegistro datetime, caja varchar(255), turno varchar(50), revision varchar(5), numeroempleado int)
end

exec sp_CrearTabla
select * from tb_Shipping

go
create procedure sp_InsertarTabla
@id_caja as int
as begin
insert into tb_Shipping(ensamble, serialnumber, mac, imei,serialnumberCaja,macCaja,imeiCaja,orden,fecharegistro,shipping_date, caja,turno,revision,numeroempleado) select e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, moc.SerialNumberCaja, moc.scanmacCaja, moc.scanimeiCaja, o.orden, mo.fecharegistro,  shipping_date = GETDATE(),c.caja, mo.turno, mo.revision, op.numeroempleado 
from tb_Ensamble e, tb_ModeloOrdenCaja moc, tb_ModeloOrden mo, tb_Orden o, tb_caja c, tbUnion_MoCaja u, tb_Operador op 
where mo.id_orden = o.id_orden and moc.id_orden = o.id_orden and mo.id_orden = moc.id_orden and mo.id_modeloOrden = u.id_modeloOrden and moc.id_mocaja = u.id_mocaja and c.id_caja = mo.id_caja and o.id_operador = op.id_operador and e.id_ensamble = o.id_ensamble and c.id_caja = @id_caja
end

exec sp_InsertarTabla 43

go
create procedure sp_BorrarTabla
as begin
drop table tb_Shipping
end

Exec sp_BorrarTabla

--Manual ver las ordenes activas
go 
create procedure sp_EstatusOrdenes
@id_orden as int
as begin 
update tb_orden set Restantes = (select cantidad - (select COUNT(*) from tb_ModeloOrden where id_orden = @id_orden ) as Restante from tb_Orden where id_orden = @id_orden) where id_orden = @id_orden
end

--Automatico ver las ordenes activas
go 
create procedure sp_EstatusOrdenes
@id_orden as int --Borrar
as begin 
DECLARE @oneid int -- or the appropriate type

DECLARE the_cursor CURSOR FAST_FORWARD
FOR SELECT id_orden FROM tb_Orden

OPEN the_cursor
FETCH NEXT FROM the_cursor INTO @oneid

WHILE @@FETCH_STATUS = 0
BEGIN
    
	update tb_orden set Restantes = (select cantidad - (select COUNT(*) from tb_ModeloOrden where id_orden = @oneid ) as Restante from tb_Orden where id_orden = @oneid) where id_orden = @oneid

    FETCH NEXT FROM the_cursor INTO @oneid
END

CLOSE the_cursor
DEALLOCATE the_cursor
end

select * from tb_Orden where id_orden = @oneid
declare @TotalOrden as int
declare @count as int

set @TotalOrden = (select COUNT(*) from tb_Orden)
while @count <= @TotalOrden
	begin

select orden from tb_Orden

--END DE LOS STORE PROCEDURE 

select * from tb_ModeloOrden where id_orden = 21
select * from tb_ModeloOrdenCaja where id_orden = 19
select * from tbUnion_MoCaja

select * from tb_Orden where id_orden = 21
update tb_orden set Restantes = (select cantidad - (select COUNT(*) from tb_ModeloOrden where id_orden = 21 ) as Restante from tb_Orden where id_orden = 21) where id_orden = 21
select orden, cantidad, Restantes from tb_orden where FechaCierre is null



select TOP 1 id_caja from tb_ModeloOrden where id_orden = 21 order by id_modeloOrden desc
select TOP 1 (id_caja) from tb_ModeloOrden where id_orden = 21

select * from tbUnion_MoCaja
select distinct e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, moc.SerialNumberCaja, moc.scanmacCaja, moc.scanimeiCaja, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_ModeloOrdenCaja moc on o.id_orden = moc.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja and c.id_caja = moc.id_caja join tb_Operador op on op.id_operador = o.id_operador

select distinct mo.id_modeloOrden as ID, moc.id_mocaja as IdCaja, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, moc.SerialNumberCaja, moc.scanmacCaja, moc.scanimeiCaja, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_ModeloOrdenCaja moc on o.id_orden = moc.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja and c.id_caja = moc.id_caja join tb_Operador op on op.id_operador = o.id_operador join tbUnion_MoCaja u on u.id_modeloOrden = mo.id_modeloOrden and u.id_mocaja = moc.id_mocaja order by mo.id_modeloOrden asc

select * from tb_ModeloOrdenCaja
select * from tb_ModeloOrden where id_caja = 253
select * from tb_Orden
select * from tb_caja where id_caja = 253
select * from tb_Ensamble

exec sp_CrearTablaTest 391
select * from tb_Shipping
delete tb_Shipping where caja = 'MW1908270126'
--

select * from tb_ModeloOrden where CONVERT(VARCHAR(255), fecharegistro, 126) like '2019-08-05%' 
select * from tb_ModeloOrden where CONVERT(varchar(255),fecharegistro,126) LIKE '2019-07-30%'
select * from tb_ModeloOrden where id_orden = 17

update tb_SetUp set tipoSim = 0 where id_orden is not null																																																																																																																																																																								--CONVERT(fecharegistro, System.String) LIKE '%7/22/2%' AND (fecharegistro LIKE % '7/22/2 %')																
t mo.id_modeloOrden, moc.id_mocaja as IdCaja, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, moc.SerialNumberCaja, moc.scanmacCaja, moc.scanimeiCaja, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_ModeloOrdenCaja moc on o.id_orden = moc.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja and c.id_caja = moc.id_caja join tb_Operador op on op.id_operador = o.id_operador where o.id_orden = 28 order by mo.id_modeloOrden asc


select * from tb_Orden 


DECLARE the_cursor CURSOR FAST_FORWARD
FOR select moc.id_mocaja, mo.id_caja from tb_ModeloOrden mo, tb_ModeloOrdenCaja moc, tbUnion_MoCaja u where moc.id_orden = 49 and u.id_mocaja = moc.id_mocaja and u.id_modeloOrden = mo.id_modeloOrden
declare @id as int
declare @id_caja as int
OPEN the_cursor
FETCH NEXT FROM the_cursor INTO @id, @id_caja

WHILE @@FETCH_STATUS = 0
BEGIN
    
	update tb_ModeloOrdenCaja set id_caja = @id_caja where id_mocaja = @id

    FETCH NEXT FROM the_cursor INTO @id, @id_caja
end
CLOSE the_cursor
DEALLOCATE the_cursor
end

select * from tb_Orden where orden=	1037738
exec sp_resdb 
exec sp_resdb2 193
go 
alter procedure sp_resdb
--@id_orden as int --Borrar
as begin
declare @id int
declare @id_caja int

DECLARE the_cursor CURSOR FAST_FORWARD
FOR select moc.id_mocaja, mo.id_caja from tb_ModeloOrden mo, tb_ModeloOrdenCaja moc, tbUnion_MoCaja u where moc.id_orden is not null and u.id_mocaja = moc.id_mocaja and u.id_modeloOrden = mo.id_modeloOrden

OPEN the_cursor
FETCH NEXT FROM the_cursor INTO @id, @id_caja

WHILE @@FETCH_STATUS = 0
BEGIN
    
	update tb_ModeloOrdenCaja set id_caja = @id_caja where id_mocaja = @id

    FETCH NEXT FROM the_cursor INTO @id, @id_caja
end
CLOSE the_cursor
DEALLOCATE the_cursor
end

select COUNT(*) from tb_ModeloOrden where id_orden is not null
INSERT INTO tb_ModeloOrden (Serialnumber, scanmac, scanimei, qr,id_orden, fecharegistro, turno, revision, partnumber, ICCID, id_caja) VALUES('ASDASD' , 'N/A' , 'N/A' , 'N/A' , 103 , '10/1/2019 9:21:44 AM' , '1er' , 'F' , '0' , 'N/A' , 0); SELECT SCOPE_IDENTITY();

select * from tb_caja
select * from tb_ModeloOrden where id_caja is null
select * from tb_ModeloOrden where id_modeloOrden = 35890

select * from tb_ModeloOrden where id_modeloOrden = 96

select top 1 o.id_orden, o.orden from tb_Orden o, tb_ModeloOrden mo where mo.id_caja = 391

select distinct mo.id_modeloOrden, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, moc.SerialNumberCaja, moc.scanmacCaja, moc.scanimeiCaja, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo left join tb_Orden o on o.id_orden = mo.id_orden left join tb_Ensamble e on e.id_ensamble = o.id_ensamble left join tb_caja c on c.id_caja = mo.id_caja left join tb_Operador op on op.id_operador = o.id_operador left join tb_ModeloOrdenCaja moc on moc.id_caja = c.id_caja and moc.id_orden = o.id_orden join tbUnion_MoCaja u on u.id_modeloOrden = mo.id_modeloOrden and u.id_mocaja = moc.id_mocaja where o.id_orden = 230 order by mo.id_modeloOrden asc

select TOP 1 id_caja from tb_ModeloOrden where id_orden = 231 order by id_modeloOrden desc

select * from tb_Orden
select * from tb_ModeloOrden where id_orden = 231
select * from tb_ModeloOrdenCaja where id_orden = 231
delete tbUnion_MoCaja where id_mocaja = 256411
delete tbUnion_MoCaja where id_mocaja = 256406
delete tbUnion_MoCaja where id_mocaja = 256407
delete tbUnion_MoCaja where id_mocaja = 256408
delete tbUnion_MoCaja where id_mocaja = 256409

select * from tbUnion_MoCaja where id_mocaja = 256409
select * from tbUnion_MoCaja where id_modeloOrden = 256416
select * from tb_ModeloOrdenCaja where id_mocaja = 256409

go
declare @id_orden int
declare @id_caja int
declare @id_modeloOrden int
declare @id_mo int

DECLARE the_cursor CURSOR FAST_FORWARD
FOR select id_modeloOrden, id_orden, id_caja from tb_ModeloOrden where id_orden = 231

OPEN the_cursor
FETCH NEXT FROM the_cursor INTO @id_modeloOrden, @id_orden, @id_caja

WHILE @@FETCH_STATUS = 0
BEGIN
    
	insert into tb_ModeloOrdenCaja(SerialNumberCaja,scanimeiCaja,scanmacCaja,qrCaja,ICCIDCaja,partnumberCaja,id_orden, id_caja) values('N/A','N/A','N/A','N/A','N/A','N/A',@id_orden,@id_caja)
	select @id_mo =  SCOPE_IDENTITY();
	
	insert into tbUnion_MoCaja values(@id_modeloOrden,@id_mo)
    FETCH NEXT FROM the_cursor INTO @id_modeloOrden, @id_orden, @id_caja
end
CLOSE the_cursor
DEALLOCATE the_cursor


select * from tb_ModeloOrden where id_orden is not null
select * from tb_caja

select distinct e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, mo.SerialNumberCaja, mo.scanmacCaja, mo.scanimeiCaja, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado 
	from tb_ModeloOrden mo left join tb_Orden o on o.id_orden = mo.id_orden left join tb_Ensamble e on e.id_ensamble = o.id_ensamble left join tb_caja c on c.id_caja = mo.id_caja left join tb_Operador op on op.id_operador = o.id_operador
	where c.id_caja = 2829 order by c.caja asc


select * from tb_Duplicates
select * from tb_Orden
select ensamble from tb_Ensamble e, tb_Orden o where o.id_orden = 231 and o.id_ensamble = e.id_ensamble
--insert into tb_Duplicates(Serialnumber,scanmac,scanimei,SerialnumberCaja,scanmacCaja,scanimeiCaja,orden,fecharegistro,turno,revision,ensamble,caja,numeroempleado) VALUES('N5' , 'N/A' , 'N/A' , 'N/A' , 'N/A' , 'N/A' , 231 , '10/18/2019 8:18:58 AM' , '1er' , 'F' , 'N/A' , 2829');



select ensamble, Serialnumber, scanmac, scanimei, SerialnumberCaja, scanmacCaja, scanimeiCaja, o.orden, fecharegistro, c.caja, turno, revision, numeroempleado from tb_Duplicates d join tb_Orden o on d.Orden = o.id_orden join tb_caja c on d.caja = c.id_caja where o.id_orden = 231
select Serialnumber, scanmac, scanimei, SerialnumberCaja, scanmacCaja, scanimeiCaja, o.orden, fecharegistro, c.caja, turno, revision, numeroempleado from tb_Duplicates d join tb_Orden o on d.Orden = o.id_orden join tb_caja c on d.caja = c.id_caja where c.id_caja = 231
select Serialnumber, scanmac, scanimei, SerialnumberCaja, scanmacCaja, scanimeiCaja, o.orden, fecharegistro, c.caja, turno, revision, numeroempleado from tb_Duplicates d join tb_Orden o on d.Orden = o.id_orden join tb_caja c on d.caja = c.id_caja where o.id_orden = 1 order by id_duplacates asc