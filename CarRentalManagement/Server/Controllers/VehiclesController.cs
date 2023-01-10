using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalManagement.Server.Data;
using CarRentalManagement.Shared.Domain;
using CarRentalManagement.Server.IRepository;

namespace CarRentalManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        //refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //refactored
        //public VehiclesController(ApplicationDbContext context)
        public VehiclesController(IUnitOfWork unitOfWork)
        {
            //refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Vehicles
        [HttpGet]
        //refactored
        //public async Task<ActionResult<IEnumerable<Make>>> GetVehicles()
        public async Task<IActionResult> GetVehicles()
        {
            //refactored
            //return await _context.Vehicles.ToListAsync();
            var Vehicles = await _unitOfWork.Vehicles.GetAll();
            return Ok(Vehicles);
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        //refactored
        //public async Task<ActionResult<Make>> GetMake(int id)
        public async Task<IActionResult> GetMake(int id)
        {
            //refactored
            //var make = await _context.Vehicles.FindAsync(id);
            var make = await _unitOfWork.Vehicles.Get(Queryable => Queryable.Id == id);

            if (make == null)
            {
                return NotFound();
            }

            //refactored
            return Ok(make);
        }

        // PUT: api/Vehicles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMake(int id, Make make)
        {
            if (id != make.Id)
            {
                return BadRequest();
            }

            //refactored
            //_context.Entry(make).State = EntityState.Modified;
            _unitOfWork.Vehicles.Update(make);

            try
            {
                //refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }   
            catch (DbUpdateConcurrencyException)
            {
                //refactored
                //if (!MakeExists(id))
                if (!await MakeExists(id))
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

        // POST: api/Vehicles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Make>> PostMake(Make make)
        {
            //Refactored
            //_context.Vehicles.Add(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Vehicles.Insert(make);
            await _unitOfWork.Save(HttpContext);


            return CreatedAtAction("GetMake", new { id = make.Id }, make);
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMake(int id)
        {
            //refactored
            //var make = await _context.Vehicles.FindAsync(id);
            var make = await _unitOfWork.Vehicles.Get(q => q.Id == id);
            if (make == null)
            {
                return NotFound();
            }

            //refactored
            //_context.Vehicles.Remove(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Vehicles.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //refactored
        //private bool MakeExists(int id)
        private async Task<bool> MakeExists(int id)
        {
            //refactored
            //return _context.Vehicles.Any(e => e.Id == id);
            var make = await _unitOfWork.Vehicles.Get(q => q.id == id);
            return make != null;
        }
    }
}
