
-- Switch to the system (aka master) database
USE master;
GO

-- Delete the puppiesDB Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='puppiesDB')
DROP DATABASE puppiesDB;
GO

-- Create a new puppiesDB Database
CREATE DATABASE puppiesDB;
GO

-- Switch to the puppiesDB Database
USE puppiesDB
GO

BEGIN TRANSACTION;

create table puppy (
	id int IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(50),
	weight INT,
	gender VARCHAR(50),
	paper_trained BIT
);
SET IDENTITY_INSERT puppy ON;
insert into puppy (id, name, weight, gender, paper_trained) values (1, 'Fido', 8, 'Female', 0);
insert into puppy (id, name, weight, gender, paper_trained) values (2, 'Blaze', 15, 'Male', 1);
insert into puppy (id, name, weight, gender, paper_trained) values (3, 'Ozzie', 10, 'Male', 1);
insert into puppy (id, name, weight, gender, paper_trained) values (4, 'Spot', 9, 'Female', 1);
insert into puppy (id, name, weight, gender, paper_trained) values (5, 'Eric', 14, 'Male', 0);
SET IDENTITY_INSERT puppy OFF;

COMMIT TRANSACTION;