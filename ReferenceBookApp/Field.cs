using System;
using System.Collections.Generic;
using System.Text;

namespace ReferenceBookApp.Domain
{
    public class Field
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Field Parent { get; set; } //pField
    }
}
