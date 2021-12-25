create database Quananvat
go
use quananvat
go
--food
--table
--foodcategory
--account
--bill
--billinfo

create table tablefood
(
	id int identity primary key,
	name nvarchar(50) not null default N'Bàn Chưa Có Tên',
	status nvarchar (50) not null default N'Trống' --trống hoặc có người
)
go

create table account
(
	displayname nvarchar(50) not null default N'MinhQuang',
	username nvarchar(50) primary key,
	password nvarchar(50) not null default 0,
	type int not null default 0 -- 1:admin, 0:staff
)
go

create table foodcategory
(
	id int identity primary key,
	name nvarchar(50) not null default N'Chưa Đặt Tên'
)
go

create table food
(
	id int identity primary key,
	name nvarchar(50) not null default N'Chưa Đặt Tên',
	idcategory int not null,
	price float not null default 0
	foreign key (idcategory) references	dbo.foodcategory(id)
)
go

create table bill
(
	id int identity primary key,
	datecheckin date not null default getdate(),
	datecheckout date,
	idtable int not null,
	status int not null default 0, -- 1: đã thanh toán, 0: chưa thanh toán
	discount int default 0,
	totalPrice float
	foreign key (idtable) references dbo.tablefood(id)
)
go

create table billinfo
(
	id int identity primary key,
	idbill int not null,
	idfood int not null,
	count int not null default 0
	foreign key (idbill) references	dbo.bill(id),
	foreign key (idfood) references	dbo.food(id)
)
go

insert into account
values ('staff','sen','1','0'),
('Quang','NguyenMinhQuang','1','1')
		
go



insert into tablefood (name)
values ('Bàn 1'),
('Bàn 2'),
('Bàn 3'),
('Bàn 4'),
('Bàn 5'),
('Bàn 6'),
('Bàn 7'),
('Bàn 8'),
('Bàn 9'),
('Bàn 10'),
('Bàn 11'),
('Bàn 12'),
('Bàn 13'),
('Bàn 14'),
('Bàn 15'),
('Bàn 16'),
('Bàn 17'),
('Bàn 18'),
('Bàn 19'),
('Bàn 20')
go
insert into foodcategory(name)
values ('Hải sản'),
('Nông sản'),
('Nước')

go
insert into food(name,idcategory,price)
values ('Mực một nắng nướng sa tế', '1','120000'),
('Nghêu hấp xả', '1','50000'),
('nấm xào thịt bò', '2','150000'),
('nấm rừng nướng', '2','160000'),
('Coca 1.5l', '3','16000'),
('pepsi 1.5l', '3','16000')

go
insert into bill(datecheckin,datecheckout,idtable,status)
values ('', '','1','0','0'),
('', '','2','1','0'),
('12/24/2020', '12/24/2020','2','1','0')

go
insert into billinfo(idbill,idfood,count)
values ('3', '1','2'),
('4', '3','4'),
('2', '1','3')

go
create proc usp_login
@username nvarchar (50), @password nvarchar (50)
as
begin
	select * from dbo.account where Username = @username and Password = @password
end

go
create proc usp_gettablelist
as select * from dbo.tablefood

go
create proc usp_insertbill
@idtable int
as
begin
	insert into dbo.bill
	values (getdate(),null,@idtable,0,0,0)
end
go


create proc usp_insertbillinfo
@idbill int, @idfood int, @count int
as
begin
	declare @isExitsBillinfo int
	declare @foodCount int = 1 
	
	select @isExitsBillinfo = id, @foodCount = b.count
	from dbo.billinfo as b
	where idbill = @idbill and idfood = @idfood
	if(@isExitsBillinfo > 0)
		begin
			declare @newCount int = @foodCount + @count
			if(@newCount > 0)
				update dbo.billinfo set count = @foodCount +@count where idfood = @idfood
			else
				delete dbo.billinfo where idbill =@idbill and idfood =@idfood
		end
	else
	begin
		insert into dbo.billinfo
		values (@idbill,@idfood,@count)
	end
end

go

create trigger utg_updatebillinfo
on dbo.billinfo for insert, update
as
begin
	declare @idbill int
	select @idbill = idbill from inserted

	declare @idtable int
	select @idtable = idtable from dbo.bill where id = @idbill and status = 0

	update dbo.tablefood set status =N'Có Người' where id = @idtable
end
go

create trigger utg_updatebill
on dbo.bill for update
as
begin
	declare @idbill int 
	select @idbill = id from inserted

	declare @idtable int
	select @idtable = idtable from dbo.bill where id = @idbill

	declare @count int = 0
	select @count = COUNT(*) from dbo.bill where idtable = @idtable and status = 0

	if(@count = 0)
		update tablefood set status = N'Trống' where id = @idtable


end
go


create proc usp_getlistbydate
@checkin date, @checkout date
as
begin
	select t.name as [Tên Bàn], totalPrice as [Tổng Tiền], datecheckin as [Ngày Vào], datecheckout as [Ngày Ra], discount as [Giảm Giá]
	from dbo.bill as b, dbo.tablefood as t
	where datecheckin >= @checkin and datecheckout <= @checkout and b.status = 1
	and t.id = b.idtable

end


go
create proc usp_updateaccount
@username nvarchar(50), @displayname nvarchar(50), @password nvarchar(50), @newpassword nvarchar(50)
as
begin
	declare @isrightpass int = 0

	select @isrightpass = count(*) from dbo.account where username = @username and password = @password

	if(@isrightpass = 1)
	begin
		if(@newpassword = null or @newpassword = '')
		begin
			update dbo.account set displayname = @displayname where username = @username
		end
		else
			update dbo.account set displayname = @displayname, password = @newpassword where username = @username
	end
end
go

create trigger utg_deletebillinfo
on dbo.billinfo for delete
as
begin
	declare @idbillinfo int 
	declare @idbill int
	select @idbillinfo = id, @idbill = deleted.idbill from deleted

	declare @idtable int
	select @idtable = idtable from dbo.bill where id = @idbill

	declare @count int = 0
	select @count = count(*) from dbo.billinfo as bi, dbo.bill as b where b.id = bi.idbill and status = 0 

	if(@count = 0)
		update dbo.tablefood set status = N'Trống' where id = @idtable
end
go
select * from account
insert into account(username, displayname, type)
values ('staff','sen','1'),
('Quang','NguyenMinhQuang','1')

select * from foodcategory
insert into foodcategory
values ('Mực nướng')	

update dbo.foodcategory set name = 'muc nuong' where id = 10

delete billinfo
delete bill
delete foodcategory

delete billinfo where idfood = 22
delete food where idcategory = 15
delete foodcategory where id = 14
