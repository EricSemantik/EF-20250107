using HopitalConsoleMatmut.Exception;
using HopitalConsoleMatmut.Model;

namespace HopitalConsoleMatmut.Repository.Memory
{
    public class SalleMemoryRepository : ISalleRepository
    {
        private List<Salle> _data;
        private int _nextId = 1;

        public SalleMemoryRepository()
        {
            _data = new List<Salle>()
            {
                new Salle { Id=_nextId++, Nom="Salle 1", Dispo= true },
                new Salle { Id=_nextId++, Nom="Salle 2", Dispo= true }
            };
        }

        public void Add(Salle entity)
        {
            entity.Id = _nextId++;
            _data.Add(entity);
        }

        public List<Salle> GetAll()
        {
            return this._data;
        }

        public List<Salle> GetAllDispo()
        {
            return this._data.FindAll(item => item.Dispo == true);
        }

        public Salle? GetById(int id)
        {
            //foreach(Salle item in _data)
            //{
            //    if(item.Id == id)
            //    {
            //        return item;
            //    }
            //}

            var entity = this._data.FirstOrDefault(item => item.Id == id);

            if(entity == null)
            {
                throw new HopitalPersistenceException($"L'identifiant {id} de la Salle est introuvable");
            }

            return entity;
        }

        public void Remove(int id)
        {
            int position = this._data.FindIndex(item => item.Id == id);
            if (position != -1)
            {
                _data.RemoveAt(position);
            }
        }

        public void Update(Salle entity)
        {
            int position = this._data.FindIndex(item => item.Id == entity.Id);
            if (position != -1)
            {
                _data[position] = entity;
            }
        }
    }
}
