using System;

namespace VideoMenueDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IVideoRepository VideoRepository { get; }

        //save changes
        int Complete();
    }
}
