using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Categorey
    {

        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string Name { get; set; }
        [MinLength(10)]
        public string Description { get; set; }
    }
}
