using System.Text.Json.Serialization;

namespace Birlik.Data.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        [JsonIgnore]
        public Teacher Teacher {get; set;}
        public int TeacherId { get; set; }
        public ImageModel()
        {
            
        }
        public ImageModel(int id, string filePath)
        {
            Id = id;
            FilePath = filePath;
        }
    }
}