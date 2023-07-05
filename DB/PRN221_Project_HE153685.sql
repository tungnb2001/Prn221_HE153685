
USE [master]
GO

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'PRN221_Project_HE153685')
BEGIN
	ALTER DATABASE [PRN221_Project_HE153685] SET OFFLINE WITH ROLLBACK IMMEDIATE;
	ALTER DATABASE [PRN221_Project_HE153685] SET ONLINE;
	DROP DATABASE [PRN221_Project_HE153685];
END
GO
CREATE DATABASE [PRN221_Project_HE153685]
GO
USE [PRN221_Project_HE153685]
GO
DECLARE @sql nvarchar(MAX) 
SET @sql = N'' 

SELECT @sql = @sql + N'ALTER TABLE ' + QUOTENAME(KCU1.TABLE_SCHEMA) 
    + N'.' + QUOTENAME(KCU1.TABLE_NAME) 
    + N' DROP CONSTRAINT ' -- + QUOTENAME(rc.CONSTRAINT_SCHEMA)  + N'.'  -- not in MS-SQL
    + QUOTENAME(rc.CONSTRAINT_NAME) + N'; ' + CHAR(13) + CHAR(15) 
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS AS RC 

INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KCU1 
    ON KCU1.CONSTRAINT_CATALOG = RC.CONSTRAINT_CATALOG  
    AND KCU1.CONSTRAINT_SCHEMA = RC.CONSTRAINT_SCHEMA 
    AND KCU1.CONSTRAINT_NAME = RC.CONSTRAINT_NAME 

EXECUTE(@sql) 

GO
DECLARE @sql2 NVARCHAR(max)=''

SELECT @sql2 += ' Drop table ' + QUOTENAME(TABLE_SCHEMA) + '.'+ QUOTENAME(TABLE_NAME) + '; '
FROM   INFORMATION_SCHEMA.TABLES
WHERE  TABLE_TYPE = 'BASE TABLE'

Exec Sp_executesql @sql2 



CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UserName] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL
)

CREATE TABLE [dbo].[Employees](
    [EmployeeId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [FullName] [nvarchar](max) NOT NULL,
	[CardId] [nvarchar](max) NOT NULL,
    [Gender] [nvarchar](max) NOT NULL,
    [Address] [nvarchar](max) NULL,
    [Role] [nvarchar](max) NULL,
    [Phone] [nvarchar](max) NULL,
    [Email] [nvarchar](max) NOT NULL
	
)

CREATE TABLE [dbo].[Suppliers] (
    [SupplierID] INT IDENTITY(1,1) PRIMARY KEY,
    [SupplierName] VARCHAR(255),
    [ContactName] VARCHAR(255),
    [Phone] VARCHAR(20),
    [Email] VARCHAR(255),
    [Address] VARCHAR(255)
)
CREATE TABLE [dbo].[Warehouse](
    [WarehouseId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] [nvarchar](100) NOT NULL,
    [Location] [nvarchar](100) NOT NULL
)


CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[SupplierID] [int] NOT NULL,
	[Title] [nvarchar](160) NOT NULL,
	[Price] [numeric](10, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	FOREIGN KEY ([SupplierID]) REFERENCES [dbo].[Suppliers](SupplierID)
)
CREATE TABLE [dbo].[PurchaseOrders] (
    [OrderID] INT IDENTITY(1,1) PRIMARY KEY,
    [SupplierID] INT,
    [OrderDate] DATE,
    [TotalAmount] DECIMAL(10, 2),
	[Quantity] [int] NOT NULL,
	 [BookId] INT NOT NULL,
    FOREIGN KEY ([SupplierID]) REFERENCES  [dbo].[Suppliers](SupplierID),
	FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books]([BookId])
)

CREATE TABLE [dbo].[InventoryTransactions](
    [TransactionId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [BookId] [int] NOT NULL,
    [WarehouseId] [int] NOT NULL,
    [Quantity] [int] NOT NULL,
    [TransactionType] [nvarchar](50) NOT NULL,
    [TransactionDate] [datetime] NOT NULL,
    CONSTRAINT [FK_InventoryTransactions_Books] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books]([BookId]),
    CONSTRAINT [FK_InventoryTransactions_Warehouse] FOREIGN KEY ([WarehouseId]) REFERENCES [dbo].[Warehouse]([WarehouseId])
)


CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[EmployeeId] [int] NOT NULL,
	[BookId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [numeric](10, 2) NOT NULL,
	FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employees]([EmployeeId]),
	FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books]([BookId])
)

INSERT INTO Employees (FullName, CardId, Gender, Address, Role, Phone, Email)
VALUES 
    ('John Doe', '1234567890', 'Male', '123 Main St, City', 'Manager', '123-456-7890', 'john.doe@example.com'),
    ('Jane Smith', '0987654321', 'Female', '456 Elm St, City', 'Supervisor', '987-654-3210', 'jane.smith@example.com'),
    ('Michael Johnson', '5678901234', 'Male', '789 Oak St, City', 'Employee', '567-890-1234', 'michael.johnson@example.com'),
    ('Emily Davis', '4321098765', 'Female', '321 Pine St, City', 'Employee', '432-109-8765', 'emily.davis@example.com'),
    ('David Wilson', '9876543210', 'Male', '654 Cedar St, City', 'Employee', '987-654-3210', 'david.wilson@example.com');

	INSERT INTO [dbo].[Suppliers] ([SupplierName], [ContactName], [Phone], [Email], [Address])
VALUES
('NC1', 'Người liên hệ 1', '1234567890', 'email1@example.com', 'DC1'),
('NC2', 'Người liên hệ 2', '0987654321', 'email2@example.com', 'DC2'),
('NC3', 'Người liên hệ 3', '1112223333', 'email3@example.com', 'DC3'),
('NC4', 'Người liên hệ 4', '4445556666', 'email4@example.com', 'DC4'),
('NC5', 'Người liên hệ 5', '7778889999', 'email5@example.com', 'DC5');


	INSERT INTO [dbo].[Users] ([UserName],[Password] )
VALUES
('admin' , 'admin')