/*
Script created by SQL Examiner 5.0.0.93 at 06/16/2017 17:34:06.
Run this script on SQL5036.Smarterasp.net.QualityMeterDB to make it the same as (local).QualityMeterDB
*/
USE [QualityMeterDB]
GO
SET NOCOUNT ON
SET NOEXEC OFF
SET ARITHABORT ON
SET XACT_ABORT ON
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
BEGIN TRAN
GO
--step 1: create table dbo.__MigrationHistory-------------------------------------------------------
CREATE TABLE [dbo].[__MigrationHistory] (
	[MigrationId]		[nvarchar](150)	 COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ContextKey]		[nvarchar](300)	 COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Model]				[varbinary](max) NOT NULL,
	[ProductVersion]	[nvarchar](32)	 COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 1 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 1 is completed with errors' SET NOEXEC ON END
GO
--step 2: dbo.__MigrationHistory: add primary key PK_dbo.__MigrationHistory-------------------------
ALTER TABLE [dbo].[__MigrationHistory] ADD CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey])
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 2 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 2 is completed with errors' SET NOEXEC ON END
GO
--step 3: create table dbo.tb_Application-----------------------------------------------------------
CREATE TABLE [dbo].[tb_Application] (
	[Id]				[uniqueidentifier]	 NOT NULL,
	[Name]				[nvarchar](500)		 COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description]		[nvarchar](max)		 COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Customer]			[nvarchar](500)		 COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CreationDate]		[datetime]			 NOT NULL,
	[LastUpdated]		[datetime]			 NOT NULL,
	[RowVersion]		[timestamp]			 NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 3 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 3 is completed with errors' SET NOEXEC ON END
GO
--step 4: dbo.tb_Application: add default DF__tb_Applicati__Id__267ABA7A----------------------------
ALTER TABLE [dbo].[tb_Application] ADD CONSTRAINT [DF__tb_Applicati__Id__267ABA7A] DEFAULT (newsequentialid())FOR [Id]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 4 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 4 is completed with errors' SET NOEXEC ON END
GO
--step 5: dbo.tb_Application: add primary key PK_dbo.tb_Application---------------------------------
ALTER TABLE [dbo].[tb_Application] ADD CONSTRAINT [PK_dbo.tb_Application] PRIMARY KEY CLUSTERED ([Id])
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 5 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 5 is completed with errors' SET NOEXEC ON END
GO
--step 6: create table dbo.tb_ApplicationEvaluations------------------------------------------------
CREATE TABLE [dbo].[tb_ApplicationEvaluations] (
	[Id]							[uniqueidentifier]	 NOT NULL,
	[QualityAttributesMetricId]		[uniqueidentifier]	 NOT NULL,
	[ApplicationId]					[uniqueidentifier]	 NOT NULL,
	[QualityValue]					[real]				 NOT NULL,
	[UserValue]						[real]				 NOT NULL,
	[CreationDate]					[datetime]			 NOT NULL,
	[LastUpdated]					[datetime]			 NOT NULL,
	[RowVersion]					[timestamp]			 NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 6 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 6 is completed with errors' SET NOEXEC ON END
GO
--step 7: dbo.tb_ApplicationEvaluations: add default DF__tb_Applicati__Id__239E4DCF-----------------
ALTER TABLE [dbo].[tb_ApplicationEvaluations] ADD CONSTRAINT [DF__tb_Applicati__Id__239E4DCF] DEFAULT (newsequentialid())FOR [Id]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 7 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 7 is completed with errors' SET NOEXEC ON END
GO
--step 8: dbo.tb_ApplicationEvaluations: add primary key PK_dbo.tb_ApplicationEvaluations-----------
ALTER TABLE [dbo].[tb_ApplicationEvaluations] ADD CONSTRAINT [PK_dbo.tb_ApplicationEvaluations] PRIMARY KEY CLUSTERED ([Id])
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 8 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 8 is completed with errors' SET NOEXEC ON END
GO
--step 9: add index IX_ApplicationId to table dbo.tb_ApplicationEvaluations-------------------------
CREATE NONCLUSTERED INDEX [IX_ApplicationId] ON [dbo].[tb_ApplicationEvaluations]([ApplicationId]) ON [PRIMARY]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 9 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 9 is completed with errors' SET NOEXEC ON END
GO
--step 10: add index IX_QualityAttributesMetricId to table dbo.tb_ApplicationEvaluations------------
CREATE NONCLUSTERED INDEX [IX_QualityAttributesMetricId] ON [dbo].[tb_ApplicationEvaluations]([QualityAttributesMetricId]) ON [PRIMARY]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 10 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 10 is completed with errors' SET NOEXEC ON END
GO
--step 11: dbo.tb_ApplicationEvaluations: add foreign key FK_dbo.tb_ApplicationEvaluations_dbo.tb_Application_ApplicationId
ALTER TABLE [dbo].[tb_ApplicationEvaluations] ADD CONSTRAINT [FK_dbo.tb_ApplicationEvaluations_dbo.tb_Application_ApplicationId] FOREIGN KEY ([ApplicationId]) REFERENCES [dbo].[tb_Application] ([Id]) ON DELETE CASCADE
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 11 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 11 is completed with errors' SET NOEXEC ON END
GO
--step 12: create table dbo.tb_QualityAttributesMetrics---------------------------------------------
CREATE TABLE [dbo].[tb_QualityAttributesMetrics] (
	[Id]					[uniqueidentifier]	 NOT NULL,
	[Name]					[nvarchar](500)		 COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description]			[nvarchar](max)		 COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CriteriaId]			[uniqueidentifier]	 NOT NULL,
	[TypeOfMetric]			[int]				 NOT NULL,
	[Quantification]		[int]				 NOT NULL,
	[StandardValue]			[real]				 NOT NULL,
	[EvaluationValue]		[real]				 NOT NULL,
	[RouteBased]			[nvarchar](30)		 COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[RelatedToId]			[uniqueidentifier]	 NULL,
	[AgainstId]				[uniqueidentifier]	 NULL,
	[CreationDate]			[datetime]			 NOT NULL,
	[LastUpdated]			[datetime]			 NOT NULL,
	[RowVersion]			[timestamp]			 NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 12 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 12 is completed with errors' SET NOEXEC ON END
GO
--step 13: dbo.tb_QualityAttributesMetrics: add default DF__tb_QualityAt__Id__29572725--------------
ALTER TABLE [dbo].[tb_QualityAttributesMetrics] ADD CONSTRAINT [DF__tb_QualityAt__Id__29572725] DEFAULT (newsequentialid())FOR [Id]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 13 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 13 is completed with errors' SET NOEXEC ON END
GO
--step 14: dbo.tb_QualityAttributesMetrics: add primary key PK_dbo.tb_QualityAttributesMetrics------
ALTER TABLE [dbo].[tb_QualityAttributesMetrics] ADD CONSTRAINT [PK_dbo.tb_QualityAttributesMetrics] PRIMARY KEY CLUSTERED ([Id])
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 14 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 14 is completed with errors' SET NOEXEC ON END
GO
--step 15: add index IX_AgainstId to table dbo.tb_QualityAttributesMetrics--------------------------
CREATE NONCLUSTERED INDEX [IX_AgainstId] ON [dbo].[tb_QualityAttributesMetrics]([AgainstId]) ON [PRIMARY]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 15 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 15 is completed with errors' SET NOEXEC ON END
GO
--step 16: add index IX_CriteriaId to table dbo.tb_QualityAttributesMetrics-------------------------
CREATE NONCLUSTERED INDEX [IX_CriteriaId] ON [dbo].[tb_QualityAttributesMetrics]([CriteriaId]) ON [PRIMARY]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 16 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 16 is completed with errors' SET NOEXEC ON END
GO
--step 17: add index IX_Name_CriteriaId to table dbo.tb_QualityAttributesMetrics--------------------
CREATE UNIQUE NONCLUSTERED INDEX [IX_Name_CriteriaId] ON [dbo].[tb_QualityAttributesMetrics]([Name], [CriteriaId]) ON [PRIMARY]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 17 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 17 is completed with errors' SET NOEXEC ON END
GO
--step 18: add index IX_RelatedToId to table dbo.tb_QualityAttributesMetrics------------------------
CREATE NONCLUSTERED INDEX [IX_RelatedToId] ON [dbo].[tb_QualityAttributesMetrics]([RelatedToId]) ON [PRIMARY]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 18 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 18 is completed with errors' SET NOEXEC ON END
GO
--step 19: create table dbo.tb_Criterias------------------------------------------------------------
CREATE TABLE [dbo].[tb_Criterias] (
	[Id]				[uniqueidentifier]	 NOT NULL,
	[Name]				[nvarchar](500)		 COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description]		[nvarchar](max)		 COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FactorId]			[uniqueidentifier]	 NOT NULL,
	[CreationDate]		[datetime]			 NOT NULL,
	[LastUpdated]		[datetime]			 NOT NULL,
	[RowVersion]		[timestamp]			 NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 19 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 19 is completed with errors' SET NOEXEC ON END
GO
--step 20: dbo.tb_Criterias: add default DF__tb_Criterias__Id__2C3393D0-----------------------------
ALTER TABLE [dbo].[tb_Criterias] ADD CONSTRAINT [DF__tb_Criterias__Id__2C3393D0] DEFAULT (newsequentialid())FOR [Id]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 20 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 20 is completed with errors' SET NOEXEC ON END
GO
--step 21: dbo.tb_Criterias: add primary key PK_dbo.tb_Criterias------------------------------------
ALTER TABLE [dbo].[tb_Criterias] ADD CONSTRAINT [PK_dbo.tb_Criterias] PRIMARY KEY CLUSTERED ([Id])
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 21 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 21 is completed with errors' SET NOEXEC ON END
GO
--step 22: add index IX_Name_FactorId to table dbo.tb_Criterias-------------------------------------
CREATE UNIQUE NONCLUSTERED INDEX [IX_Name_FactorId] ON [dbo].[tb_Criterias]([Name], [FactorId]) ON [PRIMARY]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 22 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 22 is completed with errors' SET NOEXEC ON END
GO
--step 23: create table dbo.tb_Factors--------------------------------------------------------------
CREATE TABLE [dbo].[tb_Factors] (
	[Id]				[uniqueidentifier]	 NOT NULL,
	[Name]				[nvarchar](500)		 COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description]		[nvarchar](max)		 COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SubjectId]			[uniqueidentifier]	 NOT NULL,
	[CreationDate]		[datetime]			 NOT NULL,
	[LastUpdated]		[datetime]			 NOT NULL,
	[RowVersion]		[timestamp]			 NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 23 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 23 is completed with errors' SET NOEXEC ON END
GO
--step 24: dbo.tb_Factors: add default DF__tb_Factors__Id__2F10007B---------------------------------
ALTER TABLE [dbo].[tb_Factors] ADD CONSTRAINT [DF__tb_Factors__Id__2F10007B] DEFAULT (newsequentialid())FOR [Id]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 24 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 24 is completed with errors' SET NOEXEC ON END
GO
--step 25: dbo.tb_Factors: add primary key PK_dbo.tb_Factors----------------------------------------
ALTER TABLE [dbo].[tb_Factors] ADD CONSTRAINT [PK_dbo.tb_Factors] PRIMARY KEY CLUSTERED ([Id])
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 25 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 25 is completed with errors' SET NOEXEC ON END
GO
--step 26: add index IX_Name_SubjectId to table dbo.tb_Factors--------------------------------------
CREATE UNIQUE NONCLUSTERED INDEX [IX_Name_SubjectId] ON [dbo].[tb_Factors]([Name], [SubjectId]) ON [PRIMARY]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 26 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 26 is completed with errors' SET NOEXEC ON END
GO
--step 27: create table dbo.tb_Subjects-------------------------------------------------------------
CREATE TABLE [dbo].[tb_Subjects] (
	[Id]				[uniqueidentifier]	 NOT NULL,
	[Name]				[nvarchar](500)		 COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description]		[nvarchar](max)		 COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreationDate]		[datetime]			 NOT NULL,
	[LastUpdated]		[datetime]			 NOT NULL,
	[RowVersion]		[timestamp]			 NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 27 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 27 is completed with errors' SET NOEXEC ON END
GO
--step 28: dbo.tb_Subjects: add default DF__tb_Subjects__Id__31EC6D26-------------------------------
ALTER TABLE [dbo].[tb_Subjects] ADD CONSTRAINT [DF__tb_Subjects__Id__31EC6D26] DEFAULT (newsequentialid())FOR [Id]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 28 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 28 is completed with errors' SET NOEXEC ON END
GO
--step 29: dbo.tb_Subjects: add primary key PK_dbo.tb_Subjects--------------------------------------
ALTER TABLE [dbo].[tb_Subjects] ADD CONSTRAINT [PK_dbo.tb_Subjects] PRIMARY KEY CLUSTERED ([Id])
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 29 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 29 is completed with errors' SET NOEXEC ON END
GO
--step 30: add index IX_Name to table dbo.tb_Subjects-----------------------------------------------
CREATE UNIQUE NONCLUSTERED INDEX [IX_Name] ON [dbo].[tb_Subjects]([Name]) ON [PRIMARY]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 30 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 30 is completed with errors' SET NOEXEC ON END
GO
--step 31: dbo.tb_Factors: add foreign key FK_dbo.tb_Factors_dbo.tb_Subjects_SubjectId--------------
ALTER TABLE [dbo].[tb_Factors] ADD CONSTRAINT [FK_dbo.tb_Factors_dbo.tb_Subjects_SubjectId] FOREIGN KEY ([SubjectId]) REFERENCES [dbo].[tb_Subjects] ([Id])
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 31 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 31 is completed with errors' SET NOEXEC ON END
GO
--step 32: dbo.tb_Criterias: add foreign key FK_dbo.tb_Criterias_dbo.tb_Factors_FactorId------------
ALTER TABLE [dbo].[tb_Criterias] ADD CONSTRAINT [FK_dbo.tb_Criterias_dbo.tb_Factors_FactorId] FOREIGN KEY ([FactorId]) REFERENCES [dbo].[tb_Factors] ([Id]) ON DELETE CASCADE
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 32 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 32 is completed with errors' SET NOEXEC ON END
GO
--step 33: dbo.tb_QualityAttributesMetrics: add foreign key FK_dbo.tb_QualityAttributesMetrics_dbo.tb_Criterias_CriteriaId
ALTER TABLE [dbo].[tb_QualityAttributesMetrics] ADD CONSTRAINT [FK_dbo.tb_QualityAttributesMetrics_dbo.tb_Criterias_CriteriaId] FOREIGN KEY ([CriteriaId]) REFERENCES [dbo].[tb_Criterias] ([Id])
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 33 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 33 is completed with errors' SET NOEXEC ON END
GO
--step 34: dbo.tb_QualityAttributesMetrics: add foreign key FK_dbo.tb_QualityAttributesMetrics_dbo.tb_QualityAttributesMetrics_AgainstId
ALTER TABLE [dbo].[tb_QualityAttributesMetrics] ADD CONSTRAINT [FK_dbo.tb_QualityAttributesMetrics_dbo.tb_QualityAttributesMetrics_AgainstId] FOREIGN KEY ([AgainstId]) REFERENCES [dbo].[tb_QualityAttributesMetrics] ([Id])
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 34 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 34 is completed with errors' SET NOEXEC ON END
GO
--step 35: dbo.tb_QualityAttributesMetrics: add foreign key FK_dbo.tb_QualityAttributesMetrics_dbo.tb_QualityAttributesMetrics_RelatedToId
ALTER TABLE [dbo].[tb_QualityAttributesMetrics] ADD CONSTRAINT [FK_dbo.tb_QualityAttributesMetrics_dbo.tb_QualityAttributesMetrics_RelatedToId] FOREIGN KEY ([RelatedToId]) REFERENCES [dbo].[tb_QualityAttributesMetrics] ([Id])
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 35 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 35 is completed with errors' SET NOEXEC ON END
GO
--step 36: dbo.tb_ApplicationEvaluations: add foreign key FK_dbo.tb_ApplicationEvaluations_dbo.tb_QualityAttributesMetrics_QualityAttributesMetricId
ALTER TABLE [dbo].[tb_ApplicationEvaluations] ADD CONSTRAINT [FK_dbo.tb_ApplicationEvaluations_dbo.tb_QualityAttributesMetrics_QualityAttributesMetricId] FOREIGN KEY ([QualityAttributesMetricId]) REFERENCES [dbo].[tb_QualityAttributesMetrics] ([Id]) ON DELETE CASCADE
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 36 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 36 is completed with errors' SET NOEXEC ON END
GO
--step 37: create table dbo.tb_Roles----------------------------------------------------------------
CREATE TABLE [dbo].[tb_Roles] (
	[Id]			[bigint]		 IDENTITY(1, 1) NOT NULL,
	[Roles]			[nvarchar](max)	 COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsSystem]		[bit]			 NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 37 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 37 is completed with errors' SET NOEXEC ON END
GO
--step 38: dbo.tb_Roles: add primary key PK_dbo.tb_Roles--------------------------------------------
ALTER TABLE [dbo].[tb_Roles] ADD CONSTRAINT [PK_dbo.tb_Roles] PRIMARY KEY CLUSTERED ([Id])
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 38 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 38 is completed with errors' SET NOEXEC ON END
GO
--step 39: create table dbo.tb_Users----------------------------------------------------------------
CREATE TABLE [dbo].[tb_Users] (
	[Id]			[bigint]		 IDENTITY(1, 1) NOT NULL,
	[UserName]		[nvarchar](256)	 COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Password]		[nvarchar](max)	 COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Active]		[bit]			 NOT NULL,
	[IsSystem]		[bit]			 NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 39 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 39 is completed with errors' SET NOEXEC ON END
GO
--step 40: dbo.tb_Users: add primary key PK_dbo.tb_Users--------------------------------------------
ALTER TABLE [dbo].[tb_Users] ADD CONSTRAINT [PK_dbo.tb_Users] PRIMARY KEY CLUSTERED ([Id])
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 40 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 40 is completed with errors' SET NOEXEC ON END
GO
--step 41: add index IX_Active to table dbo.tb_Users------------------------------------------------
CREATE NONCLUSTERED INDEX [IX_Active] ON [dbo].[tb_Users]([Active]) ON [PRIMARY]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 41 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 41 is completed with errors' SET NOEXEC ON END
GO
--step 42: add index IX_UserName to table dbo.tb_Users----------------------------------------------
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserName] ON [dbo].[tb_Users]([UserName]) ON [PRIMARY]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 42 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 42 is completed with errors' SET NOEXEC ON END
GO
--step 43: create table dbo.tb_Users_Roles----------------------------------------------------------
CREATE TABLE [dbo].[tb_Users_Roles] (
	[Id]		[bigint] IDENTITY(1, 1) NOT NULL,
	[UserId]	[bigint] NOT NULL,
	[RoleId]	[bigint] NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 43 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 43 is completed with errors' SET NOEXEC ON END
GO
--step 44: dbo.tb_Users_Roles: add primary key PK_dbo.tb_Users_Roles--------------------------------
ALTER TABLE [dbo].[tb_Users_Roles] ADD CONSTRAINT [PK_dbo.tb_Users_Roles] PRIMARY KEY CLUSTERED ([Id])
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 44 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 44 is completed with errors' SET NOEXEC ON END
GO
--step 45: add index IX_UserId_RoleId to table dbo.tb_Users_Roles-----------------------------------
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserId_RoleId] ON [dbo].[tb_Users_Roles]([UserId], [RoleId]) ON [PRIMARY]
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 45 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 45 is completed with errors' SET NOEXEC ON END
GO
--step 46: dbo.tb_Users_Roles: add foreign key FK_dbo.tb_Users_Roles_dbo.tb_Roles_RoleId------------
ALTER TABLE [dbo].[tb_Users_Roles] ADD CONSTRAINT [FK_dbo.tb_Users_Roles_dbo.tb_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[tb_Roles] ([Id]) ON DELETE CASCADE
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 46 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 46 is completed with errors' SET NOEXEC ON END
GO
--step 47: dbo.tb_Users_Roles: add foreign key FK_dbo.tb_Users_Roles_dbo.tb_Users_UserId------------
ALTER TABLE [dbo].[tb_Users_Roles] ADD CONSTRAINT [FK_dbo.tb_Users_Roles_dbo.tb_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[tb_Users] ([Id]) ON DELETE CASCADE
GO
IF @@ERROR <> 0 AND @@TRANCOUNT > 0 BEGIN PRINT 'step 47 is completed with errors' ROLLBACK TRAN END
GO
IF @@TRANCOUNT = 0 BEGIN PRINT 'step 47 is completed with errors' SET NOEXEC ON END
GO
----------------------------------------------------------------------
IF @@TRANCOUNT > 0 BEGIN COMMIT TRAN PRINT 'Synchronization is successfully completed.' END
GO
SET NOEXEC OFF
GO

