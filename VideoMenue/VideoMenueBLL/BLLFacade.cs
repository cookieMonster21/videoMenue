using VideoMenueBLL.Services;

namespace VideoMenueBLL
{
    public class BLLFacade
    {
        public IVideoService VideoService()
        {
            return new VideoService();
        }
    }
}
