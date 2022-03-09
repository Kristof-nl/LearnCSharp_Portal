using Data.Models;
using Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class SourceRepository : Repository<Source>, ISourceRepository
    {
        private readonly ApplicationDbContext _db;
        public SourceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Source obj)
        {
            _db.Sources.Update(obj);
        }
    }
}
