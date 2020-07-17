using System.ComponentModel.DataAnnotations;

namespace Demo.Dtos{
    public class ProductInsertDto{
        
        [Required]
        [MaxLength(100)]
        public string name { get; set; }
        
        [MaxLength(200)]
        public string description { get; set; }
    }
}