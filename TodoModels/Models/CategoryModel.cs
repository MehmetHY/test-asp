using DbAccess.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TodoModels.Models
{
    public class CategoryModel
    {
        [PrimaryKey]
        public int? Id { get; set; } = null;

        [TableColumn]
        public string? Name { get; set; } = null;

        [TableColumn]
        public int? UserId { get; set; } = null;
    }
}
