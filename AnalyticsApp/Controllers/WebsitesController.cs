using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnalyticsApp.Models;

namespace AnalyticsApp.Controllers
{
    [Produces("application/json")]
    [Route("api/websites")]
    public class WebsitesController : Controller
    {
        private readonly AnalyticsAppContext _context;

        public WebsitesController(AnalyticsAppContext context)
        {
            _context = context;
        }

        // GET: api/websites
        [HttpGet]
        public IEnumerable<Website> GetWebsite()
        {
            return _context.Website;
        }

        // GET: api/websites/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWebsite([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var website = await _context.Website.SingleOrDefaultAsync(m => m.WebsiteId == id);

            if (website == null)
            {
                return NotFound();
            }

            return Ok(website);
        }

        // PUT: api/websites/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWebsite([FromRoute] int id, [FromBody] Website website)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != website.WebsiteId)
            {
                return BadRequest();
            }

            _context.Entry(website).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebsiteExists(id))
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

        // POST: api/websites
        [HttpPost]
        public async Task<IActionResult> PostWebsite([FromBody] Website website)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Website.Add(website);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWebsite", new { id = website.WebsiteId }, website);
        }

        // DELETE: api/websites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWebsite([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var website = await _context.Website.SingleOrDefaultAsync(m => m.WebsiteId == id);
            if (website == null)
            {
                return NotFound();
            }

            _context.Website.Remove(website);
            await _context.SaveChangesAsync();

            return Ok(website);
        }

        private bool WebsiteExists(int id)
        {
            return _context.Website.Any(e => e.WebsiteId == id);
        }
    }
}