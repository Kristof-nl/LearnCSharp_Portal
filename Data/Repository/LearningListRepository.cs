using Data.Models;
using Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class LearningListRepository : Repository<LearningList>, ILearningListRepository
    {
        private readonly ApplicationDbContext _db;
        public LearningListRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //public void Update(LearningList obj)
        //{
        //    _db.LearningLists.Update(obj);
        //}
    }
}
