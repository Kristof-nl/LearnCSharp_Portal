using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Tutorial
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Description { get; set; }
        [ValidateNever]
        public string ImgUrl { get; set; }
        [Required]
        public string Link { get; set; }
        public ICollection<UserScore>? UserScores { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }
        [Required]
        public int SubcategoryId { get; set; }
        [ValidateNever]
        public Subcategory Subcategory { get; set; }
        [Required]
        public int SourceId { get; set; }
        [ValidateNever]
        public Source Source { get; set; }
    }
}
