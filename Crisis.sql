USE [CrisisManagement]
GO

/****** Object: Table [dbo].[Crisis] Script Date: 7/1/2015 4:49:04 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Crisis];


GO
CREATE TABLE [dbo].[Crisis] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Location]    VARCHAR (MAX)    NOT NULL,
    [WhenHappend] DATETIME         NOT NULL,
    [Heading]     VARCHAR (MAX)    NULL,
    [Description] VARCHAR (MAX)    NULL
);


