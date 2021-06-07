using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schoolable.Models;


namespace Schoolable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtablissementsController : ControllerBase
    {
        private readonly SchoolableContext _context;
        TypeEtablissementsController type;
        public EtablissementsController(SchoolableContext context)
        {
            _context = context;
        }

        // GET: api/Etablissements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Etablissement>>> GetEtablissements()
        {
            var etablissement = await _context.Etablissements.Include("TypeEtablissement").ToListAsync();

            return etablissement;
        }

        // GET: api/Etablissements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Etablissement>> GetEtablissement(long id)
        {
           // var etablissement = await _context.Etablissements.Include().FindAsync(id);
            var etablissement = await _context.Etablissements.Where(b => b.Id == id).Include("TypeEtablissement").FirstAsync();

            if (etablissement == null)
            {
                return NotFound();
            }

            return etablissement;
        }

        // PUT: api/Etablissements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Etablissement>> PutEtablissement(long id, Etablissement etablissement)
        {
            if (id != etablissement.Id)
            {
                return BadRequest();
            }

            _context.Entry(etablissement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtablissementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return etablissement;
        }

        // POST: api/Etablissements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Etablissement>> PostEtablissement(Etablissement etablissement)
        {
            
            _context.Etablissements.Add(etablissement);
            await _context.SaveChangesAsync();

 

            return CreatedAtAction("GetEtablissement", new { id = etablissement.Id }, etablissement);
        }

        // DELETE: api/Etablissements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtablissement(long id)
        {
            var etablissement = await _context.Etablissements.FindAsync(id);
            if (etablissement == null)
            {
                return NotFound();
            }

            _context.Etablissements.Remove(etablissement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EtablissementExists(long id)
        {
            return _context.Etablissements.Any(e => e.Id == id);
        }
    }
}
