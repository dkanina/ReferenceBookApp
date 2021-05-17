using System;
using System.Collections.Generic;
using System.Text;
using ReferenceBookApp.Domain.Contracts;

namespace ReferenceBookApp.Domain.Models.Identity
{
    public class FactIdentityModel : IFactIdentity
    {
        public int Id { get; }

        public FactIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}
