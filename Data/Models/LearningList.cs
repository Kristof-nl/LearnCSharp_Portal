using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class LearningList
    {
        public int Id { get; set; }
        public IEnumerable<Tutorial> Tutorials { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
    