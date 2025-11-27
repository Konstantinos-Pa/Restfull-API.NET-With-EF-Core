using Assignment.Models;
using Assignment.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly ICandidatesRepository _candidatesRepository;
        public CandidatesController(ICandidatesRepository candidatesRepository)
        {
            _candidatesRepository = candidatesRepository;
        }

        [HttpGet("api/candidates")]
        public async Task<IActionResult> GetCandidates()
        {
            try
            {
                var candidates = await _candidatesRepository.GetCandidatesAsync();
                return Ok(candidates);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("api/candidates/{id}")]
        public async Task<IActionResult> GetCandidateById(int id)
        {
            try
            {
                var candidate = await _candidatesRepository.GetCandidateByIdAsync(id);
                return Ok(candidate);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("api/candidates")]
        public async Task<IActionResult> AddCandidate([FromBody] Candidate candidate)
        {
            try
            {
                await _candidatesRepository.AddCandidateAsync(candidate);
                return CreatedAtAction(nameof(GetCandidateById), new { id = candidate.CandidateNumber }, candidate);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("api/candidates/{id}")]
        public async Task<IActionResult> UpdateCandidate(int id, [FromBody] Candidate candidate)
        {
            try
            {
                await _candidatesRepository.UpdateCandidateAsync(id, candidate);
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("api/candidates/{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            try
            {
                await _candidatesRepository.DeleteCandidateAsync(id);
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
