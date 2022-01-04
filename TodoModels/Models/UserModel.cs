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
        public string? Name { get; set; }
        
        [TableColumn]
        public string? Password { get; set; }
    }
}
