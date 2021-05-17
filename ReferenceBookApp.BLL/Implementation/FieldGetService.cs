using System;
using System.Threading.Tasks;
using ReferenceBookApp.BLL.Contracts;
using ReferenceBookApp.DataAccess.Contracts;
using ReferenceBookApp.Domain;
using ReferenceBookApp.Domain.Contracts;

namespace ReferenceBookApp.BLL.Implementation
{
    public class FieldGetService : IFieldGetService
    {
        private IFieldDataAccess FieldDataAccess { get; }

        public FieldGetService(IFieldDataAccess fieldDataAccess)
        {
            this.FieldDataAccess = fieldDataAccess;
        }
        
        public async Task ValidateAsync(IFieldContainer fieldContainer)
        {
            if (fieldContainer == null)
            {
                throw new ArgumentNullException(nameof(fieldContainer));
            }

            var field = await this.GetBy(fieldContainer);

            if (fieldContainer.FieldId.HasValue && field == null)
            {
                throw new InvalidOperationException($"Field not found by id {fieldContainer.FieldId}");
            }
        }

        private async Task<Field> GetBy(IFieldContainer fieldContainer)
        {
            return await this.FieldDataAccess.GetByAsync(fieldContainer);
        }
    }
}
