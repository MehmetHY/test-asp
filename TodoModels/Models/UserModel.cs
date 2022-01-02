using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoModels.Models
{
    public class UserModel
    {
        [Key]
        public int? Id { get; set; }
        
        [DataType(DataType.Text)]
        [Required]
        [MaxLength(64)]
        public string? Name { get; set; }
        
        [DataType(DataType.Password)]
        [Required]
        [MaxLength(64)]
        public string? Password { get; set; }

        public IEnumerable<CategoryModel>? Categories { get; set; }
    }
}
