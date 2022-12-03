using BalanceFinanciero.Model;
using BalanceFinanciero.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BalanceFinanciero.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RubroController : Controller
    {
        private readonly IRubroRepository _rubroRepository;
        public RubroController(IRubroRepository rubroRepository) => _rubroRepository = rubroRepository;

        [HttpGet]
        public async Task<IActionResult> GetAllRubros()
        {
            return Ok(await _rubroRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleRubro(int id)
        {
            return Ok(await _rubroRepository.GetSingle(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertRubro([FromBody] Rubro rubro)
        {
            if (rubro == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _rubroRepository.Insert(rubro);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRubro([FromBody] Rubro rubro)
        {
            if (rubro == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _rubroRepository.Update(rubro);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRubro(int id)
        {
            var deleted = await _rubroRepository.Delete(id);

            return NoContent();
        }
    }
}
