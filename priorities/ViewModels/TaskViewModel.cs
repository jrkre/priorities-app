using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace priorities.ViewModels
{
    public class TaskViewModel
    {
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [Required]
        [JsonPropertyName("Description")]
        public string Description { get; set; }
        [Required]
        public int Size { get; set; }
        public bool Completed { get; set; }
    }
}
