use master
go

drop database if exists ProjectOrganizer

create database ProjectOrganizer

use ProjectOrganizer
go

create table Employee(
EmployeeID int primary key identity,
FirstName nvarchar(100) not null,
LastName nvarchar(100) not null,
Gender varchar(10) not null,
DateOfBirth date not null default getdate(),
DateOfHire date not null default getdate(),
DepartmentID int not null,
)

create table Department(
DepartmentID int primary key identity,
DepartmentName nvarchar(100) not null,
NumberOfEmployees int not null,
EmployeeID int not null,
constraint fk_department_employee foreign key (EmployeeID) references Employee(EmployeeID),
)

create table Project(
ProjectID int primary key identity,
ProjectName nvarchar(100) not null,
StartDate date not null,
NumberOfEmployees int not null,
EmployeeID int not null,
constraint fk_project_employee foreign key (EmployeeID) references Employee(EmployeeID),
)

--create table DepartmentProject(
--DepartmentID int not null,
--ProjectID int not null,
--primary key (DepartmentID, ProjectID),
--constraint fk_project_department foreign key (DepartmentID) references Department(DepartmentID),
--constraint fk_department_project foreign key (ProjectID) references Project(ProjectID)
--)

insert into Employee ([EmployeeID], FirstName, LastName, Gender, DateOfBirth, DateOfHire)
values 
('Angel1', 'Adam', 'M', '1984-05-22', '2019-01-08'),
('Angel2', 'Lilith', 'F', '1984-11-23', '2012-03-15'),
('Angel3', 'Sachiel', 'M', '1990-01-22', '2020-02-14'),
('Angel4', 'Shamshel', 'F', '2020-09-22', '2020-09-23'),
('Angel5', 'Ramiel', 'M', '2001-09-12', '2010-08-31'),
('Angel6', 'Gaghiel', 'F', '1654-01-01', '1846-09-12'),
('Angel7', 'Israfel', 'M', '1991/07/04', '1999/10/18'),
('Angel8', 'Sandalphon', 'F', '1984/11/19', '2019/08/16')

insert into Department ([DepartmentID], DepartmentName, NumberOfEmployees)
values ('Maji-1 Melchior', 5),
('Maji-2 Balthazar', 7),
('Maji-3 Casper', 4)

insert into Project ([ProjectID], ProjectName, StartDate, NumberOfEmployees)
values ('Shinji_Ikari', '1952-08-16', 9),
('Misato_Katsurugi', '1952-06-17', 2),
('Rei_Ayanami', '1052-01-01', 4),
('Asuka_Langley_Soryu', '1966-12-12', 3)

select * from Project where NumberOfEmployees = 9