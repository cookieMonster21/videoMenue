using VideoMenueDAL.Repostiories;
using VideoMenueDAL.UOW;

namespace VideoMenueDAL
{
    public class DALFacade
    {
        public IUnitOfWork UnitOfWork
        {
            get { return new UnitOfWorkMem(); }
        }
    }
}
