using Postgrest.Attributes;
using Postgrest.Models;

namespace XamarinFormsTodo.Models
{
    [Table("todos")]
    public class TodoItem : BaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        [Column("done")]
        public bool Done { get; set; }
    }
}
