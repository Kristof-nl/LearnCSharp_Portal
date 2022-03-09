using Data.Models;
using Data.Repository.IRepository;

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
