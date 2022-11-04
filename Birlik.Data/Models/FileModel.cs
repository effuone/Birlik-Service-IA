using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Birlik.Data.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        [Required]
        public string FilePath { get; set; }
        [Required]
        public string FileName { get; set; }
        [JsonIgnore]
        public virtual Teacher Teacher {get; set;}
        public FileModel()
        {
            
        }
    }
}