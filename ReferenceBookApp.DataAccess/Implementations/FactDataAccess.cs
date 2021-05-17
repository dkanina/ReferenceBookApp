using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReferenceBookApp.DataAccess.Context;
using ReferenceBookApp.DataAccess.Contracts;
using ReferenceBookApp.DataAccess.Entities;
using ReferenceBookApp.Domain.Contracts;
using ReferenceBookApp.Domain.Models.Update;
using Field = ReferenceBookApp.Domain.Field;

namespace ReferenceBookApp.DataAccess.Implementations
{
    public class FactDataAccess : IFactDataAccess
    {
        private ReferenceBookAppContext Context { get; }
        private IMapper Mapper { get; }

        public FactDataAccess(ReferenceBookAppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }
        public async Task<Domain.Fact> InsertAsync(FactUpdateModel fact)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Fact>(fact));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Domain.Fact>(result.Entity);
        }

        public async Task<IEnumerable<Domain.Fact>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Domain.Fact>>(
                await this.Context.Fact.Include(x => x.Field).ToListAsync());
        }

        public async Task<Domain.Fact> GetAsync(IFactIdentity fact)
        {
            var result = await this.Get(fact);

            return this.Mapper.Map<Domain.Fact>(result);
        }

        private async Task<Fact> Get(IFactIdentity fact)
        {
            if (fact == null)
            {
                throw new ArgumentNullException(nameof(fact));
            }

            return await this.Context.Fact.Include(x => x.Field).FirstOrDefaultAsync(x => x.Id == fact.Id);
        }


        public async Task<Domain.Fact> UpdateAsync(FactUpdateModel fact)
        {
            var existing = await this.Get(fact);

            var result = this.Mapper.Map(fact, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Domain.Fact>(result);

        }
    }
}