CREATE TABLE [dbo].[AssignBookInfo] (
    [ID]         INT IDENTITY (1, 1) NOT NULL,
    [UserId]     INT NOT NULL,
    [BookId]     INT NOT NULL,
    [IsReturned] BIT NOT NULL,
    CONSTRAINT [PK_AssignBookInfo] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_AssignBookInfo_BookInfo] FOREIGN KEY ([BookId]) REFERENCES [dbo].[BookInfo] ([ID]),
    CONSTRAINT [FK_AssignBookInfo_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([ID])
);

