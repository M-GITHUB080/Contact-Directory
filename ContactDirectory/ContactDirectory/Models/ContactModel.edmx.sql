
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/27/2019 20:55:38
-- Generated from EDMX file: C:\Users\Hassaan-pc\documents\visual studio 2012\Projects\ContactDirectory\ContactDirectory\Models\ContactModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ContactDirectoryDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Contacts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contacts];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Contacts'
CREATE TABLE [dbo].[Contacts] (
    [ContactID] int IDENTITY(1,1) NOT NULL,
    [Company] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(30)  NOT NULL,
    [LastName] nvarchar(30)  NOT NULL,
    [JobTitle] nvarchar(50)  NOT NULL,
    [OfficePhone] nchar(14)  NOT NULL,
    [CellPhone] nchar(14)  NOT NULL,
    [FaxNo] nvarchar(14)  NOT NULL,
    [Email] nvarchar(40)  NOT NULL,
    [Website] nvarchar(50)  NOT NULL,
    [Address] nvarchar(60)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ContactID] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [PK_Contacts]
    PRIMARY KEY CLUSTERED ([ContactID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------