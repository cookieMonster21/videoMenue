using System;
using System.Collections.Generic;
using System.Linq;
using VideoMenueDAL;
using VideoMeueEntity;

namespace VideoMenueBLL.Services
{
    class VideoService : IVideoService
    {
        //use
        public Video Create(Video video)
        {
            Video newVideo;
            FakeDB.Videos.Add(newVideo = new Video(){
                VideoId = FakeDB.VideoID++,
                VideoName = video.VideoName
            });
            return newVideo;
        }

        //use..
        public Video Modify (Video video)
        {
            int tempId = video.VideoId;
            for (int i = 0; i < ReadAll().Count; i++)
            {
                if (tempId == ReadAll()[i].VideoId)
                {
                    FakeDB.Videos[i].VideoName = video.VideoName;
                    int num = i;
                }
            }
            return video;
        }

        //use
        public Video Delete(int Id)
        {
            Video video = Get(Id);
            FakeDB.Videos.Remove(video);
            return video;
        }

        //use
        public Video Get(int Id)
        {
            return FakeDB.Videos.FirstOrDefault(x => x.VideoId == Id);
        }

        //use
        public List<Video> ReadAll()
        {
            return new List<Video>(FakeDB.Videos);
        }
    }
}
