using EstrelaNegra.API.DTO;
using EstrelaNegra.API.Interfaces;
using EstrelaNegra.API.Models;
using EstrelaNegra.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EstrelaNegra.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HorseController : Controller
    {

        private readonly IHorseApplication _horseApplication;
        private readonly IHorseRepository _horseRepository;

        public HorseController(IHorseApplication horseApplication, IHorseRepository horseRepository)
        {
            _horseApplication = horseApplication;
            _horseRepository = horseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equine>>> GetHorses()
        {
            return Ok(await _horseRepository.GetAll());
        }
        [HttpPost]
        public async Task<ActionResult> AddHorse(Equine horse)
        {
            _horseRepository.Add(horse);
            if (await _horseRepository.SaveAllAsync())
            {
                return Ok("Animal cadastrado com sucesso!");
            }

            return BadRequest("Erro ao adicionar animal.");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateHorse(Equine horse)
        {
            _horseRepository.Update(horse);
            if (await _horseRepository.SaveAllAsync())
            {
                return Ok("Animal atualizado com sucesso!");
            }
            return BadRequest("Erro ao atualizar animal.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHorse(int id)
        {
            var horse = await _horseRepository.GetById(id);
            if (horse == null)
            {
                return NotFound("Animal não encontrado.");
            }
            _horseRepository.Delete(horse);
            if (await _horseRepository.SaveAllAsync())
            {
                return Ok("Animal excluído com sucesso!");
            }
            return BadRequest("Erro ao excluir animal.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var horse = await _horseApplication.GetMonitorData(id);
            if (horse == null)
                return NotFound("Animal não encontrado");
            return Ok(horse);
        }

        [HttpGet("dropList")]
        public async Task<ActionResult<IEnumerable<DropDownDTO>>> GetHorseList()
        {
            var list = await _horseApplication.GetHorseList();  
            return Ok(list);
        }

        [HttpGet("queryTest/{id}")]
        public async Task<ActionResult> TESTE(int id)
        {
            var horse = _horseRepository.GetNameById(id);
            if (horse == null)
                return NotFound("Animal não encontrado");
            return Ok(horse);
        }
    }
    
}
