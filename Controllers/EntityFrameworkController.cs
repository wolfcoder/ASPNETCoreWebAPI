using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityFrameworkController : ControllerBase
    {
        private readonly WebAPIContext _context;

        public EntityFrameworkController(WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/EntityFramework
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntityFrameworkModel>>> GetEntityFrameworkModel()
        {
            return await _context.EntityFrameworkModel.ToListAsync();
        }

        // GET: api/EntityFramework/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntityFrameworkModel>> GetEntityFrameworkModel(int id)
        {
            var entityFrameworkModel = await _context.EntityFrameworkModel.FindAsync(id);

            if (entityFrameworkModel == null)
            {
                return NotFound();
            }

            return entityFrameworkModel;
        }

        // PUT: api/EntityFramework/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntityFrameworkModel(int id, EntityFrameworkModel entityFrameworkModel)
        {
            if (id != entityFrameworkModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(entityFrameworkModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityFrameworkModelExists(id))
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

        // POST: api/EntityFramework
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EntityFrameworkModel>> PostEntityFrameworkModel(EntityFrameworkModel entityFrameworkModel)
        {
            _context.EntityFrameworkModel.Add(entityFrameworkModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntityFrameworkModel", new { id = entityFrameworkModel.Id }, entityFrameworkModel);
        }

        // DELETE: api/EntityFramework/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntityFrameworkModel(int id)
        {
            var entityFrameworkModel = await _context.EntityFrameworkModel.FindAsync(id);
            if (entityFrameworkModel == null)
            {
                return NotFound();
            }

            _context.EntityFrameworkModel.Remove(entityFrameworkModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntityFrameworkModelExists(int id)
        {
            return _context.EntityFrameworkModel.Any(e => e.Id == id);
        }
    }
}
