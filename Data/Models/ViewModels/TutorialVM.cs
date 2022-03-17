using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Data.Models.ViewModels
{
    public class TutorialVM
    {
        public Tutorial Tutorial { get; set; }
        //public double? UsersScore => (Tutorial.UserScores.Sum(score => score.Score) / Tutorial.UserScores.Count);
       
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> SubcategoryList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> SourceList { get; set; }

    }
}