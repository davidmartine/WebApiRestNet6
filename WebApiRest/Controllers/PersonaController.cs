using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiRest.Data;
using WebApiRest.Models;

namespace WebApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly DataContext _context;
        public PersonaController(DataContext context)
        {
            _context = context;
        }

        private static List<Persona> personas = new List<Persona>
        {
             new Persona
                {
                    Id = 1,
                    Name= "Test",
                    PrimerApellido = "Dospe",
                    SegundoApellido = "Trespe",
                    Direccion = "CR 45 C 67"
                }
        };

        [HttpGet]
        public async Task<ActionResult<List<Persona>>> Get()
        {
            return Ok(await _context.Persona.ToListAsync());

           // return Ok(personas);

        }

        [HttpPost]
        public async Task<ActionResult<List<Persona>>> Add(Persona pers)
        {
            // personas.Add(pers);
            // return Ok(personas);
            _context.Persona.Add(pers);
            await _context.SaveChangesAsync();
            return Ok(await _context.Persona.ToListAsync());
           

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> Get(int id)
        {
            //var per = personas.Find(x => x.Id == id);
            var pers = await _context.Persona.FindAsync(id);

            if(pers == null)
            {
                return BadRequest("No se encuentra id");
            }
            return Ok(pers);

        }

        [HttpPut]
        public async Task<ActionResult<List<Persona>>> UpdateId(Persona persona)
        {
            //var pers = personas.Find(x => x.Id == persona.Id);
            var pers = await _context.Persona.FindAsync(persona.Id);
            if(pers == null)
            {
                return BadRequest("No encontrado el id");
            }

            pers.Name = persona.Name;
            pers.PrimerApellido = persona.PrimerApellido;
            pers.SegundoApellido = persona.SegundoApellido;
            pers.Direccion = persona.Direccion;

            await _context.SaveChangesAsync();

            return Ok(await _context.Persona.ToListAsync());
            //return Ok(personas);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Persona>>> Delete(int id)
        {
            //var per = personas.Find(x => x.Id == id);
            var per = await _context.Persona.FindAsync(id);
            if(per == null)
            {
                return BadRequest("No se encontro id para eliminar");
            }

            //ersonas.Remove(per);
             _context.Persona.Remove(per);
            await _context.SaveChangesAsync();
            //return Ok(personas);
            return Ok(await _context.Persona.ToListAsync())
        }


    }
}
