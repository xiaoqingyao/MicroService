DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Email');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Users] DROP COLUMN [Email];

GO

ALTER TABLE [Users] ADD [Introduction] nvarchar(max) NULL;

GO

CREATE TABLE [Departments] (
    [EId] int NOT NULL IDENTITY,
    [CreationTime] datetime2 NOT NULL,
    [UpdatTime] datetime2 NOT NULL,
    [Gid] uniqueidentifier NOT NULL,
    [Deleted] bit NOT NULL,
    [Name] nvarchar(450) NULL,
    CONSTRAINT [PK_Departments] PRIMARY KEY ([EId])
);

GO

CREATE INDEX [IX_Departments_Name] ON [Departments] ([Name]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201026062005_UpUserAddDept', N'3.1.9');

GO

