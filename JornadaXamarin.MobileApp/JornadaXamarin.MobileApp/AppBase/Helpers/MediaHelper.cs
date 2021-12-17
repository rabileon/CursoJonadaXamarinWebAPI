using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace JornadaXamarin.MobileApp.AppBase.Helpers
{
    public static class MediaHelper
    {
        public static async Task<string> TakePhotoAsync(string photoName)
        {
            string path = string.Empty;

            if (MediaPicker.IsCaptureSupported)
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions()
                {
                    Title = photoName,
                });

                if (photo is not null)
                {
                    using var stream = await photo.OpenReadAsync();
                    using var memoryStream = new MemoryStream();
                    await stream.CopyToAsync(memoryStream);
                    var bytes = memoryStream.ToArray();
                    path = LocalFilesHelper.SaveFile(photoName, bytes);
                }
            }
            return path;
        }
    }
}