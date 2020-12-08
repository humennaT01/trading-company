using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }      
        public bool Status { get; set; }        
        public int PersonID { get; set; }
        public int RoleID { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
    }
}