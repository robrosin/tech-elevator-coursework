-- Switch to the system (aka master) database
USE master;
GO

-- Delete the TaskDB Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='TaskDB')
DROP DATABASE TaskDB;
GO

-- Create a new TaskDB Database
CREATE DATABASE TaskDB;
GO

-- Switch to the World Database
USE TaskDB
GO

-- Creat the Roster table
Create Table Task (
	TaskId int not null primary key identity,
	TaskName varchar(100) not null,
	DueDate date not null,
    Completed bit not null default 0
)
