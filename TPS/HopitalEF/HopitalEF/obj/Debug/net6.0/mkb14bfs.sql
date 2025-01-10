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

