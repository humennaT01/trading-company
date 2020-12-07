using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWPF.Models
{
    public class ShortUser
    {
        public int UserID { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }       
        public int PersonID { get; set; }
        public int RoleID { get; set; }
    }
}
