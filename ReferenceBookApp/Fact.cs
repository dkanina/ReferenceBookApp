using System;
using System.Collections.Generic;
using System.Text;
using ReferenceBookApp.Domain.Contracts;

namespace ReferenceBookApp.Domain
{
    public class Fact : IFieldContainer
    {
        public int Id { get; set; } //label

        public string Text { get; set; }
        
        public Field Field { get; set; }
        
        //public DateTime Date { get; set; } fields
        int? IFieldContainer.FieldId => this.Field.Id;
    }
}
