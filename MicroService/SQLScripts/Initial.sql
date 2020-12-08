IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Users] (
    [EId] int NOT NULL IDENTITY,
    [CreationTime] datetime2 NOT NULL,
    [UpdatTime] datetime2 NOT NULL,
    [Gid] uniqueidentifier NOT NULL,
    [Deleted] bit NOT NULL,
    [Name] nvarchar(450) NULL,
    [Pwd] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [RegistTime] datetime2 NOT NULL,
    [LastLoginTime] datetime2 NOT NULL,
    [Status] bit NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([EId])
);

GO

CREATE INDEX [IX_Users_Name_Status] ON [Users] ([Name], [Status]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201026061627_Initial', N'3.1.9');

GO

