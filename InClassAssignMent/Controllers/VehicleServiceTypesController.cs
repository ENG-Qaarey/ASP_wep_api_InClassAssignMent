using InClassAssignMent.Data;
using InClassAssignMent.Models.VehicleServiceType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InClassAssignMent.Controllers
{
    [Route("api/VehicleServiceTypesController")]
    [ApiController]
    public class VehicleServiceTypesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VehicleServiceTypesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleServiceType>>> GetVehicleServiceTypes()
        {
            return await _context.VehicleServiceTypes.Include(vst => vst.Vehicle).Include(vst => vst.ServiceType).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<VehicleServiceType>> PostVehicleServiceType(InClassAssignMent.Models.DTOs.VehicleServiceTypeCreateDto dto)
        {
            var vehicleServiceType = new VehicleServiceType
            {
                VehicleId = dto.VehicleId,
                ServiceTypeId = dto.ServiceTypeId,
                ServiceDate = dto.ServiceDate.Kind == DateTimeKind.Utc ? dto.ServiceDate : dto.ServiceDate.ToUniversalTime()
            };

            _context.VehicleServiceTypes.Add(vehicleServiceType);
            await _context.SaveChangesAsync();

            return Ok(vehicleServiceType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleServiceType(int id, InClassAssignMent.Models.DTOs.VehicleServiceTypeCreateDto dto)
        {
            var vehicleServiceType = await _context.VehicleServiceTypes.FindAsync(id);
            if (vehicleServiceType == null)
            {
                return NotFound();
            }

            vehicleServiceType.VehicleId = dto.VehicleId;
            vehicleServiceType.ServiceTypeId = dto.ServiceTypeId;
            vehicleServiceType.ServiceDate = dto.ServiceDate.Kind == DateTimeKind.Utc ? dto.ServiceDate : dto.ServiceDate.ToUniversalTime();

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleServiceType(int id)
        {
            var vehicleServiceType = await _context.VehicleServiceTypes.FindAsync(id);
            if (vehicleServiceType == null)
            {
                return NotFound();
            }

            _context.VehicleServiceTypes.Remove(vehicleServiceType);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
