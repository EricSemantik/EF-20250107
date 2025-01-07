using HopitalConsoleMatmut.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopitalConsoleMatmut.Repository
{
    public interface IPatientRepository: IRepository<Patient, int>
    {
    }
}
