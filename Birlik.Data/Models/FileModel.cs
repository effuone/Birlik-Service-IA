using System.Text.Json.Serialization;

namespace Birlik.Data.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        [JsonIgnore]
        public Teacher Teacher {get; set;}
        public int TeacherId { get; set; }
        public FileModel()
        {
            
        }
        public FileModel(int id, string filePath)
        {
            Id = id;
            FilePath = filePath;
        }
    }
}