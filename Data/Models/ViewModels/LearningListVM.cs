using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.ViewModels
{
    public class LearningListVM
    {
        public int Id { get; set; }
        public int TutorialId { get; set; }
        public Tutorial Tutorial { get; set; }
        public List<Tutorial> LearnedTutorials { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<Tutorial> ArchivedTutorials { get; set; }
        public double Score => (Tutorial.UserScores.Sum(x => x.Score)) / Tutorial.UserScores.Count;

    }
}
