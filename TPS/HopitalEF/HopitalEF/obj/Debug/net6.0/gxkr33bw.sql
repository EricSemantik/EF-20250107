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

CREATE TABLE [consultation] (
    [Id] int NOT NULL IDENTITY,
    [DtConsultation] datetime2 NOT NULL,
    [Motif] nvarchar(max) NOT NULL,
    [CompteRendu] nvarchar(max) NULL,
    [Tarif] real NOT NULL,
    CONSTRAINT [PK_consultation] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [personne] (
    [Id] int NOT NULL IDENTITY,
    [Civilite] int NULL,
    [Nom] nvarchar(max) NOT NULL,
    [Prenom] nvarchar(max) NOT NULL,
    [type] nvarchar(max) NOT NULL,
    [Login] nvarchar(max) NULL,
    [MotDePasse] nvarchar(max) NULL,
    [Pause] bit NULL,
    [NumeroSS] nvarchar(max) NULL,
    [MedecinTraitant] nvarchar(max) NULL,
    CONSTRAINT [PK_personne] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [salle] (
    [Id] int NOT NULL IDENTITY,
    [Nom] nvarchar(max) NOT NULL,
    [Dispo] bit NOT NULL,
    CONSTRAINT [PK_salle] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250109132808_Initial', N'7.0.20');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [salle] ADD [MedecinId] int NULL;
GO

CREATE UNIQUE INDEX [IX_salle_MedecinId] ON [salle] ([MedecinId]) WHERE [MedecinId] IS NOT NULL;
GO

ALTER TABLE [salle] ADD CONSTRAINT [FK_salle_personne_MedecinId] FOREIGN KEY ([MedecinId]) REFERENCES [personne] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250109133534_SalleMedecin', N'7.0.20');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [consultation] ADD [MedecinId] int NULL;
GO

CREATE INDEX [IX_consultation_MedecinId] ON [consultation] ([MedecinId]);
GO

ALTER TABLE [consultation] ADD CONSTRAINT [FK_consultation_personne_MedecinId] FOREIGN KEY ([MedecinId]) REFERENCES [personne] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250109133738_ConsultationMedecin', N'7.0.20');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [consultation] ADD [PatientId] int NULL;
GO

CREATE INDEX [IX_consultation_PatientId] ON [consultation] ([PatientId]);
GO

ALTER TABLE [consultation] ADD CONSTRAINT [FK_consultation_personne_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [personne] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250109133859_ConsultationPatient', N'7.0.20');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250109150747_MaMigration', N'7.0.20');
GO

COMMIT;
GO

