using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        ISubcategoryRepository Subcategory { get; }
        ITutorialRepository Tutorial { get; }
        ISourceRepository Source { get; }
        IApplicationUserRepository ApplicationUser { get; }
        ILearningListRepository LearningList { get; }
        IUserScoreRepository UserScore { get; }

        void Save();
    }
}
