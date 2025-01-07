-- Cr�ation des tables de la database Hopital_ADO
USE Hopital_ADO;
GO

-- Effacement de toutes les tables
IF OBJECT_ID(N'[dbo].[Salles]', 'U') IS NOT NULL
    DROP TABLE [dbo].Salles;
GO

-- Cr�ation de toutes les tables
CREATE TABLE [dbo].[Salles](
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Nom nvarchar(50) NOT NULL, 
	Dispo bit);
	GO


-- Cr�ation de quelques enregistrements
INSERT INTO [dbo].[Salles] (Nom,Dispo) VALUES('Salle Indigo', 1);
INSERT INTO [dbo].[Salles] (Nom,Dispo) VALUES('Salle Jaune', 1);
INSERT INTO [dbo].[Salles] (Nom,Dispo) VALUES('Salle Verte', 0);
