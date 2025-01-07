using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopitalConsoleMatmut.Model
{
    public class FileAttente
    {
        public List<Patient> Patients {  get; set; } = new List<Patient>();

        public FileAttente()
        {

        }  
    }
}
