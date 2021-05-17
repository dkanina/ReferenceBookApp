using System.Threading.Tasks;
using ReferenceBookApp.Domain;
using ReferenceBookApp.Domain.Models.Update;

namespace ReferenceBookApp.BLL.Contracts
{
    public interface IFactCreateService
    {
        Task<Fact> CreateAsync(FactUpdateModel fact);
    }
}