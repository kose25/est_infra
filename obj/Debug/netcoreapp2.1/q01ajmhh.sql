IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF SCHEMA_ID(N'GET') IS NULL EXEC(N'CREATE SCHEMA [GET];');

GO

CREATE TABLE [GET].[EstadoEstudiante] (
    [id] int NOT NULL IDENTITY,
    [nombre] nvarchar(max) NULL,
    [codigo] nvarchar(max) NULL,
    CONSTRAINT [PK_EstadoEstudiante] PRIMARY KEY ([id])
);

GO

CREATE TABLE [GET].[EstadoMateriaEstudiante] (
    [id] int NOT NULL IDENTITY,
    [nombre] nvarchar(max) NULL,
    [codigo] nvarchar(max) NULL,
    CONSTRAINT [PK_EstadoMateriaEstudiante] PRIMARY KEY ([id])
);

GO

CREATE TABLE [GET].[EstadoProfesor] (
    [id] int NOT NULL IDENTITY,
    [nombre] nvarchar(max) NULL,
    [codigo] nvarchar(max) NULL,
    CONSTRAINT [PK_EstadoProfesor] PRIMARY KEY ([id])
);

GO

CREATE TABLE [GET].[Materia] (
    [id] int NOT NULL IDENTITY,
    [nombre] nvarchar(max) NULL,
    [codigo] nvarchar(450) NULL,
    CONSTRAINT [PK_Materia] PRIMARY KEY ([id])
);

GO

CREATE TABLE [GET].[TipoDocumento] (
    [id] int NOT NULL IDENTITY,
    [codigo] nvarchar(max) NULL,
    [nombre] nvarchar(max) NULL,
    CONSTRAINT [PK_TipoDocumento] PRIMARY KEY ([id])
);

GO

CREATE TABLE [GET].[Estudiante] (
    [id] int NOT NULL IDENTITY,
    [nombre] nvarchar(max) NULL,
    [apellido] nvarchar(max) NULL,
    [documento] nvarchar(450) NULL,
    [TipoDocumentoid] int NULL,
    [fechaNacimiento] datetime2 NOT NULL,
    [sexo] nvarchar(max) NULL,
    [direccion] nvarchar(max) NULL,
    [telefono] nvarchar(max) NULL,
    [email] nvarchar(max) NULL,
    [fechaIngreso] datetime2 NOT NULL,
    [fechaEgreso] datetime2 NOT NULL,
    [fechaRetiro] datetime2 NOT NULL,
    [estadoid] int NULL,
    CONSTRAINT [PK_Estudiante] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Estudiante_TipoDocumento_TipoDocumentoid] FOREIGN KEY ([TipoDocumentoid]) REFERENCES [GET].[TipoDocumento] ([id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Estudiante_EstadoEstudiante_estadoid] FOREIGN KEY ([estadoid]) REFERENCES [GET].[EstadoEstudiante] ([id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [GET].[Profesor] (
    [id] int NOT NULL IDENTITY,
    [nombre] nvarchar(max) NULL,
    [apellido] nvarchar(max) NULL,
    [documento] nvarchar(450) NULL,
    [tipoDocumentoid] int NULL,
    [estadoid] int NULL,
    CONSTRAINT [PK_Profesor] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Profesor_EstadoProfesor_estadoid] FOREIGN KEY ([estadoid]) REFERENCES [GET].[EstadoProfesor] ([id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Profesor_TipoDocumento_tipoDocumentoid] FOREIGN KEY ([tipoDocumentoid]) REFERENCES [GET].[TipoDocumento] ([id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [GET].[EstudiantesXMateria] (
    [id] int NOT NULL IDENTITY,
    [estudianteid] int NULL,
    [materiaid] int NULL,
    [estadoid] int NULL,
    CONSTRAINT [PK_EstudiantesXMateria] PRIMARY KEY ([id]),
    CONSTRAINT [FK_EstudiantesXMateria_EstadoMateriaEstudiante_estadoid] FOREIGN KEY ([estadoid]) REFERENCES [GET].[EstadoMateriaEstudiante] ([id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EstudiantesXMateria_Estudiante_estudianteid] FOREIGN KEY ([estudianteid]) REFERENCES [GET].[Estudiante] ([id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EstudiantesXMateria_Materia_materiaid] FOREIGN KEY ([materiaid]) REFERENCES [GET].[Materia] ([id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [GET].[ProfesoresXMateria] (
    [id] int NOT NULL IDENTITY,
    [profesorid] int NULL,
    [materiaid] int NULL,
    CONSTRAINT [PK_ProfesoresXMateria] PRIMARY KEY ([id]),
    CONSTRAINT [FK_ProfesoresXMateria_Materia_materiaid] FOREIGN KEY ([materiaid]) REFERENCES [GET].[Materia] ([id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProfesoresXMateria_Profesor_profesorid] FOREIGN KEY ([profesorid]) REFERENCES [GET].[Profesor] ([id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Estudiante_TipoDocumentoid] ON [GET].[Estudiante] ([TipoDocumentoid]);

GO

CREATE UNIQUE INDEX [IX_Estudiante_documento] ON [GET].[Estudiante] ([documento]) WHERE [documento] IS NOT NULL;

GO

CREATE INDEX [IX_Estudiante_estadoid] ON [GET].[Estudiante] ([estadoid]);

GO

CREATE INDEX [IX_EstudiantesXMateria_estadoid] ON [GET].[EstudiantesXMateria] ([estadoid]);

GO

CREATE INDEX [IX_EstudiantesXMateria_estudianteid] ON [GET].[EstudiantesXMateria] ([estudianteid]);

GO

CREATE INDEX [IX_EstudiantesXMateria_materiaid] ON [GET].[EstudiantesXMateria] ([materiaid]);

GO

CREATE UNIQUE INDEX [IX_Materia_codigo] ON [GET].[Materia] ([codigo]) WHERE [codigo] IS NOT NULL;

GO

CREATE UNIQUE INDEX [IX_Profesor_documento] ON [GET].[Profesor] ([documento]) WHERE [documento] IS NOT NULL;

GO

CREATE INDEX [IX_Profesor_estadoid] ON [GET].[Profesor] ([estadoid]);

GO

CREATE INDEX [IX_Profesor_tipoDocumentoid] ON [GET].[Profesor] ([tipoDocumentoid]);

GO

CREATE INDEX [IX_ProfesoresXMateria_materiaid] ON [GET].[ProfesoresXMateria] ([materiaid]);

GO

CREATE INDEX [IX_ProfesoresXMateria_profesorid] ON [GET].[ProfesoresXMateria] ([profesorid]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220705063906_Inicial', N'2.1.14-servicing-32113');

GO

