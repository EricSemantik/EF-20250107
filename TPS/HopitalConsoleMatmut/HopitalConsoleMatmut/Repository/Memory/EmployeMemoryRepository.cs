using HopitalConsoleMatmut.Model;

namespace HopitalConsoleMatmut.Repository.Memory
{
    public class EmployeMemoryRepository : IEmployeRepository
    {
        private List<Employe> _data;
        private int _nextId = 1;

        public EmployeMemoryRepository()
        {
            _data = new List<Employe>()
            {
                new Medecin { Id=_nextId++, Civilite=Civilite.M, Nom="GUILLIER", Prenom="Simon", Login="SIMONG", MotDePasse="azerty"},
                new Medecin { Id=_nextId++, Civilite=Civilite.M, Nom="COLAS", Prenom="Anthony", Login="ANTHONYC", MotDePasse="azerty"},
                new Secretaire { Id=_nextId++, Civilite=Civilite.M, Nom="SULTAN", Prenom="Eric", Login="ERICS", MotDePasse="azerty"}
            };
        }

        public void Add(Employe entity)
        {
            entity.Id = _nextId++;
            _data.Add(entity);
        }

        public Employe? Authentification(string login, string motDePasse)
        {
            return this._data.Find(item => item.Login == login && item.MotDePasse == motDePasse);
        }

        public List<Employe> GetAll()
        {
            return this._data;
        }

        public List<Medecin> GetAllMedecin()
        {
            List<Medecin> liste = new List<Medecin>();

            foreach (Employe item in _data)
            {
                if(item is Medecin)
                {
                    liste.Add((Medecin)item);
                }
            }

            return liste;
        }

        public List<Secretaire> GetAllSecretaire()
        {
            List<Secretaire> liste = new List<Secretaire>();

            foreach (Employe item in _data)
            {
                if (item is Secretaire)
                {
                    liste.Add((Secretaire)item);
                }
            }

            return liste;
        }

        public Employe? GetById(int id)
        {
            return this._data.FirstOrDefault(item => item.Id == id);

        }

        public void Remove(int id)
        {
            int position = this._data.FindIndex(item => item.Id == id);
            if (position != -1)
            {
                _data.RemoveAt(position);
            }
        }

        public void Update(Employe entity)
        {
            int position = this._data.FindIndex(item => item.Id == entity.Id);
            if (position != -1)
            {
                _data[position] = entity;
            }
        }
    }
}
