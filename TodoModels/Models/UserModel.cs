using DbAccess.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TodoModels.Models
{
    public class UserModel
    {
        [PrimaryKey]
        [TableColumn]
        public int? Id { get; set; }
        
        [TableColumn]
        [DataType(DataType.Text)]
        [Required]
        [MaxLength(64)]
        public string? Name { get; set; }
        
        [TableColumn]
        [DataType(DataType.Password)]
        [Required]
        [MaxLength(64)]
        public string? Password { get; set; }
    }
}
