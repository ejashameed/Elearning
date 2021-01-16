using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Bookstore.Controllers
{
    [Route("/blob")]
    public class BlobController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly String _connectionString;
        private readonly String _containerName;
        private readonly String _fileName;
        public BlobController(IConfiguration configuration)
        {
           _configuration = configuration;
           _connectionString = _configuration ["AzureStorage:ConnectionString"];
           _containerName = _configuration ["AzureStorage:Container"];
           _fileName = "D:/Bookstore/Bookstore/wwwroot/images/Books/download.jpg";
        }
        [Route("/blob/")]
        [Route("/blob/index")]
        public IActionResult Index()
        {
            var containerClient = new BlobContainerClient(_connectionString,_containerName);
            try
            {
                var bobClient = containerClient.GetBlobClient(_fileName);
                using (var fileStream = System.IO.File.OpenRead(_fileName)) 
                {
                    bobClient.Upload(fileStream);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }
    }
}
