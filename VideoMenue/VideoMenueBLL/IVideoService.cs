﻿using System.Collections.Generic;
using VideoMeueEntity;

namespace VideoMenueBLL
{
    public interface IVideoService
    {
        Video Create(Video video);
        List<Video> ReadAll();
        Video Get(int Id);
        Video Delete(int selection);
        Video Modify(Video video);
    }
}
