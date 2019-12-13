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
    public class TblCreatorsController : ControllerBase
    {
        private readonly SaitynasContext _context;

        public TblCreatorsController(SaitynasContext context)
        {
            _context = context;
        }

        // GET: api/TblCreators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCreator>>> GetTblCreator()
        {
            return await _context.TblCreator.ToListAsync();
        }

        // GET: api/TblCreators/5
        [HttpGet("{id}")]
        public TblCreator GetTblCreator(int id)
        {
            var tblCreator = _context.TblCreator.Find(id);
            if (tblCreator == null)
            {
                return null;
            }

            return tblCreator;
        }

        // PUT: api/TblCreators/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCreator(int id, TblCreator tblCreator)
        {
            if (id != tblCreator.CreatorId)
            {
                return BadRequest();
            }

            _context.Entry(tblCreator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCreatorExists(id))
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

        // POST: api/TblCreators
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TblCreator>> PostTblCreator(TblCreator tblCreator)
        {
            _context.TblCreator.Add(tblCreator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblCreator", new { id = tblCreator.CreatorId }, tblCreator);
        }

        // DELETE: api/TblCreators/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblCreator>> DeleteTblCreator(int id)
        {
            var tblCreator = await _context.TblCreator.FindAsync(id);
            if (tblCreator == null)
            {
                return NotFound();
            }

            _context.TblCreator.Remove(tblCreator);
            await _context.SaveChangesAsync();

            return tblCreator;
        }

        private bool TblCreatorExists(int id)
        {
            return _context.TblCreator.Any(e => e.CreatorId == id);
        }
    }
}
