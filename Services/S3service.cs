using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Amazon.S3;
using Amazon.S3.Model;

using s3mediainfo.Models;

namespace s3mediainfo.Services
{
    internal class S3service
    {
        private readonly IAmazonS3 Client;
        public S3service()
        {
            Client = new AmazonS3Client();
        }
        public void GetUrl(ref ResponseModel model) {            
            GetPreSignedUrlRequest req = new GetPreSignedUrlRequest
            {
                BucketName = model.S3entity.Bucket.Name,
                Key = model.S3entity.Object.Key,
                Expires = DateTime.Now.AddMinutes(5)
            };            
            model.SignedUrl = Client.GetPreSignedURL(req);
        }        
    }
}
