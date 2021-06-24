using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LockStep.Library.Domain.Finance;

namespace LockStep.Library.Persistence.Repositories
{
    public class CheckRepository : GenericRepository<Check>, ICheckRepository
    {
        public CheckRepository(LibraryDbContext context) : base(context) { }
    }
}
