using Data.Models;
using Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class TutorialRepository : Repository<Tutorial>, ITutorialRepository
    {
        private readonly ApplicationDbContext _db;
        public TutorialRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Tutorial obj)
        {
            var objFromDb = _db.Tutorials.FirstOrDefault(x => x.Id == obj.Id);
            if (objFromDb != null)
            {
                //Explicity to avoid to update img URL
                objFromDb.Title = obj.Title;
                objFromDb.Author = obj.Author;
                objFromDb.Description = obj.Description;
                objFromDb.UserScores = obj.UserScores;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Category = obj.Category;
                objFromDb.SubcategoryId = obj.SubcategoryId;
                objFromDb.Subcategory = obj.Subcategory;
                if (objFromDb.ImgUrl != null)
                {
                    objFromDb.ImgUrl = obj.ImgUrl;
                }
            }
 
        }
    }
}
