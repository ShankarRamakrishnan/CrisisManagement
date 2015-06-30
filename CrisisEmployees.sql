USE [CrisisManagement]
GO

/****** Object: Table [dbo].[CrisisEmployees] Script Date: 7/1/2015 4:50:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[CrisisEmployees];


GO
CREATE TABLE [dbo].[CrisisEmployees] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [EmployeeAffected] VARCHAR (50)     NOT NULL
);


