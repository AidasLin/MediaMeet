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
    public class TblArtworksController : ControllerBase
    {
        private readonly SaitynasContext _context;

        public TblArtworksController(SaitynasContext context)
        {
            _context = context;
        }

        // GET: api/TblArtworks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblArtwork>>> GetTblArtwork()
        {
            return await _context.TblArtwork.ToListAsync();
        }

        // GET: api/TblArtworks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblArtwork>> GetTblArtwork(int id)
        {
            var tblArtwork = await _context.TblArtwork.FindAsync(id);

            if (tblArtwork == null)
            {
                return NotFound();
            }

            return tblArtwork;
        }

        // PUT: api/TblArtworks/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblArtwork(int id, TblArtwork tblArtwork)
        {
            if (id != tblArtwork.ArtworkId)
            {
                return BadRequest();
            }

            _context.Entry(tblArtwork).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblArtworkExists(id))
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

        // POST: api/TblArtworks
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TblArtwork>> PostTblArtwork(TblArtwork tblArtwork)
        {
            _context.TblArtwork.Add(tblArtwork);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblArtwork", new { id = tblArtwork.ArtworkId }, tblArtwork);
        }

        // DELETE: api/TblArtworks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblArtwork>> DeleteTblArtwork(int id)
        {
            var tblArtwork = await _context.TblArtwork.FindAsync(id);
            if (tblArtwork == null)
            {
                return NotFound();
            }

            _context.TblArtwork.Remove(tblArtwork);
            await _context.SaveChangesAsync();

            return tblArtwork;
        }

        private bool TblArtworkExists(int id)
        {
            return _context.TblArtwork.Any(e => e.ArtworkId == id);
        }
    }
}
