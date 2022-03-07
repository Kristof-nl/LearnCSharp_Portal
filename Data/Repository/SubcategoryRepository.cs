using Data.Models;
using Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class SubcategoryRepository : Repository<Subcategory>, ISubcategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public SubcategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Subcategory> GetAllSubcategories(int id)
        {
            IQueryable<Subcategory> query = _db.Subcategories;
            query = query.Where(x => x.Category.Id == id);
            return query;
        }

        public void Update(Subcategory obj)
        {
            _db.Subcategories.Update(obj);
        }
    }
}
