using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace ReferenceBookApp.DataAccess.Entities
{
    public partial class Fact
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //label
        public string Text { get; set; }
        public int? FieldId { get; set; }
        public virtual Field Field { get; set; }
    }
}