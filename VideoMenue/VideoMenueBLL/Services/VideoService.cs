using System.Collections.Generic;
using System.Linq;
using VideoMenueDAL;
using VideoMeueEntity;

namespace VideoMenueBLL.Services
{
    class VideoService : IVideoService
    {
        public Video Create(Video video)
        {
            Video newVideo;
            FakeDB.Videos.Add(newVideo = new Video(){
                VideoId = FakeDB.VideoID++,
                VideoName = video.VideoName
            });
            return newVideo;
        }

        public void Modify (Video video)
        {
            int tempId = video.VideoId;
            for (int i = 0; i < ReadAll().Count; i++)
            {
                if (tempId == ReadAll()[i].VideoId)
                {
                    FakeDB.Videos[i].VideoName = video.VideoName;
                }
            }
        }

        public void Delete(int Id)
        {
            Video video = Get(Id);
            FakeDB.Videos.Remove(video);
        }

        public Video Get(int Id)
        {
            return FakeDB.Videos.FirstOrDefault(x => x.VideoId == Id);
        }

        public List<Video> ReadAll()
        {
            return new List<Video>(FakeDB.Videos);
        }

        public bool IdInDatabase(int selection)
        {
            bool temp = false;
            for (int i = 0; i < FakeDB.Videos.Count; i++)
            {
                if (FakeDB.Videos[i].VideoId == selection)
                {
                    temp = true;
                }
            }
            return temp;
        }

        public Video Search(string search)
        {
            Video tempVideo = null;
            for (int i = 0; i < ReadAll().Count; i++)
            {
                string name = ReadAll()[i].VideoName.Substring(0, 3);
                if (search == name)
                {
                    tempVideo = ReadAll()[i];
                }
            }
            return tempVideo;
        }
    }
}
