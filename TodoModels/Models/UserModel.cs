using System.ComponentModel.DataAnnotations;

namespace TodoModels.Models
{
    internal class UserModel
    {
        public int? Id { get; set; }
        
        [DataType(DataType.Text)]
        [Required]
        [MaxLength(64)]
        public string? Name { get; set; }
        
        [DataType(DataType.Password)]
        [Required]
        [MaxLength(64)]
        public string? Password { get; set; }
    }
}
