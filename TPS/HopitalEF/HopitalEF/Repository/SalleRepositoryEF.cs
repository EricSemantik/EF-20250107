using HopitalEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopitalEF.Repository
{
    public class SalleRepositoryEF : ISalleRepository
    {
        private HopitalEFContext _context;

        public SalleRepositoryEF(HopitalEFContext context) { 
            _context = context;
        }

        public void Add(Salle entity)
        {
            _context.Add(entity);
        }

        public List<Salle> GetAll()
        {
            return _context.Salles.ToList();
        }

        public List<Salle> GetAllDispo()
        {
            return _context.Salles.Where(s => s.Dispo == true).ToList();
        }

        public Salle? GetById(int id)
        {
            return _context.Salles.Where(s => s.Id == id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            var salle = GetById(id);

            if (salle != null)
            {
                _context.Salles.Remove(salle);
            }
        }

        public void Update(Salle entity)
        {
            _context.Salles.Update(entity);
        }
    }
}
