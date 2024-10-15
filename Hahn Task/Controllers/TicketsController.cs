using Hahn_Task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketManagementApi.Data;

namespace TicketManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets(
            int pageNumber = 1,
            int pageSize = 10,
            string? filter = null,
            string? sortBy = null,
            bool ascending = true)
        {
            try
            {
                var ticketsQuery = _context.Tickets.AsQueryable();

                if (!string.IsNullOrEmpty(filter))
                {
                    ticketsQuery = ticketsQuery.Where(t => t.Description.Contains(filter));
                }

                if (!string.IsNullOrEmpty(sortBy))
                {
                    ticketsQuery = sortBy.ToLower() switch
                    {
                        "description" => ascending ? ticketsQuery.OrderBy(t => t.Description) : ticketsQuery.OrderByDescending(t => t.Description),
                        "status" => ascending ? ticketsQuery.OrderBy(t => t.Status) : ticketsQuery.OrderByDescending(t => t.Status),
                        "date" => ascending ? ticketsQuery.OrderBy(t => t.Date) : ticketsQuery.OrderByDescending(t => t.Date),
                        _ => ticketsQuery
                    };
                }

                var tickets = await ticketsQuery
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return Ok(tickets);
            }
            catch (Exception ex)
            {
                // Log the exception details (e.g., to a file or monitoring system)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving tickets.");
            }
        }

        // POST: api/tickets
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {
            try
            {
                _context.Tickets.Add(ticket);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetTickets), new { id = ticket.TicketId }, ticket);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while saving the ticket.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        // PUT: api/tickets/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, Ticket ticket)
        {
            if (id != ticket.TicketId)
            {
                return BadRequest("Ticket ID mismatch.");
            }

            _context.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Tickets.Any(t => t.TicketId == id))
                {
                    return NotFound("Ticket not found.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "A concurrency error occurred.");
                }
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the ticket.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        // DELETE: api/tickets/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            try
            {
                var ticket = await _context.Tickets.FindAsync(id);
                if (ticket == null)
                {
                    return NotFound("Ticket not found.");
                }

                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the ticket.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }
    }
}
