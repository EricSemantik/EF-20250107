using HopitalEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopitalEF.Repository
{
    public interface ISalleRepository: IRepository<Salle, int>
    {
        public List<Salle> GetAllDispo();
        
    }
}
