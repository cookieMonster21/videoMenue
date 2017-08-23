using System.Collections.Generic;
using VideoMenueDAL;
using VideoMeueEntity;

namespace VideoMenueBLL.Services
{
    class VideoService : IVideoService
    {
        IVideoRepository repro;

        public VideoService(IVideoRepository repro)
        {
            this.repro = repro;
        }

        public Video Create(Video video)
        {
            return this.repro.Create(video);
        }

        public void Modify (Video video)
        {
            int tempId = video.VideoId;
            for (int i = 0; i < ReadAll().Count; i++)
            {
                if (tempId == ReadAll()[i].VideoId)
                {
                    ReadAll()[i].VideoName = video.VideoName;
                }
            }
        }

        public void Delete(int Id)
        {
            repro.Delete(Id);
        }

        public Video Get(int Id)
        {
            return repro.Get(Id);
        }

        public List<Video> ReadAll()
        {
            return repro.ReadAll();
        }

        public bool IdInDatabase(int selection)
        {
            return repro.IdInDatabase(selection);
        }

        public Video Search(string search)
        {
            return repro.Search(search);
        }
    }
}
