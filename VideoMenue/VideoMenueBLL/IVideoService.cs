using System.Collections.Generic;
using VideoMeueEntity;

namespace VideoMenueBLL
{
    public interface IVideoService
    {
        //Create
        Video Create(Video video);

        //Read
        List<Video> ReadAll();
        Video Get(int Id);

        //Update, Modify
        void Modify(Video video);

        //Delete
        Video Delete(int selection);

        //Search
        List<Video> Search(string search);

        bool IdInDatabase(int selection);
        bool emptyDB();
    }
}
