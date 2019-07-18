using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SmartAC.Data;
using SmartAC.Models;
using SmartAC.Notification;

namespace SmartAC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        IHubContext<ChatHub, ITypedNotificationHub> _chatHubContext;
        private readonly DeviceContext _context;

        public DataController(DeviceContext context, IHubContext<ChatHub, ITypedNotificationHub> chatHubContext)
        {
            _context = context;
            _chatHubContext = chatHubContext;
        }

        // GET: api/Data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataReading>>> GetDataReadings()
        {
            return await _context.DataReadings.ToListAsync();
        }

        // GET: api/Data/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataReading>> GetDataReading(long id)
        {
            var dataReading = await _context.DataReadings.FindAsync(id);

            if (dataReading == null)
            {
                return NotFound();
            }

            return dataReading;
        }

        // PUT: api/Data/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataReading(long id, DataReading dataReading)
        {
            if (id != dataReading.Id)
            {
                return BadRequest();
            }

            _context.Entry(dataReading).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataReadingExists(id))
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

        // POST: api/Data
        [HttpPost]
        public async Task<ActionResult<DataReading>> PostDataReading(DataReading dataReading)
        {
            await _chatHubContext.Clients.All.BroadcastMessage(dataReading.SensorId.ToString(), dataReading.Status);
            _context.DataReadings.Add(dataReading);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDataReading", new { id = dataReading.Id }, dataReading);
        }

        // DELETE: api/Data/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataReading>> DeleteDataReading(long id)
        {
            var dataReading = await _context.DataReadings.FindAsync(id);
            if (dataReading == null)
            {
                return NotFound();
            }

            _context.DataReadings.Remove(dataReading);
            await _context.SaveChangesAsync();

            return dataReading;
        }

        private bool DataReadingExists(long id)
        {
            return _context.DataReadings.Any(e => e.Id == id);
        }
    }
}
