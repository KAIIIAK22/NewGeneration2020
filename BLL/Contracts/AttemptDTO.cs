using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    public class AttemptDTO
    {
        public string NickOrEmail { get; set; }
        public string IpAddress { get; set; }
        public bool IsSuccess { get; set; }
    }
}
