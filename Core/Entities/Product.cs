using System.ComponentModel.DataAnnotations;

namespace restful_api.Core.Entities
{
    /// <summary>
    /// Represents a product entity in the system.
    /// </summary>
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }  

    }
}
