using System;
using System.Collections.Generic;
using System.Linq;
using VideoMeueEntity;

namespace VideoMenueDAL.Repostiories
{
    class VideoRepostioryFakeDB : IVideoRepository
    {
        private static int VideoID = 1;
        private static List<Video> Videos = new List<Video>();

        public Video Create(Video video)
        {
            Video newVideo;
            Videos.Add(newVideo = new Video()
            {
                VideoId = VideoID++,
                VideoName = video.VideoName
            });
            return newVideo;
        }

        public Video Delete(int selection)
        {
            Video video = Get(selection);
            Videos.Remove(video);
            return video;
        }

        public Video Get(int Id)
        {
            return Videos.FirstOrDefault(x => x.VideoId == Id);
        }

        public bool IdInDatabase(int selection)
        {
            bool temp = false;
            for (int i = 0; i < Videos.Count; i++)
            {
                if (Videos[i].VideoId == selection)
                {
                    temp = true;
                }
            }
            return temp;
        }

        public List<Video> ReadAll()
        {
            return new List<Video>(Videos);
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
