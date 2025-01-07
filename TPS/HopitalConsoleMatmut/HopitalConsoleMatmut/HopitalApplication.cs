using HopitalConsoleMatmut.Repository.Memory;
using HopitalConsoleMatmut.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HopitalConsoleMatmut.Model;

namespace HopitalConsoleMatmut
{
    public class HopitalApplication
    {
        private static HopitalApplication? _instance = null;

        public IConsultationRepository ConsultationRepo { get; } = new ConsultationMemoryRepository();
        public IEmployeRepository EmployeRepo { get; } = new EmployeMemoryRepository();
        public IPatientRepository PatientRepo { get; } = new PatientMemoryRepository();
        public ISalleRepository SalleRepo { get; } = new SalleFileRepository(@"C:\Users\eric\Documents\Cours C#\salles.csv");
        public FileAttente FileAttente { get; } = new FileAttente();

        private HopitalApplication() { }

        public static HopitalApplication GetInstance()
        {
            if(_instance == null)
            {
                _instance = new HopitalApplication();
            }

            return _instance;
        }
    }
}
