using VideoMenueDAL.Repostiories;

namespace VideoMenueDAL
{
    public class DALFacade
    {
        public IVideoRepository VideoRepository
        {
            get { return new VideoRepostioryFakeDB(); }
        }
    }
}
