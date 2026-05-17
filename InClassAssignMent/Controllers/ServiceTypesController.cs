using InClassAssignMent.Data;
using InClassAssignMent.Models.ServiceType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InClassAssignMent.Controllers
{
    [Route("api/ServiceTypesController")]
    [ApiController]
    public class ServiceTypesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServiceTypesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceType>>> GetServiceTypes()
        {
            return await _context.ServiceTypes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceType>> GetServiceType(int id)
        {
            var serviceType = await _context.ServiceTypes.FindAsync(id);

            if (serviceType == null)
            {
                return NotFound();
            }

            return serviceType;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceType>> PostServiceType(InClassAssignMent.Models.DTOs.ServiceTypeCreateDto dto)
        {
            var serviceType = new ServiceType
            {
                Name = dto.Name,
                Description = dto.Description,
                Cost = dto.Cost
            };

            _context.ServiceTypes.Add(serviceType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetServiceType), new { id = serviceType.Id }, serviceType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceType(int id, InClassAssignMent.Models.DTOs.ServiceTypeCreateDto dto)
        {
            var serviceType = await _context.ServiceTypes.FindAsync(id);
            if (serviceType == null)
            {
                return NotFound();
            }

            serviceType.Name = dto.Name;
            serviceType.Description = dto.Description;
            serviceType.Cost = dto.Cost;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceType(int id)
        {
            var serviceType = await _context.ServiceTypes.FindAsync(id);
            if (serviceType == null)
            {
                return NotFound();
            }

            _context.ServiceTypes.Remove(serviceType);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
