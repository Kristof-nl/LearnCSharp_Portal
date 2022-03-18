using Data.Models;
using Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ArchivedTutorialsRepository : Repository<ArchivedTutorials>, IArchivedTutorialsRepository
    {
        private readonly ApplicationDbContext _db;
        public ArchivedTutorialsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //public void Update(ArchivedTutorials obj)
        //{
        //    _db.ArchivedTutorials.Update(obj);
        //}
    }
}
