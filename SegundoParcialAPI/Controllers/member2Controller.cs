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
    public class member2Controller : ControllerBase
    {
        private readonly CreditContext _context;

        public member2Controller(CreditContext context)
        {
            _context = context;
        }

        // GET: api/member2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member2>>> GetMember2s()
        {
            return await _context.Member2s.ToListAsync();
        }

        // GET: api/member2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Member2>> GetMember2(int id)
        {
            var member2 = await _context.Member2s.FindAsync(id);

            if (member2 == null)
            {
                return NotFound();
            }

            return member2;
        }

        // PUT: api/member2/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember2(int id, Member2 member2)
        {
            if (id != member2.MemberNo)
            {
                return BadRequest();
            }

            _context.Entry(member2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Member2Exists(id))
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

        // POST: api/member2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Member2>> PostMember2(Member2 member2)
        {
            _context.Member2s.Add(member2);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Member2Exists(member2.MemberNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMember2", new { id = member2.MemberNo }, member2);
        }

        // DELETE: api/member2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember2(int id)
        {
            var member2 = await _context.Member2s.FindAsync(id);
            if (member2 == null)
            {
                return NotFound();
            }

            _context.Member2s.Remove(member2);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Member2Exists(int id)
        {
            return _context.Member2s.Any(e => e.MemberNo == id);
        }
    }
}
