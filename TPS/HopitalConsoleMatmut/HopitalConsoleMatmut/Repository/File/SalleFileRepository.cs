using HopitalConsoleMatmut.Exception;
using HopitalConsoleMatmut.Model;
using System.Text;

namespace HopitalConsoleMatmut.Repository.Memory
{
    public class SalleFileRepository : ISalleRepository
    {
        private string _fileName;

        public SalleFileRepository(string fileName)
        {
            _fileName = fileName;
        }

        public void Add(Salle entity)
        {
            var read = readAll();

            entity.Id = read.max+1;

            read.list.Add(entity);

            WriteAll(read.list);
        }

        public List<Salle> GetAll()
        {
            return readAll().list;
        }

        public List<Salle> GetAllDispo()
        {
            return readAll().list.FindAll(item => item.Dispo == true);
        }

        public Salle? GetById(int id)
        {
            var entity = readAll().list.FirstOrDefault(item => item.Id == id);

            if(entity == null)
            {
                throw new HopitalPersistenceException($"L'identifiant {id} de la Salle est introuvable");
            }

            return entity;
        }

        public void Remove(int id)
        {
            var salles = readAll().list;
            int position = salles.FindIndex(item => item.Id == id);
            if (position != -1)
            {
                salles.RemoveAt(position);
            }
            WriteAll(salles);
        }

        public void Update(Salle entity)
        {
            var salles = readAll().list;
            int position = salles.FindIndex(item => item.Id == entity.Id);
            if (position != -1)
            {
                salles[position] = entity;
            }

            WriteAll(salles);
        }

        private (List<Salle> list, int max) readAll()
        {
            var list = new List<Salle>();
            int maxId = 0;
            if (File.Exists(_fileName))
            {
                using (var stream = new StreamReader(_fileName))
                {
                    while (!stream.EndOfStream)
                    {
                        string line = stream.ReadLine();

                        string[] items = line.Split(";", StringSplitOptions.None);
                        int id = int.Parse(items[0]);
                        string nom = items[1];
                        bool dispo = items[2] == "O" ? true : false;
                        int? idMedecin = !string.IsNullOrEmpty(items[3]) ? int.Parse(items[3]) : null;

                        Salle salle = new Salle() { Id = id, Nom = nom, Dispo = dispo };
                        if (idMedecin != null)
                        {
                            Medecin medecin = (Medecin)HopitalApplication.GetInstance().EmployeRepo.GetById((int)idMedecin);

                            salle.Medecin = medecin;
                        }

                        if (id > maxId)
                        {
                            maxId = id;
                        }

                        list.Add(salle);
                    }
                }
            }

            return (list, maxId);
        }

        private void WriteAll(List<Salle> list)
        {
            FileStream stream = new FileStream(_fileName, FileMode.Create);
            using (var writer = new StreamWriter(stream, Encoding.UTF8))
            {
                foreach(Salle salle in list)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(salle.Id).Append(";");
                    sb.Append(salle.Nom).Append(";");
                    sb.Append(salle.Dispo?"O":"N").Append(";");
                    if(salle.Medecin != null && salle.Medecin.Id != null) {
                        sb.Append(salle.Medecin.Id);
                    }

                    writer.WriteLine(sb.ToString());
                }
            }
            stream.Dispose();
        }
    }
}
