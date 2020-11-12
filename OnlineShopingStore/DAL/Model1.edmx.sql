
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/09/2020 09:09:02
-- Generated from EDMX file: D:\CoursInfoGestion\Cours_Uccle03\ASP.NET-Project\OnlineShopingStore\OnlineShopingStore\DAL\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DB_MyOnlineIphoneStore];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Tbl_Cart__Member__239E4DCF]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tbl_Cart] DROP CONSTRAINT [FK__Tbl_Cart__Member__239E4DCF];
GO
IF OBJECT_ID(N'[dbo].[FK__Tbl_Cart__Produc__22AA2996]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tbl_Cart] DROP CONSTRAINT [FK__Tbl_Cart__Produc__22AA2996];
GO
IF OBJECT_ID(N'[dbo].[FK__Tbl_Membe__Membe__267ABA7A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tbl_MemberRole] DROP CONSTRAINT [FK__Tbl_Membe__Membe__267ABA7A];
GO
IF OBJECT_ID(N'[dbo].[FK__Tbl_Membe__RoleI__276EDEB3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tbl_MemberRole] DROP CONSTRAINT [FK__Tbl_Membe__RoleI__276EDEB3];
GO
IF OBJECT_ID(N'[dbo].[FK__Tbl_Produ__Categ__145C0A3F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tbl_Product] DROP CONSTRAINT [FK__Tbl_Produ__Categ__145C0A3F];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Tbl_Cart]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_Cart];
GO
IF OBJECT_ID(N'[dbo].[Tbl_CartStatut]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_CartStatut];
GO
IF OBJECT_ID(N'[dbo].[Tbl_Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_Category];
GO
IF OBJECT_ID(N'[dbo].[Tbl_MemberRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_MemberRole];
GO
IF OBJECT_ID(N'[dbo].[Tbl_Members]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_Members];
GO
IF OBJECT_ID(N'[dbo].[Tbl_Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_Product];
GO
IF OBJECT_ID(N'[dbo].[Tbl_role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_role];
GO
IF OBJECT_ID(N'[dbo].[Tbl_SlideImage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_SlideImage];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Tbl_Cart'
CREATE TABLE [dbo].[Tbl_Cart] (
    [CartId] int IDENTITY(1,1) NOT NULL,
    [ProductId] int  NULL,
    [MemberId] int  NULL,
    [CartStatusld] int  NULL
);
GO

-- Creating table 'Tbl_CartStatut'
CREATE TABLE [dbo].[Tbl_CartStatut] (
    [CartStatutsld] int IDENTITY(1,1) NOT NULL,
    [CartStatut] varchar(500)  NULL
);
GO

-- Creating table 'Tbl_Category'
CREATE TABLE [dbo].[Tbl_Category] (
    [CategoryId] int IDENTITY(1,1) NOT NULL,
    [CategoryName] varchar(500)  NULL,
    [IsActive] bit  NULL,
    [IsDelete] bit  NULL
);
GO

-- Creating table 'Tbl_MemberRole'
CREATE TABLE [dbo].[Tbl_MemberRole] (
    [MemberRoleId] int IDENTITY(1,1) NOT NULL,
    [MemberId] int  NULL,
    [RoleId] int  NULL
);
GO

-- Creating table 'Tbl_Members'
CREATE TABLE [dbo].[Tbl_Members] (
    [memberId] int IDENTITY(1,1) NOT NULL,
    [FirstName] varchar(200)  NULL,
    [LastName] varchar(200)  NULL,
    [EmailId] varchar(200)  NULL,
    [Password] varchar(500)  NULL,
    [IsActive] bit  NULL,
    [IsDelete] bit  NULL,
    [CreateOn] datetime  NULL,
    [ModofiedOn] datetime  NULL
);
GO

-- Creating table 'Tbl_Product'
CREATE TABLE [dbo].[Tbl_Product] (
    [ProductId] int IDENTITY(1,1) NOT NULL,
    [ProductName] varchar(500)  NULL,
    [CategoryId] int  NULL,
    [IsActive] bit  NULL,
    [IsDelete] bit  NULL,
    [CreateDate] datetime  NULL,
    [ModifierDate] datetime  NULL,
    [Description]varchar(50) NULL,
    [ProductImage] varchar(max)  NULL,
    [Isfeatured] bit  NULL,
    [Quantity] int  NULL,
    [Price] decimal(18,0)  NULL
);
GO

-- Creating table 'Tbl_role'
CREATE TABLE [dbo].[Tbl_role] (
    [RoleId] int IDENTITY(1,1) NOT NULL,
    [RoleName] varchar(200)  NULL
);
GO

-- Creating table 'Tbl_ShippingDetails'
CREATE TABLE [dbo].[Tbl_ShippingDetails] (
    [ShippingDetailId] int IDENTITY(1,1) NOT NULL,
    [MemberId] int  NULL,
    [Adress] varchar(500)  NULL,
    [City] varchar(500)  NULL,
    [State] varchar(500)  NULL,
    [Country] varchar(50)  NULL,
    [Zipcode] varchar(50)  NULL,
    [OrderId] int  NULL,
    [AmountPaid] decimal(18,0)  NULL,
    [PayementType] varchar(50)  NULL
);
GO

-- Creating table 'Tbl_SlideImage'
CREATE TABLE [dbo].[Tbl_SlideImage] (
    [SlideId] int IDENTITY(1,1) NOT NULL,
    [SlideTitle] varchar(200)  NULL,
    [SlideImage] varchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CartId] in table 'Tbl_Cart'
ALTER TABLE [dbo].[Tbl_Cart]
ADD CONSTRAINT [PK_Tbl_Cart]
    PRIMARY KEY CLUSTERED ([CartId] ASC);
GO

-- Creating primary key on [CartStatutsld] in table 'Tbl_CartStatut'
ALTER TABLE [dbo].[Tbl_CartStatut]
ADD CONSTRAINT [PK_Tbl_CartStatut]
    PRIMARY KEY CLUSTERED ([CartStatutsld] ASC);
GO

-- Creating primary key on [CategoryId] in table 'Tbl_Category'
ALTER TABLE [dbo].[Tbl_Category]
ADD CONSTRAINT [PK_Tbl_Category]
    PRIMARY KEY CLUSTERED ([CategoryId] ASC);
GO

-- Creating primary key on [MemberRoleId] in table 'Tbl_MemberRole'
ALTER TABLE [dbo].[Tbl_MemberRole]
ADD CONSTRAINT [PK_Tbl_MemberRole]
    PRIMARY KEY CLUSTERED ([MemberRoleId] ASC);
GO

-- Creating primary key on [memberId] in table 'Tbl_Members'
ALTER TABLE [dbo].[Tbl_Members]
ADD CONSTRAINT [PK_Tbl_Members]
    PRIMARY KEY CLUSTERED ([memberId] ASC);
GO

-- Creating primary key on [ProductId] in table 'Tbl_Product'
ALTER TABLE [dbo].[Tbl_Product]
ADD CONSTRAINT [PK_Tbl_Product]
    PRIMARY KEY CLUSTERED ([ProductId] ASC);
GO

-- Creating primary key on [RoleId] in table 'Tbl_role'
ALTER TABLE [dbo].[Tbl_role]
ADD CONSTRAINT [PK_Tbl_role]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [ShippingDetailId] in table 'Tbl_ShippingDetails'
ALTER TABLE [dbo].[Tbl_ShippingDetails]
ADD CONSTRAINT [PK_Tbl_ShippingDetails]
    PRIMARY KEY CLUSTERED ([ShippingDetailId] ASC);
GO

-- Creating primary key on [SlideId] in table 'Tbl_SlideImage'
ALTER TABLE [dbo].[Tbl_SlideImage]
ADD CONSTRAINT [PK_Tbl_SlideImage]
    PRIMARY KEY CLUSTERED ([SlideId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MemberId] in table 'Tbl_Cart'
ALTER TABLE [dbo].[Tbl_Cart]
ADD CONSTRAINT [FK__Tbl_Cart__Member__239E4DCF]
    FOREIGN KEY ([MemberId])
    REFERENCES [dbo].[Tbl_Members]
        ([memberId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Tbl_Cart__Member__239E4DCF'
CREATE INDEX [IX_FK__Tbl_Cart__Member__239E4DCF]
ON [dbo].[Tbl_Cart]
    ([MemberId]);
GO

-- Creating foreign key on [ProductId] in table 'Tbl_Cart'
ALTER TABLE [dbo].[Tbl_Cart]
ADD CONSTRAINT [FK__Tbl_Cart__Produc__22AA2996]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Tbl_Product]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Tbl_Cart__Produc__22AA2996'
CREATE INDEX [IX_FK__Tbl_Cart__Produc__22AA2996]
ON [dbo].[Tbl_Cart]
    ([ProductId]);
GO

-- Creating foreign key on [CategoryId] in table 'Tbl_Product'
ALTER TABLE [dbo].[Tbl_Product]
ADD CONSTRAINT [FK__Tbl_Produ__Categ__145C0A3F]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[Tbl_Category]
        ([CategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Tbl_Produ__Categ__145C0A3F'
CREATE INDEX [IX_FK__Tbl_Produ__Categ__145C0A3F]
ON [dbo].[Tbl_Product]
    ([CategoryId]);
GO

-- Creating foreign key on [MemberId] in table 'Tbl_MemberRole'
ALTER TABLE [dbo].[Tbl_MemberRole]
ADD CONSTRAINT [FK__Tbl_Membe__Membe__267ABA7A]
    FOREIGN KEY ([MemberId])
    REFERENCES [dbo].[Tbl_Members]
        ([memberId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Tbl_Membe__Membe__267ABA7A'
CREATE INDEX [IX_FK__Tbl_Membe__Membe__267ABA7A]
ON [dbo].[Tbl_MemberRole]
    ([MemberId]);
GO

-- Creating foreign key on [RoleId] in table 'Tbl_MemberRole'
ALTER TABLE [dbo].[Tbl_MemberRole]
ADD CONSTRAINT [FK__Tbl_Membe__RoleI__276EDEB3]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Tbl_role]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Tbl_Membe__RoleI__276EDEB3'
CREATE INDEX [IX_FK__Tbl_Membe__RoleI__276EDEB3]
ON [dbo].[Tbl_MemberRole]
    ([RoleId]);
GO

-- Creating foreign key on [MemberId] in table 'Tbl_ShippingDetails'
ALTER TABLE [dbo].[Tbl_ShippingDetails]
ADD CONSTRAINT [FK__Tbl_Shipp__Membe__1CF15040]
    FOREIGN KEY ([MemberId])
    REFERENCES [dbo].[Tbl_Members]
        ([memberId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Tbl_Shipp__Membe__1CF15040'
CREATE INDEX [IX_FK__Tbl_Shipp__Membe__1CF15040]
ON [dbo].[Tbl_ShippingDetails]
    ([MemberId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------