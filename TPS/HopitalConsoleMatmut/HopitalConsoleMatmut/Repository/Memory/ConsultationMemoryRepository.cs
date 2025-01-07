using HopitalConsoleMatmut.Model;

namespace HopitalConsoleMatmut.Repository.Memory
{
    public class ConsultationMemoryRepository : IConsultationRepository
    {
        private List<Consultation> _data;
        private int _nextId = 1;

        public ConsultationMemoryRepository()
        {
            _data = new List<Consultation>()
            {
                
            };
        }

        public void Add(Consultation entity)
        {
            entity.Id = _nextId++;
            _data.Add(entity);
        }

        public List<Consultation> GetAll()
        {
            return this._data;
        }

        public List<Consultation> GetAllByPatient(int idPatient)
        {
            return this._data.FindAll(item => item.Patient.Id == idPatient);
        }

        public Consultation? GetById(int id)
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

        public void Update(Consultation entity)
        {
            int position = this._data.FindIndex(item => item.Id == entity.Id);
            if (position != -1)
            {
                _data[position] = entity;
            }
        }
    }
}
