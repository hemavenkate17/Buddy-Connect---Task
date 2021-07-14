Create Database Inventory
go 

use Inventory

create table tbl_Product
(
ProductID int identity(1,1),
Name varchar(20),
Description varchar(100),
Price money,
DiscountPercentage float,
Constraint Pk_Prod Primary key (ProductID)
)

update tbl_Product set Description ='Model : iphone 12 pro max, Brand : Apple, Processor: Apple A14 Bionic' where ProductID=1

insert into tbl_Product values('IPhone','Model : iphone 12 pro max, Brand : Apple, Processor: Apple A14 Bionic',500000,8.5)
insert into tbl_Product values('Oppo','Model : Oppo A54 , 4 GB Ram, Display :16.5 inch',20000,2.3)
insert into tbl_Product values('Poco','Model : Poco M3, 64 GB 4 GB Ram, Corning Gorilla Glass',11500,3)



select * from tbl_Product

create table tbl_Customer
(
CustomerID int identity(100,1),
Name varchar(20),
Address varchar(50),
ContactNo varchar(10),
Constraint Pk_Cust Primary key (CustomerID)
)

insert into tbl_Customer values('Hema','No 6 Rajiv Gandhi street, chennai-119','9940239001')
insert into tbl_Customer values('Deepak','No 4 Valmiki street, chennai-089','9876542145')
insert into tbl_Customer values('Vinoba','No 2 Anna Nagar street, chennai-109','9999956781')



select * from tbl_Customer

create table tbl_PurchaseOrder
(
POID int identity(1,1),
CustomerId int,
Date Date,
Amount float,
constraint PK_poid Primary key (POID),
constraint Fk_Cust Foreign key (CustomerId)
references tbl_Customer (CustomerID)
)

insert into tbl_PurchaseOrder values(100,'2021-07-08',80000.00)
insert into tbl_PurchaseOrder values(101,'2021-08-11',20000.00)
insert into tbl_PurchaseOrder values(102,'2021-09-12',11500.00)


select * from tbl_PurchaseOrder

create table tbl_PurchaseOrderDetail
(
PODID int identity(1000,1),
POID int,
ProductID int,
Price money,
Qty int,
constraint PK_podid Primary key (PODID),
constraint Fk_POID Foreign key (POID)
references tbl_PurchaseOrder(POID),
constraint Fk_ProductID Foreign key (ProductID)
references tbl_Product (ProductID),
)

insert into tbl_PurchaseOrderDetail values (4,1,500000,1)
insert into tbl_PurchaseOrderDetail values (5,2,20000,2)
insert into tbl_PurchaseOrderDetail values (6,3,11500,2)


select * from tbl_PurchaseOrderDetail