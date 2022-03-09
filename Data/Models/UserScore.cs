using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class UserScore
    {
        public int Id { get; set; }
        public double Score { get; set; }
        public Tutorial Tutorial { get; set; }
    }
}
