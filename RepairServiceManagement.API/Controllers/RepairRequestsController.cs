using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepairServiceManagement.API.Data;
using RepairServiceManagement.API.IRepository;
using RepairServiceManagement.API.Models.RepairRequest;

namespace RepairServiceManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairRequestsController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly IRepairRequestsRepository _repairRequestsRepository;

        public RepairRequestsController(IMapper mapper, IRepairRequestsRepository repairRequestsRepository)
        {
            this._mapper = mapper;
            this._repairRequestsRepository = repairRequestsRepository;
        }

        // GET: api/RepairRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetRepairRequestsDto>>> GetRepairRequests()
        {
            var repairRequests = await _repairRequestsRepository.GetAllAsync();
            return Ok(_mapper.Map<List<GetRepairRequestsDto>>(repairRequests));
        }

        // GET: api/RepairRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetRepairRequestDetailDto>> GetRepairRequest(int id)
        {
            var repairRequest = await _repairRequestsRepository.GetAsync(id);

            if (repairRequest == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GetRepairRequestDetailDto>(repairRequest));
        }

        // PUT: api/RepairRequests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepairRequest(int id, UpdateRepairRequestDto updateRepairRequestDto)
        {
            if (id != updateRepairRequestDto.Id)
            {
                return BadRequest();
            }
            
            //verify the repairRequest that need to be updated 
            var repairRequest = await _repairRequestsRepository.GetAsync(id);
            if (repairRequest == null)
            {
                return NotFound();
            }

            //map updateRepairRequestDto to repairRequest
            //var updateRequest = _mapper.Map<RepairRequest>(updateRepairRequestDto);
            _mapper.Map(updateRepairRequestDto, repairRequest);

            try
            {
                await _repairRequestsRepository.UpdateAsync(repairRequest);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await RepairRequestExists(id))
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
            await _repairRequestsRepository.AddAsync(repairRequest);

            //201 Created
            return CreatedAtAction("GetRepairRequest", new { id = repairRequest.Id }, repairRequest);
        }

        // DELETE: api/RepairRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepairRequest(int id)
        {
            var repairRequest = await _repairRequestsRepository.GetAsync(id);
            if (repairRequest == null)
            {
                return NotFound();
            }

            await _repairRequestsRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> RepairRequestExists(int id)
        {
            return await _repairRequestsRepository.Exists(id);
        }
    }
}
