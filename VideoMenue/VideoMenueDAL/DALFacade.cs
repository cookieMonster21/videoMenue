using VideoMenueDAL.Repostiories;
using VideoMenueDAL.UOW;

namespace VideoMenueDAL
{
    public class DALFacade
    {
        public IVideoRepository VideoRepository
        {
            get { return new VideoRepositoryEFMemory(new Context.InMemoryContext()); }
        }

        public IUnitOfWork UnitOfWork
        {
            get { return new UnitOfWorkMem(); }
        }
    }
}
