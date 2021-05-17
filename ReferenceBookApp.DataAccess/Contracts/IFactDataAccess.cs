using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReferenceBookApp.Domain;
using ReferenceBookApp.Domain.Contracts;
using ReferenceBookApp.Domain.Models.Update;

namespace ReferenceBookApp.DataAccess.Contracts
{
    public interface IFactDataAccess
    {
        Task<Fact> InsertAsync(FactUpdateModel fact);
        Task<IEnumerable<Fact>> GetAsync();
        Task<Fact> GetAsync(IFactIdentity factId);
        Task<Fact> UpdateAsync(FactUpdateModel fact);
    }
}