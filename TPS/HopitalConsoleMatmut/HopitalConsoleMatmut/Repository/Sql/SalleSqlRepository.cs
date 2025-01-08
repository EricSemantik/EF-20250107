using HopitalConsoleMatmut.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopitalConsoleMatmut.Repository.Sql
{
    public class SalleSqlRepository : ISalleRepository
    {
        public void Add(Salle entity)
        {
            // INSERT INTO [dbo].[Salles] (Nom, Dispo) VALUES(@Nom, @Dispo)
            throw new NotImplementedException();
        }

        public List<Salle> GetAll()
        {
            using (var connection = HopitalApplication.GetInstance().GetConnection())
            {
                connection.Open();
                //connection.ChangeDatabase("Hopital_ADO");
                SqlCommand commandeLecture = connection.CreateCommand();
                commandeLecture.CommandText = "SELECT Id, Nom, Dispo FROM [dbo].[Salles]";
                using (DbDataReader reader = commandeLecture.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Créer une salle à partir des données du Reader
                        // rajouter cette salle à la liste préalablement créé
                    }
                }
            }

            return null;
        }

        public List<Salle> GetAllDispo()
        {
            throw new NotImplementedException();
        }

        public Salle? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            // DELETE FROM [dbo].[Salles] WHERE Id = @Id
            throw new NotImplementedException();
        }

        public void Update(Salle entity)
        {
            // UPDATE [dbo].[Salles] SET Nom = @Nom, Dispo = @Dispo WHERE Id = @Id
            throw new NotImplementedException();
        }
    }
}
