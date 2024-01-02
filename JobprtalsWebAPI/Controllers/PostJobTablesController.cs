using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobprtalsWebAPI.Models;

namespace JobprtalsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostJobTablesController : ControllerBase
    {
        private readonly JobsPortalDbContext _context;

        public PostJobTablesController(JobsPortalDbContext context)
        {
            _context = context;
        }

        // GET: api/PostJobTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostJobTable>>> GetPostJobTables()
        {
          if (_context.PostJobTables == null)
          {
              return NotFound();
          }
            return await _context.PostJobTables.ToListAsync();
        }

        // GET: api/PostJobTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostJobTable>> GetPostJobTable(int id)
        {
          if (_context.PostJobTables == null)
          {
              return NotFound();
          }
            var postJobTable = await _context.PostJobTables.FindAsync(id);

            if (postJobTable == null)
            {
                return NotFound();
            }

            return postJobTable;
        }

        // PUT: api/PostJobTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostJobTable(int id, PostJobTable postJobTable)
        {
            if (id != postJobTable.PostJobId)
            {
                return BadRequest();
            }

            _context.Entry(postJobTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostJobTableExists(id))
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

        // POST: api/PostJobTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostJobTable>> PostPostJobTable(PostJobTable postJobTable)
        {
          if (_context.PostJobTables == null)
          {
              return Problem("Entity set 'JobsPortalDbContext.PostJobTables'  is null.");
          }
            _context.PostJobTables.Add(postJobTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostJobTable", new { id = postJobTable.PostJobId }, postJobTable);
        }

        // DELETE: api/PostJobTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostJobTable(int id)
        {
            if (_context.PostJobTables == null)
            {
                return NotFound();
            }
            var postJobTable = await _context.PostJobTables.FindAsync(id);
            if (postJobTable == null)
            {
                return NotFound();
            }

            _context.PostJobTables.Remove(postJobTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostJobTableExists(int id)
        {
            return (_context.PostJobTables?.Any(e => e.PostJobId == id)).GetValueOrDefault();
        }
    }
}
