use master
go

-- Delete the db it already exists
drop database if exists ArtGallery

-- Create a new database
create database ArtGallery

-- Change to the new database
use ArtGallery
go

-- Create the Address table

create table Address (
	AddressId int primary key identity,
	Address nvarchar(100) not null,
	City nvarchar(50) not null,
	District nvarchar(50) null,
	Postalcode nvarchar(10) null,
	Country char(3) not null,
	)

create table Customer (
	CustomerId int primary key identity,
	Name varchar(50) not null,
	Phone varchar(15) not null,
	AddressId int not null,
	constraint fk_customer_address foreign key (AddressId) references Address(AddressId)
	)

create table Artist (
	ArtistId int primary key identity,
	Name varchar(50),
	AddressId int null,
	constraint fk_artist_address foreign key (AddressId) references Address(AddressId),
	)

	create table Painting (
	PaintingId int primary key identity,
	Title varchar(100)not null,
	ArtistId int not null,
	IsAvailable bit not null default 0, 
	constraint fk_painting_artist foreign key (ArtistId) references Artist(ArtistId)
	)

	create table Trans (
	TransactionId int primary key identity,
	PaintingId int not null,
	CustomerId int not null,
	TransactionDate datetime not null default getdate(),
	TransactionPrice money not null,
	IsCustomerPurchase bit not null default 1,
	constraint fk_trans_painting foreign key (PaintingId) references Painting(PaintingId),
	constraint fk_trans_customer foreign key (CustomerId) references Customer(CustomerId),
	)






	