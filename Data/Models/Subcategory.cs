using System.ComponentModel.DataAnnotations;


namespace Data.Models
{
    public class Subcategory
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Category? Category { get; set; }

    }
}
