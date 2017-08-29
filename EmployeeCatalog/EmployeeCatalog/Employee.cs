using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCatalog
{
    public class Employee
    {
        public int id { set; get; }
        public string surname { set; get; }
        public string name { set; get; }
        public string patronymic { set; get; }
        public string position { set; get; }
        public string admission { set; get; }
        public string dismissal { set; get; }
        public string photo { set; get; }
    }
}
