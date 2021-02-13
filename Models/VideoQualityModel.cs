using System;
using System.Text;

namespace s3mediainfo.Models
{
    public class VideoQualityModel
    {
        public string Bucket { get; set; }        
        public string Key { get; set; }
        public int Quality { get; set; }
    }
}
