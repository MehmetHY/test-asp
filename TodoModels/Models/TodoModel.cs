using DbAccess.Attributes;

namespace TodoModels.Models
{
    public class TodoModel
    {
        [PrimaryKey]
        [TableColumn]
        public int? Id { get; set; }

        [TableColumn]
        public string? Title { get; set; }

        [TableColumn]
        public string? Description { get; set; }

        [TableColumn]
        public int? CategoryId { get; set; }
        
        [TableColumn]
        public int? UserId { get; set; }

        [TableColumn]
        public int? State { get; set; }

        [TableColumn]
        public int? Index { get; set; }
    }
}
