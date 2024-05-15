using Newtonsoft.Json;

namespace Task.Models
{
    public class Answer
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("employeeid")]
        public string EmployeeId { get; set; }
        [JsonProperty("questionid")]
        public string QuestionId { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
