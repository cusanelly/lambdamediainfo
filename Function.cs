using Amazon.Lambda.Core;
using Amazon.Lambda.S3Events;

using s3mediainfo.Models;
using s3mediainfo.Services;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace s3mediainfo
{
    public class Function
    {
        ResponseModel responses = new ResponseModel();
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// 
        public VideoQualityModel FunctionHandler(S3Event input, ILambdaContext context)
        {
            if (input.Records[0].S3 != null)
            {
                responses.S3entity = input.Records[0].S3;
                new S3service().GetUrl(ref responses);
                MediaInfoservice mediaservice = new MediaInfoservice();
                mediaservice.GetVideoInfo(ref responses);
            }
            return responses.MediaData;
        }
    }
}
