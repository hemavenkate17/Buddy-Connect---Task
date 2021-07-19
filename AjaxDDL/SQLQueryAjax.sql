create database DropdownAjax
go

use DropdownAjax

create table tbl_Country
(
CountryID int identity(1,1),
Name varchar(20),
Constraint Pk_CID Primary key (CountryID)
)

insert tbl_Country Values ('India')
insert tbl_Country Values ('USA')
insert tbl_Country Values ('France')

select * from tbl_Country

create table tbl_State
(
StateID int identity(1,1),
Name varchar(20),
CId int,
Constraint Pk_SID Primary key (CountryID)
)


insert tbl_State values ('TamilNadu',1)
insert tbl_State values ('Andra Pradesh',1)
insert tbl_State values ('Delhi',1)
insert tbl_State values ('California',2)
insert tbl_State values ('New York',2)
insert tbl_State values ('Iowa',2)
insert tbl_State values ('Ile-de-France',3)
insert tbl_State values ('Midi-Pyrenees',3)
insert tbl_State values ('Alsace',3)

select * from tbl_State


create table tbl_District
(
DistrictID int identity(100,1),
Name varchar(20),
CId int,
SId int,
Constraint Pk_DID Primary key (DistrictID)
)

insert tbl_District values('Chennai',1,1)
insert tbl_District values('Coimbatore',1,1)
insert tbl_District values('Chittoor',1,2)
insert tbl_District values('Guntur',1,2)
insert tbl_District values('New Delhi',1,3)
insert tbl_District values('Shahdara',1,3)
insert tbl_District values('Doug LaMalfa',2,4)
insert tbl_District values('Jared Huffman',2,4)
insert tbl_District values('Jared Huffman',2,5)
insert tbl_District values('Queens',2,5)
insert tbl_District values('Albert City',2,6)
insert tbl_District values('Calamus',2,6)
insert tbl_District values('Paris',3,7)
insert tbl_District values('Montreuil',3,7)
insert tbl_District values('Balma',3,8)
insert tbl_District values('Albi',3,8)
insert tbl_District values('Ostwald',3,9)
insert tbl_District values('Mulhouse',3,9)

select * from tbl_District