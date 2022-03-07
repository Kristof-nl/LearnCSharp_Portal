using Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Subcategory = new SubcategoryRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }
        public ISubcategoryRepository Subcategory { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
