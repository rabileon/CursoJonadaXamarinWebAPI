using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace JornadaXamarin.MobileApp.AppBase.Helpers
{
    public class BlobStorageHelper
    {
        public static async Task<string> UploadCover(string cover)
        {
            // Create a BlobServiceClient object which will be used to create a container client
            BlobServiceClient blobServiceClient = new BlobServiceClient(Constants.Storage.CONNECTION_STRING);
            // Create the container and return a container client object
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(Constants.Storage.BLOB);
            // Get a reference to a blob
            BlobClient blobClient = containerClient.GetBlobClient(cover);
            // Open the file and upload its data
            var photoBytes = LocalFilesHelper.ReadFile(cover);
            using MemoryStream uploadFileStream = new(photoBytes);
            var response = await blobClient.UploadAsync(uploadFileStream, true);
            uploadFileStream.Close();
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
