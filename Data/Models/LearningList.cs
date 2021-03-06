using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class LearningList
    {
        public int Id { get; set; }
        public int TutorialId { get; set; }
        public Tutorial Tutorial { get; set; }
        public List<Tutorial> LearnedTutorials { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public List<Tutorial> ArchivedTutorials { get; set; }
    }
}
    