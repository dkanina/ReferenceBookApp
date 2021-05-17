using System.Collections.Generic;
using System.Threading.Tasks;
using ReferenceBookApp.Domain;
using ReferenceBookApp.Domain.Contracts;

namespace ReferenceBookApp.BLL.Contracts
{
    public interface IFactGetService
    {
        Task<IEnumerable<Fact>> GetAsync();
        Task<Fact> GetAsync(IFactIdentity fact);
    }
}