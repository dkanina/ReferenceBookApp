using System.Threading.Tasks;
using ReferenceBookApp.BLL.Contracts;
using ReferenceBookApp.DataAccess.Contracts;
using ReferenceBookApp.Domain;
using ReferenceBookApp.Domain.Models.Update;

namespace ReferenceBookApp.BLL.Implementation
{
    public class FactCreateService : IFactCreateService
    {
        private IFactDataAccess FactDataAccess { get; }
        private IFieldGetService FieldGetService { get; }

        public FactCreateService(IFactDataAccess factDataAccess, IFieldGetService fieldGetService)
        {
            this.FactDataAccess = factDataAccess;
            this.FieldGetService = fieldGetService;
        }
        public async Task<Fact> CreateAsync(FactUpdateModel fact)
        {
            await this.FieldGetService.ValidateAsync(fact);
            return await this.FactDataAccess.InsertAsync(fact);
        }
    }
}