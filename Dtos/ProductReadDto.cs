using System.ComponentModel.DataAnnotations;

namespace Demo.Dtos{
    public class ProductReadDto{
        
        [Key]
        public int id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string name { get; set; }
        
        [MaxLength(200)]
        public string description { get; set; }
    }
}