using System.Threading.Tasks;
using ReferenceBookApp.BLL.Contracts;
using ReferenceBookApp.DataAccess.Contracts;
using ReferenceBookApp.Domain;
using ReferenceBookApp.Domain.Models.Update;

namespace ReferenceBookApp.BLL.Implementation
{
    public class FactUpdateService : IFactUpdateService
    {
        private IFactDataAccess FactDataAccess { get; }
        private IFieldGetService FieldGetService { get; }

        public FactUpdateService(IFactDataAccess factDataAccess, IFieldGetService fieldGetService)
        {
            this.FactDataAccess = factDataAccess;
            this.FieldGetService = fieldGetService;
        }
        public async Task<Fact> UpdateAsync(FactUpdateModel fact)
        {
            await this.FieldGetService.ValidateAsync(fact);
            return await this.FactDataAccess.UpdateAsync(fact);
        }
    }
}