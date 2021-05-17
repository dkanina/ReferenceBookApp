using System;
using System.Collections.Generic;
using System.Text;
using ReferenceBookApp.Domain.Contracts;

namespace ReferenceBookApp.Domain.Models.Update
{
    public class FactUpdateModel : IFactIdentity, IFieldContainer
    {
        public int Id { get; set; } //label
        
        public string Text { get; set; }
        public int? FieldId { get; }
    }
}
