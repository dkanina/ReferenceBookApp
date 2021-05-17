using System.Threading.Tasks;
using ReferenceBookApp.Domain;
using ReferenceBookApp.Domain.Contracts;

namespace ReferenceBookApp.DataAccess.Contracts
{
    public interface IFieldDataAccess
    {
        Task<Field> GetByAsync(IFieldContainer fieldId);
    }
}