using Newtonsoft.Json;

namespace Task.Models
{
    public class Question
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("questiontype")]
        public QuestionType Type { get; set; }
    }

    public enum QuestionType
    {
        Paragraph,
        YesNo,
        Dropdown,
        MultipleChoice,
        Date,
        Numeric
    }
}
