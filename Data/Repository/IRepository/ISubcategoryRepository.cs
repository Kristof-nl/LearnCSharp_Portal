using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.IRepository
{
    public interface ISubcategoryRepository : IRepository<Subcategory>
    {
        void Update(Subcategory obj);
        IEnumerable<Subcategory> GetAllSubcategories(int id);
    }
}

