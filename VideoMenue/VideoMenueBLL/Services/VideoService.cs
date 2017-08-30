using System.Collections.Generic;
using VideoMenueDAL;
using VideoMeueBLL.BusinessObjects;
using VideoMeueDAL.Entities;
using System.Linq;

namespace VideoMenueBLL.Services
{
    class VideoService : IVideoService
    {
        DALFacade facade;
        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

        public void AddVideos(List<VideoBO> videoList)
        {
            using (var uow = facade.UnitOfWork)
            {
                for (int i = 0; i < videoList.Count; i++)
                {
                    uow.VideoRepository.Create(Convert(videoList[i]));
                }
                uow.Complete();
            }
        }

        public void Modify (VideoBO video)
        {
            //Convert????
            using (var uow = facade.UnitOfWork)
            {
                var VideoFromDB = uow.VideoRepository.Get(video.VideoId);
                VideoFromDB.VideoName = video.VideoName;
                uow.Complete();
            }
        }

        public VideoBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVideo = uow.VideoRepository.Delete(Id);
                uow.Complete();
                return Convert(newVideo);
            }
        }

        public VideoBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return Convert(uow.VideoRepository.Get(Id));
            }
        }

        public List<VideoBO> ReadAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.ReadAll().Select(Convert).ToList();
            }
        }

        public bool IdInDatabase(int selection)
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.IdInDatabase(selection);
            }
        }

        public List<VideoBO> Search(string search)
        {
            using (var uow = facade.UnitOfWork)
            {
                //return uow.VideoRepository.Search(search).Select(c => Convert(c)).ToList();
                return uow.VideoRepository.Search(search).Select(Convert).ToList();
            }
        }

        public bool emptyDB()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.emptyDB();
            }
        }

        private Video Convert(VideoBO video)
        {
            return new Video()
            {
                VideoId = video.VideoId,
                VideoName = video.VideoName
            };
        }

        private VideoBO Convert(Video video)
        {
            return new VideoBO()
            {
                VideoId = video.VideoId,
                VideoName = video.VideoName
            };
        }
    }
}
