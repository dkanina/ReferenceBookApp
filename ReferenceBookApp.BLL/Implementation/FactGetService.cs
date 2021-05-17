using System.Collections.Generic;
using System.Threading.Tasks;
using ReferenceBookApp.BLL.Contracts;
using ReferenceBookApp.DataAccess.Contracts;
using ReferenceBookApp.Domain;
using ReferenceBookApp.Domain.Contracts;

namespace ReferenceBookApp.BLL.Implementation
{
    public class FactGetService : IFactGetService
    {
        private IFactDataAccess FactDataAccess { get; }

        public FactGetService(IFactDataAccess factDataAccess)
        {
            this.FactDataAccess = factDataAccess;
        }
        public Task<IEnumerable<Fact>> GetAsync()
        {
            return this.FactDataAccess.GetAsync();
        }

        public Task<Fact> GetAsync(IFactIdentity fact)
        {
            return this.FactDataAccess.GetAsync(fact);
        }
    }
}