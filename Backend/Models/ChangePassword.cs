using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class ChangePassword
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }       
        public string ConfirmPassword { get; set; }
    }
}