using Data.Models;
using Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserScoreRepository : Repository<UserScore>, IUserScoreRepository
    {
        private readonly ApplicationDbContext _db;
        public UserScoreRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

   
    }
}
