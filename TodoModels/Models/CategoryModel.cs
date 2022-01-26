using DbAccess.Attributes;

namespace TodoModels.Models
{
    public class CategoryModel
    {
        [PrimaryKey]
        [TableColumn]
        public int? Id { get; set; } = null;

        [TableColumn]
        public string? Name { get; set; } = null;

        [TableColumn]
        public int? UserId { get; set; } = null;

        [TableColumn]
        public int? BaseCategoryId { get; set; } = null;
    }
}
