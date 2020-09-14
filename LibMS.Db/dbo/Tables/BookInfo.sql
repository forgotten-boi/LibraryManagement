CREATE TABLE [dbo].[BookInfo] (
    [ID]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (500) NULL,
    [Details] NVARCHAR (500) NULL,
    CONSTRAINT [PK_BookInfo] PRIMARY KEY CLUSTERED ([ID] ASC)
);

