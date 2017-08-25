using System.Collections.Generic;
using System.Linq;
using VideoMenueDAL.Context;
using VideoMeueEntity;

namespace VideoMenueDAL.Repostiories
{
    class VideoRepositoryEFMemory : IVideoRepository
    {
        InMemoryContext context;
        public VideoRepositoryEFMemory(InMemoryContext context)
        {
            this.context = context;
        }

        public Video Create(Video video)
        {
            //.Video = add to this table
            this.context.Video.Add(video);
            return video;
        }

        public Video Delete(int selection)
        {
            Video video = Get(selection);
            this.context.Video.Remove(video);
            return video;
        }

        public Video Get(int Id)
        {
            return this.context.Video.FirstOrDefault(x => x.VideoId == Id);
        }

        public bool IdInDatabase(int selection)
        {
            bool temp = false;
            for (int i = 0; i < this.context.Video.Count(); i++)
            {
                if (ReadAll()[i].VideoId == selection)
                {
                    temp = true;
                }
            }
            return temp;
        }

        public List<Video> ReadAll()
        {
            return this.context.Video.ToList();
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
        public bool emptyDB()
        {
            bool emptyDB = ReadAll().Count == 0;
            return emptyDB;
        }
    }
}
