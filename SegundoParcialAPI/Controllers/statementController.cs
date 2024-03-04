using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SegundoParcialAPI.Models;

namespace SegundoParcialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class statementController : ControllerBase
    {
        private readonly CreditContext _context;

        public statementController(CreditContext context)
        {
            _context = context;
        }

        // GET: api/statement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Statement>>> GetStatements()
        {
            return await _context.Statements.ToListAsync();
        }

        // GET: api/statement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Statement>> GetStatement(int id)
        {
            var statement = await _context.Statements.FindAsync(id);

            if (statement == null)
            {
                return NotFound();
            }

            return statement;
        }

        // PUT: api/statement/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatement(int id, Statement statement)
        {
            if (id != statement.StatementNo)
            {
                return BadRequest();
            }

            _context.Entry(statement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatementExists(id))
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

        // POST: api/statement
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Statement>> PostStatement(Statement statement)
        {
            _context.Statements.Add(statement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatement", new { id = statement.StatementNo }, statement);
        }

        // DELETE: api/statement/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatement(int id)
        {
            var statement = await _context.Statements.FindAsync(id);
            if (statement == null)
            {
                return NotFound();
            }

            _context.Statements.Remove(statement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatementExists(int id)
        {
            return _context.Statements.Any(e => e.StatementNo == id);
        }
    }
}
