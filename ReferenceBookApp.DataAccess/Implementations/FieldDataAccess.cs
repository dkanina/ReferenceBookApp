using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReferenceBookApp.DataAccess.Context;
using ReferenceBookApp.DataAccess.Contracts;
using ReferenceBookApp.Domain;
using ReferenceBookApp.Domain.Contracts;

namespace ReferenceBookApp.DataAccess.Implementations
{
    public class FieldDataAccess : IFieldDataAccess
    {
        private ReferenceBookAppContext Context { get; }
        private IMapper Mapper { get; }

        public FieldDataAccess(ReferenceBookAppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }
        public async Task<Field> GetByAsync(IFieldContainer field)
        {
            return field.FieldId.HasValue
                ? this.Mapper.Map<Field>(await this.Context.Field.FirstOrDefaultAsync(x => x.Id == field.FieldId))
                : null;
        }
    }
}