IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Categories] (
    [Id] int NOT NULL IDENTITY,
    [Name] varchar(150) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Books] (
    [Id] int NOT NULL IDENTITY,
    [Name] varchar(150) NOT NULL,
    [Author] varchar(150) NOT NULL,
    [Description] varchar(350) NULL,
    [Value] float NOT NULL,
    [PublishDate] datetime2 NOT NULL,
    [CategoryId] int NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Books_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id])
);
GO

CREATE INDEX [IX_Books_CategoryId] ON [Books] ([CategoryId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230520000335_InitialCreate', N'6.0.16');
GO

COMMIT;
GO

