using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepairServiceManagement.API.Data;
using RepairServiceManagement.API.Models.RepairRequest;

namespace RepairServiceManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairRequestsController : ControllerBase
    {
        private readonly RepairServiceDbContext _context;
        private readonly IMapper _mapper;

        public RepairRequestsController(RepairServiceDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/RepairRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetRepairRequestsDto>>> GetRepairRequests()
        {
            var repairRequests = await _context.RepairRequests.ToListAsync();
            return Ok(_mapper.Map<List<GetRepairRequestsDto>>(repairRequests));
        }

        // GET: api/RepairRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetRepairRequestDetailDto>> GetRepairRequest(int id)
        {
            var repairRequest = await _context.RepairRequests.FindAsync(id);

            if (repairRequest == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GetRepairRequestDetailDto>(repairRequest));
        }

        // PUT: api/RepairRequests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepairRequest(int id, RepairRequest repairRequest)
        {
            if (id != repairRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(repairRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepairRequestExists(id))
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

        // POST: api/RepairRequests
        [HttpPost]
        public async Task<ActionResult<RepairRequest>> PostRepairRequest(CreateRepairRequestDto createRepairRequest)
        {
            var repairRequest = _mapper.Map<RepairRequest>(createRepairRequest);
            _context.RepairRequests.Add(repairRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRepairRequest", new { id = repairRequest.Id }, repairRequest);
        }

        // DELETE: api/RepairRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepairRequest(int id)
        {
            var repairRequest = await _context.RepairRequests.FindAsync(id);
            if (repairRequest == null)
            {
                return NotFound();
            }

            _context.RepairRequests.Remove(repairRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepairRequestExists(int id)
        {
            return _context.RepairRequests.Any(e => e.Id == id);
        }
    }
}
