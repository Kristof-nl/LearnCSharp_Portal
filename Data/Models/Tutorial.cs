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
        public string ImgUrl { get; set; }

        public ICollection<UserScore> UserScores { get; set; }
        [NotMapped]
        public double UsersScore => UserScores.Sum(score => score.Score)/ UserScores.Count;
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public int SubcategoryId { get; set; }
        public Subcategory Subcategory { get; set; }


    }
}
