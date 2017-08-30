using System.Collections.Generic;
using VideoMeueDAL.Entities;

namespace VideoMenueDAL
{
    public interface IVideoRepository
    {
        //Create
        Video Create(Video video);

        //Read
        List<Video> ReadAll();
        Video Get(int Id);

        //Delete
        Video Delete(int selection);

        //Search
        List<Video> Search(string search);

        bool IdInDatabase(int selection);
        bool emptyDB();
    }
}
