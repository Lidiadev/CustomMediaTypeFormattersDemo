using CustomMediaTypeFormattersDemo.Helpers;
using CustomMediaTypeFormattersDemo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace CustomMediaTypeFormattersDemo.Formatters
{
    public class CustomMediaTypeFormatter : MediaTypeFormatter
    {
        public CustomMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("multipart/form-data"));
        }

        public override bool CanReadType(Type type)
        {
            return type == typeof(AlbumModel);
        }

        public override bool CanWriteType(Type type)
        {
            return false;
        }

        public override async Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger, CancellationToken cancellationToken)
        {
            var provider = await content.ReadAsMultipartAsync();
            var providerContent = provider.Contents.FirstOrDefault(x => x.Headers.ContentType.MediaType == "application/json");

            AlbumModel album = new AlbumModel(); 
            album = await providerContent.ReadAsAsync<AlbumModel>();

            var files = provider.Contents.Where(x => x.Headers.ContentType.MediaType != "application/json").ToList();
            album.Files = new List<ImageModel>();
            foreach(var file in files)
            {
                album.Files.Add(new ImageModel
                {
                    Data = await file.ReadAsByteArrayAsync(),
                    Name = file.Headers.ContentDisposition.FileName.NormalizeName(),
                    MimeType = file.Headers.ContentType.MediaType
                    
                });
            }
                
            return album;
        }
    }
}