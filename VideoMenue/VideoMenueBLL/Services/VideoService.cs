using System.Collections.Generic;
using VideoMenueDAL;
using VideoMeueEntity;

namespace VideoMenueBLL.Services
{
    class VideoService : IVideoService
    {
        DALFacade facade;
        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

        public Video Create(Video video)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVideo = uow.VideoRepository.Create(video);
                uow.Complete();
                return newVideo;
            }
        }

        public void Modify (Video video)
        {
            using (var uow = facade.UnitOfWork)
            {
                var VideoFromDB = uow.VideoRepository.Get(video.VideoId);
                VideoFromDB.VideoName = video.VideoName;
                uow.Complete();
            }
        }

        public Video Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVideo = uow.VideoRepository.Delete(Id);
                uow.Complete();
                return newVideo;
            }
        }

        public Video Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.Get(Id);
            }
        }

        public List<Video> ReadAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.ReadAll();
            }
        }

        public bool IdInDatabase(int selection)
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.IdInDatabase(selection);
            }
        }

        public Video Search(string search)
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.Search(search);
            }
        }

        public bool emptyDB()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.emptyDB();
            }
        }
    }
}
