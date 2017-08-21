using System;
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

        public Video Delete(int Id)
        {
            Video video = Get(Id);
            FakeDB.Videos.Remove(video);
            return video;
        }

        public Video Get(int Id)
        {
            return FakeDB.Videos.FirstOrDefault(x => x.VideoId == Id);
        }

        public List<Video> ReadAll()
        {
            return new List<Video>(FakeDB.Videos);
        }

        public Video Update(Video Video)
        {
            throw new NotImplementedException();
        }
    }
}
