using Microsoft.AspNetCore.Mvc;
using Task.Models;
using Task.Repository.IRepository;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerRepository _answerRepository;

        public AnswerController(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        // GET api/Answer/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnswerById(string id)
        {
            var answer = await _answerRepository.GetAnswerById(id);
            if (answer == null)
            {
                return NotFound();
            }

            return Ok(answer);
        }

        // GET api/Answer/employee/{id}
        [HttpGet("employee/{id}")]
        public async Task<IActionResult> GetAnswersByEmployeeId(string id)
        {
            var answers = await _answerRepository.GetAnswersByEmployeeId(id);
            return Ok(answers);
        }

        // GET api/Answer/question/{id}
        [HttpGet("question/{id}")]
        public async Task<IActionResult> GetAnswersByQuestionId(string id)
        {
            var answers = await _answerRepository.GetAnswersByQuestionId(id);
            return Ok(answers);
        }

        // POST api/Answer
        [HttpPost]
        public async Task<IActionResult> CreateAnswer(Answer answer)
        {
            var createdAnswer = await _answerRepository.CreateAnswer(answer);
            return CreatedAtAction(nameof(GetAnswerById), new { id = createdAnswer.Id }, createdAnswer);
        }

        // PYT api/Answer/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnswer(string id, Answer answer)
        {
            var existingAnswer = await _answerRepository.GetAnswerById(id);
            if (existingAnswer == null)
            {
                return NotFound();
            }

            answer.Id = existingAnswer.Id;
            var updatedAnswer = await _answerRepository.UpdateAnswer(id, answer);
            return Ok(updatedAnswer);
        }
    }
}
