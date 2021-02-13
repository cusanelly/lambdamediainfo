
using Xabe.FFmpeg;

using Amazon.S3.Model;
using Amazon.S3.Util;

namespace s3mediainfo.Models
{
    public class ResponseModel
    {
        public S3EventNotification.S3Entity S3entity { get; set; }
        public string SignedUrl { get; set; }        
        
        public IMediaInfo MediaInfoResponse { get; set; }

        public VideoQualityModel MediaData { get; set; }        
    }
}
