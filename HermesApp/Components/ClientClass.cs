using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermesApp.Components
{
    public class ClientClass
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateLastVisit { get; set; }
        public int CountVisits { get; set; }
        public ClientClass() { }
    }
}
