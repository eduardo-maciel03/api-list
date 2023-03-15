using apiLIST.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiLIST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LinguagensController : ControllerBase
    {
        private static List<Linguagem> linguagem = new List<Linguagem>
        {
            new Linguagem
            {
                Id = 1,
                Name = "C# (C-Sharp)",
                CrossPlataform = "Sim"
            },
            new Linguagem
            {
                Id = 2,
                Name = "Python",
                CrossPlataform = "Sim"
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<Linguagem>>> GetAll()
        {
            return Ok(linguagem);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Linguagem>>> GetId(int id)
        {
            var ling = linguagem.Find(x => x.Id == id);
            if(ling is null)
            {
                return NotFound("Registro Não Encontrado!");
            }
            return Ok(ling);
        }

        [HttpPost]
        public async Task<ActionResult<List<Linguagem>>> PostLing(Linguagem newLing)
        {
            linguagem.Add(newLing);
            return Ok(linguagem);
        }

        [HttpPut]
        public async Task<ActionResult<List<Linguagem>>> PutLing(Linguagem putLing)
        {
            var ling = linguagem.Find(x => x.Id == putLing.Id);
            if(ling is null)
            {
                return NotFound("Registro Não Encontrado!");
            }
            else
            {
                ling.Name = putLing.Name;
                ling.CrossPlataform = putLing.CrossPlataform;
            }
            return Ok(ling);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Linguagem>>> DelLing(int id)
        {
            var ling = linguagem.Find(x => x.Id == id);
            if(ling is null)
            {
                return NotFound("Registro Não Encontrado!");
            }
            else
            {
                linguagem.Remove(ling);
            }
            return Ok(linguagem);
        }
    }
}
