using VideoMenueBLL.Services;
using VideoMenueDAL;

namespace VideoMenueBLL
{
    public class BLLFacade
    {
        public IVideoService VideoService
        {
            get { return new VideoService(new DALFacade()); }
        }
    }
}
