using HopitalConsoleMatmut.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopitalConsoleMatmut.Repository
{
    public interface IEmployeRepository: IRepository<Employe, int>
    {
        List<Medecin> GetAllMedecin();

        List<Secretaire> GetAllSecretaire();

        Employe? Authentification(string login, string motDePasse);

    }
}
