
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/27/2023 23:28:58
-- Generated from EDMX file: C:\Users\LENOVO\OneDrive\Máy tính\CNPM\SupplementFactsSoftwares\OrderItemsWeb\Models\SupplementFactsDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MobilePhone];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FkIncludeImportedProducts_ProductID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IncludeImportedProducts] DROP CONSTRAINT [FK_FkIncludeImportedProducts_ProductID];
GO
IF OBJECT_ID(N'[dbo].[FK_FkIncludeImportedProducts_ReceiptID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IncludeImportedProducts] DROP CONSTRAINT [FK_FkIncludeImportedProducts_ReceiptID];
GO
IF OBJECT_ID(N'[dbo].[FK_FkOrderReceipt_AgentID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderReceipts] DROP CONSTRAINT [FK_FkOrderReceipt_AgentID];
GO
IF OBJECT_ID(N'[dbo].[FK_FkIncludeOrderProducts_OrderID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IncludeOrderProducts] DROP CONSTRAINT [FK_FkIncludeOrderProducts_OrderID];
GO
IF OBJECT_ID(N'[dbo].[FK_FkIncludeOrderProducts_ProductID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IncludeOrderProducts] DROP CONSTRAINT [FK_FkIncludeOrderProducts_ProductID];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[IncludeImportedProducts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IncludeImportedProducts];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[WarehouseReceipts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WarehouseReceipts];
GO
IF OBJECT_ID(N'[dbo].[Agents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Agents];
GO
IF OBJECT_ID(N'[dbo].[IncludeOrderProducts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IncludeOrderProducts];
GO
IF OBJECT_ID(N'[dbo].[OrderReceipts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderReceipts];
GO
IF OBJECT_ID(N'[dbo].[Distributors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Distributors];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'IncludeImportedProducts'
CREATE TABLE [dbo].[IncludeImportedProducts] (
    [TotalProductQuantity] int  NOT NULL,
    [TotalProductPrice] int  NOT NULL,
    [ReceiptID] int  NOT NULL,
    [ProductID] varchar(10)  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [ProductID] varchar(10)  NOT NULL,
    [ProductName] nvarchar(50)  NOT NULL,
    [ProductPrice] int  NOT NULL,
    [ProductQuantity] int  NOT NULL
);
GO

-- Creating table 'WarehouseReceipts'
CREATE TABLE [dbo].[WarehouseReceipts] (
    [ReceiptID] int IDENTITY(1,1) NOT NULL,
    [TotalWarehouseQuantity] int  NOT NULL,
    [TotalWarehousePrice] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL
);
GO

-- Creating table 'Agents'
CREATE TABLE [dbo].[Agents] (
    [AgentID] varchar(10)  NOT NULL,
    [AgentName] nvarchar(50)  NOT NULL,
    [AgentAccount] nvarchar(50)  NOT NULL,
    [AgentPassword] nvarchar(50)  NOT NULL,
    [AgentAddress] nvarchar(100)  NULL,
    [AgentPhoneNumber] nvarchar(20)  NULL
);
GO

-- Creating table 'IncludeOrderProducts'
CREATE TABLE [dbo].[IncludeOrderProducts] (
    [TotalProductQuantity] int  NOT NULL,
    [TotalProductPrice] int  NOT NULL,
    [OrderID] int  NOT NULL,
    [ProductID] varchar(10)  NOT NULL
);
GO

-- Creating table 'OrderReceipts'
CREATE TABLE [dbo].[OrderReceipts] (
    [OrderID] int IDENTITY(1,1) NOT NULL,
    [TotalOrderPrice] int  NOT NULL,
    [TotalOrderQuantity] int  NOT NULL,
    [OrderedDate] datetime  NOT NULL,
    [Status] nvarchar(50)  NOT NULL,
    [AgentID] varchar(10)  NOT NULL
);
GO

-- Creating table 'Distributors'
CREATE TABLE [dbo].[Distributors] (
    [DistributorID] varchar(10)  NOT NULL,
    [DistributorAccount] nvarchar(50)  NOT NULL,
    [DistributorPassword] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ReceiptID], [ProductID] in table 'IncludeImportedProducts'
ALTER TABLE [dbo].[IncludeImportedProducts]
ADD CONSTRAINT [PK_IncludeImportedProducts]
    PRIMARY KEY CLUSTERED ([ReceiptID], [ProductID] ASC);
GO

-- Creating primary key on [ProductID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ProductID] ASC);
GO

-- Creating primary key on [ReceiptID] in table 'WarehouseReceipts'
ALTER TABLE [dbo].[WarehouseReceipts]
ADD CONSTRAINT [PK_WarehouseReceipts]
    PRIMARY KEY CLUSTERED ([ReceiptID] ASC);
GO

-- Creating primary key on [AgentID] in table 'Agents'
ALTER TABLE [dbo].[Agents]
ADD CONSTRAINT [PK_Agents]
    PRIMARY KEY CLUSTERED ([AgentID] ASC);
GO

-- Creating primary key on [OrderID], [ProductID] in table 'IncludeOrderProducts'
ALTER TABLE [dbo].[IncludeOrderProducts]
ADD CONSTRAINT [PK_IncludeOrderProducts]
    PRIMARY KEY CLUSTERED ([OrderID], [ProductID] ASC);
GO

-- Creating primary key on [OrderID] in table 'OrderReceipts'
ALTER TABLE [dbo].[OrderReceipts]
ADD CONSTRAINT [PK_OrderReceipts]
    PRIMARY KEY CLUSTERED ([OrderID] ASC);
GO

-- Creating primary key on [DistributorID] in table 'Distributors'
ALTER TABLE [dbo].[Distributors]
ADD CONSTRAINT [PK_Distributors]
    PRIMARY KEY CLUSTERED ([DistributorID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProductID] in table 'IncludeImportedProducts'
ALTER TABLE [dbo].[IncludeImportedProducts]
ADD CONSTRAINT [FK_FkIncludeImportedProducts_ProductID]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[Products]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FkIncludeImportedProducts_ProductID'
CREATE INDEX [IX_FK_FkIncludeImportedProducts_ProductID]
ON [dbo].[IncludeImportedProducts]
    ([ProductID]);
GO

-- Creating foreign key on [ReceiptID] in table 'IncludeImportedProducts'
ALTER TABLE [dbo].[IncludeImportedProducts]
ADD CONSTRAINT [FK_FkIncludeImportedProducts_ReceiptID]
    FOREIGN KEY ([ReceiptID])
    REFERENCES [dbo].[WarehouseReceipts]
        ([ReceiptID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AgentID] in table 'OrderReceipts'
ALTER TABLE [dbo].[OrderReceipts]
ADD CONSTRAINT [FK_FkOrderReceipt_AgentID]
    FOREIGN KEY ([AgentID])
    REFERENCES [dbo].[Agents]
        ([AgentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FkOrderReceipt_AgentID'
CREATE INDEX [IX_FK_FkOrderReceipt_AgentID]
ON [dbo].[OrderReceipts]
    ([AgentID]);
GO

-- Creating foreign key on [OrderID] in table 'IncludeOrderProducts'
ALTER TABLE [dbo].[IncludeOrderProducts]
ADD CONSTRAINT [FK_FkIncludeOrderProducts_OrderID]
    FOREIGN KEY ([OrderID])
    REFERENCES [dbo].[OrderReceipts]
        ([OrderID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProductID] in table 'IncludeOrderProducts'
ALTER TABLE [dbo].[IncludeOrderProducts]
ADD CONSTRAINT [FK_FkIncludeOrderProducts_ProductID]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[Products]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FkIncludeOrderProducts_ProductID'
CREATE INDEX [IX_FK_FkIncludeOrderProducts_ProductID]
ON [dbo].[IncludeOrderProducts]
    ([ProductID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------