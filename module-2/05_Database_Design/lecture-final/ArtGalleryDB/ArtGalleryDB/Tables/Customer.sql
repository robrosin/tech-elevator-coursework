CREATE TABLE [dbo].[Customer]
(
    [CustomerId] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Phone] NVARCHAR(20) NOT NULL, 
    [AddressId] INT NOT NULL, 
    CONSTRAINT [FK_Customer_Address] FOREIGN KEY (AddressId) REFERENCES Address(AddressId)
)

