DROP DATABASE IF EXISTS InvoicingZL

CREATE DATABASE InvoicingZL

USE InvoicingZL

DROP TABLE IF EXISTS [dbo].[Item]
CREATE TABLE [dbo].[Item] (
    [Id]    INT           NOT NULL,
    [Name]  NVARCHAR (50) NOT NULL,
	[Description]  NVARCHAR (50) NOT NULL,
    [Price] DECIMAL (12)  NOT NULL,
    [Qty]   INT           NULL,
    CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED ([Id] ASC)
);

DROP TABLE IF EXISTS [dbo].[Customer]
CREATE TABLE [dbo].[Customer] (
    [Id]       INT           NOT NULL,
    [Name]     NVARCHAR (50) NOT NULL,
    [Address]  NVARCHAR (50) NOT NULL,
    [IsMember] BIT           NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([Id] ASC)
);

DROP TABLE IF EXISTS [dbo].[Invoice]
CREATE TABLE [dbo].[Invoice] (
    [Id]         INT      NOT NULL,
    [CustomerId] INT      NOT NULL,
    [ItemId]  INT      NOT NULL,
    [SaleDate]   DATETIME   NULL,
    [Amount]  DECIMAL (12)  NOT NULL,    
    CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Invoice_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id])
);

USE [InvoicingZL]
GO

INSERT INTO [dbo].[Customer]
           ([Id]
           ,[Name]
           ,[Address]
           ,[IsMember])
     VALUES
           (1,'RONA','Montreal','true'),
		   (2,'Home Deport','Saint-Laurent','true'),
		   (3,'Walmart','Kirkland','false'),
		   (4,'Costco','Point Claire','true'),
		   (5,'BMR','Saint-Constant','false')

GO

INSERT INTO [dbo].[Item]
           ([Id]
           ,[Name]
           ,[Description]
           ,[Price]
           ,[Qty])
     VALUES
           (10001,'Light1','30W',9.99,1),
		   (10002,'Light2','40W',19.99,1),
		   (10003,'Light3','50W',29.99,1),
		   (10004,'Light4','60W',39.99,1),
		   (10005,'Light5','70W',49.99,1)
GO

INSERT INTO [dbo].[Invoice]
           ([Id]
           ,[CustomerId]
           ,[ItemId]
           ,[SaleDate]
           ,[Amount])
     VALUES
           (1001,2,10001,2019-11-18,100.99),
		   (1002,1,10004,2019-11-18,80.99),
		   (1003,5,10004,2019-11-18,100.99),
		   (1004,3,10005,2019-11-18,100.99),
		   (1005,4,10003,2019-11-18,100.99)
GO

ALTER TABLE [dbo].[Item]
ADD [InvoiceId] INT   NULL;

ALTER TABLE [dbo].[Item]
ADD CONSTRAINT [FK_Item_Invoice]
FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoice] ([Id]);

ALTER TABLE [dbo].[Item]
ALTER COLUMN [Price] DECIMAL(10,2);

ALTER TABLE [dbo].[Invoice] 
ALTER COLUMN [Amount] DECIMAL(10,2);

ALTER TABLE [dbo].[Invoice] 
DROP CONSTRAINT [FK_Invoice_Item];
ALTER TABLE [dbo].[Item] 
DROP CONSTRAINT [FK_Item_Invoice];

ALTER TABLE [dbo].[Invoice] 
DROP COLUMN [ItemId];
ALTER TABLE [dbo].[Item] 
DROP COLUMN [InvoiceId];

DROP TABLE IF EXISTS [dbo].[Invoice_Item]
CREATE TABLE [dbo].[Invoice_Item] (
    [InvoiceId]      INT      NOT NULL,
    [ItemId]         INT      NOT NULL   
    CONSTRAINT [FK_Invoice_Item] FOREIGN KEY ([InvoiceId] ) REFERENCES [dbo].[Invoice] ([Id]),
	CONSTRAINT [FK_Item_Invoice] FOREIGN KEY ([ItemId] ) REFERENCES [dbo].[Item] ([Id])
);



