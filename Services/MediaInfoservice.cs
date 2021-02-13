using System;
using System.Linq;

using Xabe.FFmpeg;

using s3mediainfo.Models;


namespace s3mediainfo.Services
{
    internal class MediaInfoservice
    {
        public MediaInfoservice()
        {

        }

        public void GetVideoInfo(ref ResponseModel model)
        {
            // Specify an environment variable that would point to the path which ffmpeg and ffprobe are located on Lambda.
            FFmpeg.SetExecutablesPath(Environment.GetEnvironmentVariable("ffmpeg"));
            model.MediaInfoResponse = FFmpeg.GetMediaInfo(model.SignedUrl).Result;
            model.MediaData = new VideoQualityModel
            {
                Bucket = model.S3entity.Bucket.Name,                
                Key = model.S3entity.Object.Key,
                Quality = model.MediaInfoResponse.VideoStreams.First().Height
            };
        }
    }
}
