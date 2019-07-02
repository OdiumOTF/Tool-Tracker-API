
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/09/2019 14:04:35
-- Generated from EDMX file: c:\users\student\source\repos\ToolTrackerAPI\ToolTrackerAPI\Models\ToolTrackerDb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ToolRental];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Customer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customer];
GO
IF OBJECT_ID(N'[dbo].[Rental]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rental];
GO
IF OBJECT_ID(N'[dbo].[Tool]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tool];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [CustomerId] int IDENTITY(1,1) NOT NULL,
    [CustomerName] nvarchar(max)  NULL,
    [CustomerPhone] nvarchar(max)  NULL
);
GO

-- Creating table 'Rentals'
CREATE TABLE [dbo].[Rentals] (
    [RentalId] int IDENTITY(1,1) NOT NULL,
    [CustomerId] int  NOT NULL,
    [DateRented] datetime  NOT NULL,
    [DateReturned] datetime  NULL,
    [ToolId] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tools'
CREATE TABLE [dbo].[Tools] (
    [ToolId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Brand] nvarchar(max)  NULL,
    [Notes] nvarchar(max)  NULL,
    [Available] int  NOT NULL,
    [AssetNum] nvarchar(max)  NOT NULL,
    [Comment] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ToolHistories'
CREATE TABLE [dbo].[ToolHistories] (
    [ToolHistoryId] int IDENTITY(1,1) NOT NULL,
    [CustomerName] nvarchar(max)  NOT NULL,
    [Borrowed] datetime  NOT NULL,
    [Returned] datetime  NULL,
    [AssetNum] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Workshops'
CREATE TABLE [dbo].[Workshops] (
    [WorkshopId] int IDENTITY(1,1) NOT NULL,
    [WorkshopName] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CustomerId] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([CustomerId] ASC);
GO

-- Creating primary key on [RentalId] in table 'Rentals'
ALTER TABLE [dbo].[Rentals]
ADD CONSTRAINT [PK_Rentals]
    PRIMARY KEY CLUSTERED ([RentalId] ASC);
GO

-- Creating primary key on [ToolId] in table 'Tools'
ALTER TABLE [dbo].[Tools]
ADD CONSTRAINT [PK_Tools]
    PRIMARY KEY CLUSTERED ([ToolId] ASC);
GO

-- Creating primary key on [ToolHistoryId] in table 'ToolHistories'
ALTER TABLE [dbo].[ToolHistories]
ADD CONSTRAINT [PK_ToolHistories]
    PRIMARY KEY CLUSTERED ([ToolHistoryId] ASC);
GO

-- Creating primary key on [WorkshopId] in table 'Workshops'
ALTER TABLE [dbo].[Workshops]
ADD CONSTRAINT [PK_Workshops]
    PRIMARY KEY CLUSTERED ([WorkshopId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------