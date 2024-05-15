using Microsoft.AspNetCore.Mvc;
using Task.Models;
using Task.Repository.IRepository;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        // GET api/Question/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById(string id)
        {
            var question = await _questionRepository.GetQuestionById(id);
            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        // GET api/Question/employee/{id}
        [HttpGet("employee/{id}")]
        public async Task<IActionResult> GetQuestionsByEmployeeId(string id)
        {
            var questions = await _questionRepository.GetQuestionsByEmployeeId(id);
            return Ok(questions);
        }

        // POST api/Question/{id}
        [HttpPost]
        public async Task<IActionResult> CreateQuestion(Question question)
        {
            var createdQuestion = await _questionRepository.CreateQuestion(question);
            return CreatedAtAction(nameof(GetQuestionById), new { id = createdQuestion.Id }, createdQuestion);
        }

        // PUT api/Question/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(string id, Question question)
        {
            var existingQuestion = await _questionRepository.GetQuestionById(id);
            if (existingQuestion == null)
            {
                return NotFound();
            }

            question.Id = existingQuestion.Id;
            var updatedQuestion = await _questionRepository.UpdateQuestion(id, question);
            return Ok(updatedQuestion);
        }
    }
}
