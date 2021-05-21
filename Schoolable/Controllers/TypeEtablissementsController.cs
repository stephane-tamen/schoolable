using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schoolable.Models;

namespace Schoolable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeEtablissementsController : ControllerBase
    {
        private readonly SchoolableContext _context;

        public TypeEtablissementsController(SchoolableContext context)
        {
            _context = context;
        }

        // GET: api/TypeEtablissements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeEtablissement>>> GetTypeEtablissements()
        {
            return await _context.TypeEtablissements.ToListAsync();
        }

        // GET: api/TypeEtablissements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeEtablissement>> GetTypeEtablissement(long id)
        {
            var typeEtablissement = await _context.TypeEtablissements.FindAsync(id);

            if (typeEtablissement == null)
            {
                return NotFound();
            }

            return typeEtablissement;
        }

        // PUT: api/TypeEtablissements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeEtablissement(long id, TypeEtablissement typeEtablissement)
        {
            if (id != typeEtablissement.Id)
            {
                return BadRequest();
            }

            _context.Entry(typeEtablissement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeEtablissementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TypeEtablissements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeEtablissement>> PostTypeEtablissement(TypeEtablissement typeEtablissement)
        {
            _context.TypeEtablissements.Add(typeEtablissement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeEtablissement", new { id = typeEtablissement.Id }, typeEtablissement);
        }

        // DELETE: api/TypeEtablissements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeEtablissement(long id)
        {
            var typeEtablissement = await _context.TypeEtablissements.FindAsync(id);
            if (typeEtablissement == null)
            {
                return NotFound();
            }

            _context.TypeEtablissements.Remove(typeEtablissement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeEtablissementExists(long id)
        {
            return _context.TypeEtablissements.Any(e => e.Id == id);
        }
    }
}
