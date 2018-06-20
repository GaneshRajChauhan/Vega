using System.Threading.Tasks;
using Vega.Core;
using Vega.persistance;

namespace Vega.persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VegaDbContext context;
        public UnitOfWork(VegaDbContext context)
        {
            this.context = context;

        }
        public async Task CompleteAsync()
        {
          await  context.SaveChangesAsync();
        }
    }
}