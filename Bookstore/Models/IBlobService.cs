using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    interface IBlobService
    {
       // public Task<IActionResult> GetBlobAsync(String name);
        public Task<IEnumerable<string>> ListBlobsAsync();
        public Task UploadFileBlobAsync(String filePath, string fileName);

    }
}
