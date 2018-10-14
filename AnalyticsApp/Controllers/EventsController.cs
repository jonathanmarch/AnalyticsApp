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
    [Route("api/events")]
    public class EventsController : Controller
    {
        private readonly AnalyticsAppContext _context;

        public EventsController(AnalyticsAppContext context)
        {
            _context = context;
        }

        // GET: api/events
        [HttpGet]
        public IEnumerable<Event> GetEvent()
        {
            return _context.Event;
        }

        // GET: api/events/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = await _context.Event.SingleOrDefaultAsync(m => m.EventId == id);

            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // POST: api/events
        [HttpPost]
        public async Task<IActionResult> PostEvent([FromRoute] Guid WebsiteId, [FromBody] Event @event)
        {
            var website = await _context.Website.SingleOrDefaultAsync(m => m.WebsiteId == WebsiteId);

            if (website == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            @event.IpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            _context.Event.Add(@event);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = @event.EventId }, @event);
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.EventId == id);
        }
    }
}