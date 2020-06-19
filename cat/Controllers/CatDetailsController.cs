using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cat.Models;

namespace cat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatDetailsController : ControllerBase
    {
        private readonly CatDetailContext _context;

        public CatDetailsController(CatDetailContext context)
        {
            _context = context;
        }

        // GET: api/CatDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatDetail>>> GetCatDetails()
        {
            return await _context.CatDetails.ToListAsync();
        }

        // GET: api/CatDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatDetail>> GetCatDetail(int id)
        {
            var catDetail = await _context.CatDetails.FindAsync(id);

            if (catDetail == null)
            {
                return NotFound();
            }

            return catDetail;
        }

        // PUT: api/CatDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatDetail(int id, CatDetail catDetail)
        {
            if (id != catDetail.ID)
            {
                return BadRequest();
            }

            _context.Entry(catDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatDetailExists(id))
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

        // POST: api/CatDetails
        [HttpPost]
        public async Task<ActionResult<CatDetail>> PostCatDetail(CatDetail catDetail)
        {
            _context.CatDetails.Add(catDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatDetail", new { id = catDetail.ID }, catDetail);
        }

        // DELETE: api/CatDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CatDetail>> DeleteCatDetail(int id)
        {
            var catDetail = await _context.CatDetails.FindAsync(id);
            if (catDetail == null)
            {
                return NotFound();
            }

            _context.CatDetails.Remove(catDetail);
            await _context.SaveChangesAsync();

            return catDetail;
        }

        private bool CatDetailExists(int id)
        {
            return _context.CatDetails.Any(e => e.ID == id);
        }
    }
}
