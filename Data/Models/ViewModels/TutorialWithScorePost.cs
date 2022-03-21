using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Data.Models.ViewModels
{
    public class TutorialWithScorePostVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public string Link { get; set; }
        public ICollection<UserScore>? UserScores { get; set; }
        public int Score { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int SubcategoryId { get; set; }
        public Subcategory Subcategory { get; set; }
        public int SourceId { get; set; }
        public Source Source { get; set; }

    }
}