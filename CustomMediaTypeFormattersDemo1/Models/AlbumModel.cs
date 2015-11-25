using Newtonsoft.Json;
using System.Collections.Generic;

namespace CustomMediaTypeFormattersDemo.Models
{
    public class AlbumModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public List<ImageModel> Files { get; set; }
    }
}