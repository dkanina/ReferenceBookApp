using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReferenceBookApp.DataAccess.Entities
{
    public partial class Field
    {
        public Field()
        {
            this.Fact = new HashSet<Fact>();
            this.InverseParent = new HashSet<Field>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public virtual Field Parent { get; set; }
        public virtual ICollection<Fact> Fact { get; set; }
        public virtual ICollection<Field> InverseParent { get; set; }
    }
}