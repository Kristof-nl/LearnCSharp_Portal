using Microsoft.AspNetCore.Mvc.Rendering;

namespace Data.Models.ViewModels
{
    public class TutorialVM
    {
        public Tutorial Tutorial { get; set; }
        public double? UsersScore => (Tutorial.UserScores.Sum(score => score.Score) / Tutorial.UserScores.Count);
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> SubcategoryList { get; set; }

    }
}