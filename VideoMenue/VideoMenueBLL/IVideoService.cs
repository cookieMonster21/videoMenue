using System.Collections.Generic;
using VideoMeueBLL.BusinessObjects;

namespace VideoMenueBLL
{
    public interface IVideoService
    {
        //Create
        void AddVideos(List<VideoBO> video);

        //Read
        List<VideoBO> ReadAll();
        VideoBO Get(int Id);

        //Update, Modify
        void Modify(VideoBO video);

        //Delete
        VideoBO Delete(int selection);

        //Search
        List<VideoBO> Search(string search);

        bool IdInDatabase(int selection);
        bool emptyDB();
    }
}
