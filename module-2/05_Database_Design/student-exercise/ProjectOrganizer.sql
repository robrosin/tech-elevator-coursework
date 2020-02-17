use master
go

drop database if exists ProjectOrganizer

create database ProjectOrganizer

use ProjectOrganizer
go

create table Project(
ProjectID int primary key identity,
ProjectName nvarchar(100) not null,
StartDate date not null
)

create table Department(
DepartmentID int primary key identity,
DepartmentName nvarchar(100) not null
)

create table Employee(
EmployeeID int primary key identity,
FirstName nvarchar(100) not null,
LastName nvarchar(100) not null,
Gender varchar(10) not null,
DateOfBirth date not null default getdate(),
DateOfHire date not null default getdate(),
DepartmentID int not null,
constraint fk_employee_department foreign key (DepartmentID) references Department(DepartmentID)
)

create table EmployeeProject(
EmployeeID int,
ProjectID int,
constraint pk_employee_project primary key (EmployeeID, ProjectID),
constraint fk_employee foreign key (EmployeeID) references Employee(EmployeeID),
constraint fk_project foreign key (ProjectID) references Project(ProjectID)
)

insert into Employee (FirstName, LastName, Gender, DateOfBirth, DateOfHire, DepartmentID)
values 
('Angel1', 'Adam', 'M', '1984-05-22', '2019-01-08', 1),
('Angel2', 'Lilith', 'F', '1984-11-23', '2012-03-15', 2),
('Angel3', 'Sachiel', 'M', '1990-01-22', '2020-02-14', 3),
('Angel4', 'Shamshel', 'F', '2020-09-22', '2020-09-23', 1),
('Angel5', 'Ramiel', 'M', '2001-09-12', '2010-08-31', 2),
('Angel6', 'Gaghiel', 'F', '1654-01-01', '1846-09-12', 3),
('Angel7', 'Israfel', 'M', '1991/07/04', '1999/10/18', 1),
('Angel8', 'Sandalphon', 'F', '1984/11/19', '2019/08/16', 2)

insert into Department (DepartmentName)
values ('Maji-1 Melchior'),
('Maji-2 Balthazar'),
('Maji-3 Casper')

insert into Project (ProjectName, StartDate)
values ('Shinji_Ikari', '1952-08-16'),
('Misato_Katsurugi', '1952-06-17'),
('Rei_Ayanami', '1052-01-01'),
('Asuka_Langley_Soryu', '1966-12-12')

select * from EmployeeProject

insert into EmployeeProject (EmployeeID, ProjectID)
values (1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 1),
(6, 2),
(7, 3),
(8, 4)