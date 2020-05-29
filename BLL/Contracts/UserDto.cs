using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    public class UserDto
    {

        public int UserId { get; set; }
        public string UserNick { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public List<Role> UserRole { get; set; }
    }
}
