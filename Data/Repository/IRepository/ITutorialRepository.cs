using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.IRepository
{
    public interface ITutorialRepository : IRepository<Tutorial>
    {
        void Update(Tutorial obj);
    }
}
