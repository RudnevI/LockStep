using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LockStep.Library.Domain.Finance;

namespace LockStep.Library.Persistence.Repositories
{
    public class PriceRepository : GenericRepository<Price>, IPriceRepository
    {
        public PriceRepository(LibraryDbContext context) : base(context) { }
    }
}
