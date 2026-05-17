using InClassAssignMent.Data;
using InClassAssignMent.Models.Customars;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InClassAssignMent.Controllers
{
    [Route("api/CustomersController")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customar>>> GetCustomers()
        {
            return await _context.Customars.Include(c => c.Vehicles).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customar>> GetCustomer(int id)
        {
            var customer = await _context.Customars.Include(c => c.Vehicles).FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpPost]
        public async Task<ActionResult<Customar>> PostCustomer(InClassAssignMent.Models.DTOs.CustomarCreateDto dto)
        {
            var customer = new Customar
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone
            };

            _context.Customars.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, InClassAssignMent.Models.DTOs.CustomarCreateDto dto)
        {
            var customer = await _context.Customars.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            customer.Name = dto.Name;
            customer.Email = dto.Email;
            customer.Phone = dto.Phone;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customars.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customars.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
