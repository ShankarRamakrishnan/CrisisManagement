USE [CrisisManagement]
GO

/****** Object: Table [dbo].[Crisis] Script Date: 6/29/2015 1:45:06 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Crisis];


GO
CREATE TABLE [dbo].[Crisis] (
    [Id]             UNIQUEIDENTIFIER           NOT NULL,
    [Where]          VARCHAR (100) NOT NULL,
    [WhenHappend]    DATETIME      NOT NULL,
    [AffectedPeople] VARCHAR (MAX) NOT NULL
);


