using VideoMenueDAL.Context;
using VideoMenueDAL.Repostiories;

namespace VideoMenueDAL.UOW
{
    public class UnitOfWorkMem : IUnitOfWork
    {
        public IVideoRepository VideoRepository { get; internal set; }
        private InMemoryContext context;

        public UnitOfWorkMem()
        {
            context = new InMemoryContext();
            VideoRepository = new VideoRepositoryEFMemory(context);
        }

        public int Complete()
        {
            //number of changes
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
