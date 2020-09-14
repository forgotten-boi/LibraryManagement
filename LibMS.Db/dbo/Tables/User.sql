CREATE TABLE [dbo].[User] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (500) NULL,
    [LastName]  NVARCHAR (500) NULL,
    [UserName]  NVARCHAR (500) NULL,
    [Password]  NVARCHAR (500) NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([ID] ASC)
);

