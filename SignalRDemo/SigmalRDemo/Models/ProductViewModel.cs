using System.ComponentModel.DataAnnotations;

namespace SigmalRDemo.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Range(0.01, 10000)]
        public decimal? Price { get; set; }

        [Range(1, 100)]
        public int? Quantity { get; set; }
    }
}
