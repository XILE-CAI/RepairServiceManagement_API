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
using RepairServiceManagement.API.Models.Customer;

namespace RepairServiceManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomersRepository _customersRepository;

        public CustomersController( IMapper mapper, ICustomersRepository customersRepository)
        {
            this._mapper = mapper;
            this._customersRepository = customersRepository;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCustomersDto>>> GetCustomers()
        {
            var customers = await _customersRepository.GetAllAsync();
            return Ok(_mapper.Map<List<GetCustomersDto>>(customers));
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCustomerDetailDto>> GetCustomer(int id)
        {
            var customer = await _customersRepository.GetDetails(id); 

            //include list of repairRequests in Customer
            /*var customer = await _context.Customers
                .Include(c => c.RepairRequests)
                .FirstOrDefaultAsync(c => c.Id == id);*/

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GetCustomerDetailDto>(customer));
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, UpdateCustomerDto updateCustomerDto)
        {
            //verify customer ID that need to be updated
            if (id != updateCustomerDto.Id)
            {
                return BadRequest();
            }

            //verify the customer that need to be updated
            var customer = await _customersRepository.GetAsync(id);
            if(customer == null)
            {
                return NotFound();
            }

            //var updateCustomer = _mapper.Map<Customer>(updateCustomerDto);
            //Set the state to indicate that it has been modified
            //_context.Entry(customer).State = EntityState.Modified;

            _mapper.Map(updateCustomerDto,customer);

            try
            {
                await _customersRepository.UpdateAsync(customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return 204
            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(CreateCustomerDto createCustomerDto)
        {
            var customer = _mapper.Map<Customer>(createCustomerDto);
            await _customersRepository.AddAsync(customer);
            
            //201 Created
            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _customersRepository.GetAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            await _customersRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CustomerExists(int id)
        {
            var customer = await _customersRepository.GetAsync(id);
            return customer != null;
        }
    }
}
