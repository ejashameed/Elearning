using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }
        //public async Task<IActionResult> GetBlobAsync(string name)
        //{
           
            
        //var containerClient = _blobServiceClient.GetBlobContainerClient("books");
        //    var blobClient = containerClient.GetBlobClient(name);

        //    var blobDownloadInfo = await blobClient.DownloadAsync();
        //    return new BlobInfo(blobDownloadInfo.Value.Content,blobDownloadInfo.Value.ContentType);
        //}

        public Task<IEnumerable<string>> ListBlobsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UploadFileBlobAsync(string filePath, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
