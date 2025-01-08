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
            using (var connection = HopitalApplication.GetInstance().GetConnection())
            {
                connection.Open();
                SqlCommand commandeEcriture = connection.CreateCommand();
                commandeEcriture.CommandText = "INSERT INTO [dbo].[Salles] (Nom, Dispo) VALUES(@Nom, @Dispo)";

                //commandeEcriture.Parameters.AddWithValue("@Nom", entity.Nom); ;

                //commandeEcriture.Parameters.AddWithValue("@Dispo", entity.Dispo);

                var paramNom = commandeEcriture.CreateParameter();
                paramNom.DbType = System.Data.DbType.String;
                paramNom.ParameterName = "@Nom";
                paramNom.Value = entity.Nom;

                commandeEcriture.Parameters.Add(paramNom);

                var paramDispo = commandeEcriture.CreateParameter();
                paramDispo.DbType = System.Data.DbType.Boolean;
                paramDispo.ParameterName = "@Dispo";
                paramDispo.Value = entity.Dispo;
                
                commandeEcriture.Parameters.Add(paramDispo);

                int rows = commandeEcriture.ExecuteNonQuery();

               
            }
        }

        public List<Salle> GetAll()
        {
            List<Salle> list = new List<Salle>();
            using (var connection = HopitalApplication.GetInstance().GetConnection())
            {
                connection.Open();
                SqlCommand commandeLecture = connection.CreateCommand();
                commandeLecture.CommandText = "SELECT Id, Nom, Dispo FROM [dbo].[Salles]";
                
                
                using (DbDataReader reader = commandeLecture.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Salle salle = new Salle();
                        salle.Id = reader.GetInt32(0);
                        salle.Nom = reader.GetString(1);
                        salle.Dispo = reader.GetBoolean(2);

                        list.Add(salle);
                    }
                }
            }

            return list;
        }

        public List<Salle> GetAllDispo()
        {
            List<Salle> list = new List<Salle>();
            using (var connection = HopitalApplication.GetInstance().GetConnection())
            {
                connection.Open();
                SqlCommand commandeLecture = connection.CreateCommand();
                commandeLecture.CommandText = "SELECT Id, Nom, Dispo FROM [dbo].[Salles] WHERE Dispo = @Dispo";

                //var paramDispo = commandeLecture.CreateParameter();
                //paramDispo.DbType = System.Data.DbType.Boolean;
                //paramDispo.ParameterName = "@Dispo";
                //paramDispo.Value = true;

                //commandeLecture.Parameters.Add(paramDispo); 

                commandeLecture.Parameters.AddWithValue("@Dispo", true);

                using (DbDataReader reader = commandeLecture.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Salle salle = new Salle();
                        salle.Id = reader.GetInt32(0);
                        salle.Nom = reader.GetString(1);
                        salle.Dispo = reader.GetBoolean(2);

                        list.Add(salle);
                    }
                }
            }

            return list;
        }

        public Salle? GetById(int id)
        {
            using (var connection = HopitalApplication.GetInstance().GetConnection())
            {
                connection.Open();
                SqlCommand commandeLecture = connection.CreateCommand();
                commandeLecture.CommandText = "SELECT Nom, Dispo FROM [dbo].[Salles] WHERE Id = @Id";

                //var paramId = commandeLecture.CreateParameter();
                //paramId.DbType = System.Data.DbType.Int32;
                //paramId.ParameterName = "@Id";
                //paramId.Value = id;

                //commandeLecture.Parameters.Add(paramId);

                commandeLecture.Parameters.AddWithValue("@Id", id);

                using (DbDataReader reader = commandeLecture.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Salle salle = new Salle();
                        salle.Id = id;
                        salle.Nom = reader.GetString(0);
                        salle.Dispo = reader.GetBoolean(1);

                        return salle;
                    }
                }
            }

            return null;
        }

        public void Remove(int id)
        {
            // DELETE FROM [dbo].[Salles] WHERE Id = @Id
            using (var connection = HopitalApplication.GetInstance().GetConnection())
            {
                connection.Open();
                SqlCommand commandeEcriture = connection.CreateCommand();
                commandeEcriture.CommandText = "DELETE FROM [dbo].[Salles] WHERE Id = @Id";

                commandeEcriture.Parameters.AddWithValue("@Id", id); ;

                //var paramId = commandeEcriture.CreateParameter();
                //paramId.DbType = System.Data.DbType.Int32;
                //paramId.ParameterName = "@Id";
                //paramId.Value = id;

                //commandeEcriture.Parameters.Add(paramId);

                int rows = commandeEcriture.ExecuteNonQuery();
            }
        }

        public void Update(Salle entity)
        {
            using (var connection = HopitalApplication.GetInstance().GetConnection())
            {
                connection.Open();
                SqlCommand commandeEcriture = connection.CreateCommand();
                commandeEcriture.CommandText = "UPDATE [dbo].[Salles] SET Nom = @Nom, Dispo = @Dispo WHERE Id = @Id";

                commandeEcriture.Parameters.AddWithValue("@Nom", entity.Nom);

                commandeEcriture.Parameters.AddWithValue("@Dispo", entity.Dispo);

                commandeEcriture.Parameters.AddWithValue("@Id", entity.Id);

                //var paramNom = commandeEcriture.CreateParameter();
                //paramNom.DbType = System.Data.DbType.String;
                //paramNom.ParameterName = "@Nom";
                //paramNom.Value = entity.Nom;

                //commandeEcriture.Parameters.Add(paramNom);

                //var paramDispo = commandeEcriture.CreateParameter();
                //paramDispo.DbType = System.Data.DbType.Boolean;
                //paramDispo.ParameterName = "@Dispo";
                //paramDispo.Value = entity.Dispo;

                //commandeEcriture.Parameters.Add(paramDispo);

                //var paramId = commandeEcriture.CreateParameter();
                //paramId.DbType = System.Data.DbType.Int32;
                //paramId.ParameterName = "@Id";
                //paramId.Value = entity.Id;

                //commandeEcriture.Parameters.Add(paramId);

                int rows = commandeEcriture.ExecuteNonQuery();
            }
        }
    }
}
