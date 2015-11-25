using System.Collections.Generic;
using System.Linq;

namespace CustomMediaTypeFormattersDemo.Models
{
    public class Album
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Image> Files { get; set; }

        public Album()
        {

        }

        public Album(AlbumModel albumModel)
        {
            Title = albumModel.Title;
            Description = albumModel.Description;
            if (albumModel.Files.Any())
            {
                Files = new List<Image>();
                foreach(ImageModel file in albumModel.Files)
                {
                    Files.Add(new Image
                    {
                        Data = file.Data,
                        MimeType = file.MimeType,
                        Name = file.Name
                    });
                }
            }
        }
    }
}