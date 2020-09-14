CREATE TABLE [dbo].[BookCountInfo] (
    [ID]        INT IDENTITY (1, 1) NOT NULL,
    [BookID]    INT NULL,
    [BookCount] INT NULL,
    CONSTRAINT [PK_BookCountInfo] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_BookCountInfo_BookInfo] FOREIGN KEY ([BookID]) REFERENCES [dbo].[BookInfo] ([ID])
);

