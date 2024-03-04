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
    public class chargeController : ControllerBase
    {
        private readonly CreditContext _context;

        public chargeController(CreditContext context)
        {
            _context = context;
        }

        // GET: api/charge
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Charge>>> GetCharges()
        {
            return await _context.Charges.ToListAsync();
        }

        // GET: api/charge/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Charge>> GetCharge(int id)
        {
            var charge = await _context.Charges.FindAsync(id);

            if (charge == null)
            {
                return NotFound();
            }

            return charge;
        }

        // PUT: api/charge/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharge(int id, Charge charge)
        {
            if (id != charge.ChargeNo)
            {
                return BadRequest();
            }

            _context.Entry(charge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChargeExists(id))
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

        // POST: api/charge
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Charge>> PostCharge(Charge charge)
        {
            _context.Charges.Add(charge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharge", new { id = charge.ChargeNo }, charge);
        }

        // DELETE: api/charge/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharge(int id)
        {
            var charge = await _context.Charges.FindAsync(id);
            if (charge == null)
            {
                return NotFound();
            }

            _context.Charges.Remove(charge);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChargeExists(int id)
        {
            return _context.Charges.Any(e => e.ChargeNo == id);
        }
    }
}
