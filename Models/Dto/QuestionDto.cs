namespace Task.Models.Dto
{
    public class QuestionDto
    {
        public string QuestionId { get; set; }
        public string EmployeeId { get; set; }
        public string Content { get; set; }
        public QuestionType Type { get; set; }
    }
}
