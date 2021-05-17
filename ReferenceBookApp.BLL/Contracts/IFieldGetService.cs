using System.Threading.Tasks;
using ReferenceBookApp.Domain.Contracts;

namespace ReferenceBookApp.BLL.Contracts
{
    public interface IFieldGetService
    {
        Task ValidateAsync(IFieldContainer fieldContainer);
    }
}