CREATE TABLE [dbo].[Address]
(
    [AddressId] INT NOT NULL , 
    [Address] NVARCHAR(50) NOT NULL, 
    [City] NVARCHAR(50) NOT NULL, 
    [District] NVARCHAR(50) NULL, 
    [PostalCode] NVARCHAR(15) NOT NULL, 
    [Country] CHAR(3) NOT NULL, 
    CONSTRAINT [PK_Address] PRIMARY KEY ([AddressId]) 
)
