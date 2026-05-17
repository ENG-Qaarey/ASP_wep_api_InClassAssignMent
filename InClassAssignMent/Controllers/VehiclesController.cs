using InClassAssignMent.Data;
using InClassAssignMent.Models.Vehicles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InClassAssignMent.Controllers
{
    [Route("api/VehiclesController")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VehiclesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicles>>> GetVehicles()
        {
            return await _context.Vehicles.Include(v => v.Customar).Include(v => v.VehicleServiceTypes).ThenInclude(vst => vst.ServiceType).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicles>> GetVehicle(int id)
        {
            var vehicle = await _context.Vehicles.Include(v => v.Customar).Include(v => v.VehicleServiceTypes).ThenInclude(vst => vst.ServiceType).FirstOrDefaultAsync(v => v.Id == id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return vehicle;
        }

        [HttpPost]
        public async Task<ActionResult<Vehicles>> PostVehicle(InClassAssignMent.Models.DTOs.VehicleCreateDto dto)
        {
            var vehicle = new Vehicles
            {
                Make = dto.Make,
                Model = dto.Model,
                Year = dto.Year,
                CustomarId = dto.CustomarId
            };

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVehicle), new { id = vehicle.Id }, vehicle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, InClassAssignMent.Models.DTOs.VehicleCreateDto dto)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            vehicle.Make = dto.Make;
            vehicle.Model = dto.Model;
            vehicle.Year = dto.Year;
            vehicle.CustomarId = dto.CustomarId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
