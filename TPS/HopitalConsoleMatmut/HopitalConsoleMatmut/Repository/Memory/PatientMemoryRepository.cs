using HopitalConsoleMatmut.Model;

namespace HopitalConsoleMatmut.Repository.Memory
{
    public class PatientMemoryRepository : IPatientRepository
    {
        private List<Patient> _data;
        private int _nextId = 1;

        public PatientMemoryRepository()
        {
            _data = new List<Patient>()
            {
                new Patient { Id=_nextId++, Civilite=Civilite.M, Nom="DUPONT", Prenom="Pierre", NumeroSS="15454515481157", MedecinTraitant="AFTERSICK"},
                new Patient { Id=_nextId++, Civilite=Civilite.MME, Nom="PANOT", Prenom="Mathilde", NumeroSS="245415154151", MedecinTraitant="BEFORESICK" }
            };
        }

        public void Add(Patient entity)
        {
            entity.Id = _nextId++;
            _data.Add(entity);
        }

        public List<Patient> GetAll()
        {
            return this._data;
        }

        public Patient? GetById(int id)
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

        public void Update(Patient entity)
        {
            int position = this._data.FindIndex(item => item.Id == entity.Id);
            if (position != -1)
            {
                _data[position] = entity;
            }
        }
    }
}
