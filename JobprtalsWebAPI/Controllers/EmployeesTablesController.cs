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
    public class EmployeesTablesController : ControllerBase
    {
        private readonly JobsPortalDbContext _context;

        public EmployeesTablesController(JobsPortalDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeesTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeesTable>>> GetEmployeesTables()
        {
          if (_context.EmployeesTables == null)
          {
              return NotFound();
          }
            return await _context.EmployeesTables.ToListAsync();
        }

        // GET: api/EmployeesTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeesTable>> GetEmployeesTable(int id)
        {
          if (_context.EmployeesTables == null)
          {
              return NotFound();
          }
            var employeesTable = await _context.EmployeesTables.FindAsync(id);

            if (employeesTable == null)
            {
                return NotFound();
            }

            return employeesTable;
        }

        // PUT: api/EmployeesTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeesTable(int id, EmployeesTable employeesTable)
        {
            if (id != employeesTable.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employeesTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesTableExists(id))
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

        // POST: api/EmployeesTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeesTable>> PostEmployeesTable(EmployeesTable employeesTable)
        {
          if (_context.EmployeesTables == null)
          {
              return Problem("Entity set 'JobsPortalDbContext.EmployeesTables'  is null.");
          }
            _context.EmployeesTables.Add(employeesTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeesTable", new { id = employeesTable.EmployeeId }, employeesTable);
        }

        // DELETE: api/EmployeesTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeesTable(int id)
        {
            if (_context.EmployeesTables == null)
            {
                return NotFound();
            }
            var employeesTable = await _context.EmployeesTables.FindAsync(id);
            if (employeesTable == null)
            {
                return NotFound();
            }

            _context.EmployeesTables.Remove(employeesTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeesTableExists(int id)
        {
            return (_context.EmployeesTables?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
    }
}
