using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Saitynas.Models;

namespace Saitynas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblRatingsController : ControllerBase
    {
        private readonly SaitynasContext _context;

        public TblRatingsController(SaitynasContext context)
        {
            _context = context;
        }

        // GET: api/TblRatings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblRating>>> GetTblRating()
        {
            return await _context.TblRating.ToListAsync();
        }

        // GET: api/TblRatings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblRating>> GetTblRating(int id)
        {
            var tblRating = await _context.TblRating.FindAsync(id);

            if (tblRating == null)
            {
                return NotFound();
            }

            return tblRating;
        }

        // PUT: api/TblRatings/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblRating(int id, TblRating tblRating)
        {
            if (id != tblRating.RatingId)
            {
                return BadRequest();
            }

            _context.Entry(tblRating).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblRatingExists(id))
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

        // POST: api/TblRatings
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TblRating>> PostTblRating(TblRating tblRating)
        {
            _context.TblRating.Add(tblRating);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblRating", new { id = tblRating.RatingId }, tblRating);
        }

        // DELETE: api/TblRatings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblRating>> DeleteTblRating(int id)
        {
            var tblRating = await _context.TblRating.FindAsync(id);
            if (tblRating == null)
            {
                return NotFound();
            }

            _context.TblRating.Remove(tblRating);
            await _context.SaveChangesAsync();

            return tblRating;
        }

        private bool TblRatingExists(int id)
        {
            return _context.TblRating.Any(e => e.RatingId == id);
        }
    }
}
