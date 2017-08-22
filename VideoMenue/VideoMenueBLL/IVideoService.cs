using System.Collections.Generic;
using VideoMeueEntity;

namespace VideoMenueBLL
{
    public interface IVideoService
    {
        Video Create(Video video);
        List<Video> ReadAll();
        Video Get(int Id);
        void Delete(int selection);
        void Modify(Video video);
        bool IdInDatabase(int selection);
        Video Search(string search);
    }
}
