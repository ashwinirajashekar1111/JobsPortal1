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
    public class CompanyTablesController : ControllerBase
    {
        private readonly JobsPortalDbContext _context;

        public CompanyTablesController(JobsPortalDbContext context)
        {
            _context = context;
        }

        // GET: api/CompanyTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyTable>>> GetCompanyTables()
        {
          if (_context.CompanyTables == null)
          {
              return NotFound();
          }
            return await _context.CompanyTables.ToListAsync();
        }

        // GET: api/CompanyTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyTable>> GetCompanyTable(int id)
        {
          if (_context.CompanyTables == null)
          {
              return NotFound();
          }
            var companyTable = await _context.CompanyTables.FindAsync(id);

            if (companyTable == null)
            {
                return NotFound();
            }

            return companyTable;
        }

        // PUT: api/CompanyTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyTable(int id, CompanyTable companyTable)
        {
            if (id != companyTable.CompanyId)
            {
                return BadRequest();
            }

            _context.Entry(companyTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyTableExists(id))
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

        // POST: api/CompanyTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyTable>> PostCompanyTable(CompanyTable companyTable)
        {
          if (_context.CompanyTables == null)
          {
              return Problem("Entity set 'JobsPortalDbContext.CompanyTables'  is null.");
          }
            _context.CompanyTables.Add(companyTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyTable", new { id = companyTable.CompanyId }, companyTable);
        }

        // DELETE: api/CompanyTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyTable(int id)
        {
            if (_context.CompanyTables == null)
            {
                return NotFound();
            }
            var companyTable = await _context.CompanyTables.FindAsync(id);
            if (companyTable == null)
            {
                return NotFound();
            }

            _context.CompanyTables.Remove(companyTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyTableExists(int id)
        {
            return (_context.CompanyTables?.Any(e => e.CompanyId == id)).GetValueOrDefault();
        }
    }
}
