using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Cemeraf.Data;
using Cemeraf.Models;
using Microsoft.Extensions.Configuration;
using Amazon.Runtime;

namespace Cemeraf.Services
{
    public class PicturesService : IPictures
    {
        private IAmazonS3 client;
        private readonly IConfiguration Configuration;
        private readonly ApplicationDbContext _context;

        public PicturesService(IConfiguration cfg, ApplicationDbContext ctx)
        {
            _context = ctx;
            Configuration = cfg;
            var credentials = new BasicAWSCredentials(
                Configuration["AwsS3:AccessId"].Trim(), Configuration["AwsS3:SecretAccessKey"].Trim());
            client = new AmazonS3Client(credentials, Amazon.RegionEndpoint.USEast1);
        }
        public Task<string> UploadPictureToS3(string pathToFile, string extension)
        {
            return Task.Run(async () => {

                string pathToS3 = "";

                FileStream stream = new FileStream(pathToFile, FileMode.Open);

                String timeStamp = GetTimestamp(DateTime.Now);

                Random random = new Random();
                var fileNameInS3 = "doctor-image-" + random.Next(0, 98000).ToString() + "_" + timeStamp + extension;

                PutObjectRequest request = new PutObjectRequest();
                request.InputStream = stream;
                request.BucketName = Configuration["AwsS3:BucketName"];
                request.CannedACL = S3CannedACL.PublicRead;
                request.Key = "doctorsPictures/" + fileNameInS3;
                request.AutoCloseStream = true;

                var response = await client.PutObjectAsync(request);

                string baseS3 = @"https://s3.amazonaws.com/cemeraf/doctorsPictures/";

                return pathToS3 = baseS3 + fileNameInS3;
            });
        }

        private string GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }
    }
}
