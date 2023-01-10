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
    public class BookingsController : ControllerBase
    {
        //refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //refactored
        //public BookingsController(ApplicationDbContext context)
        public BookingsController(IUnitOfWork unitOfWork)
        {
            //refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Bookings
        [HttpGet]
        //refactored
        //public async Task<ActionResult<IEnumerable<Make>>> GetBookings()
        public async Task<IActionResult> GetBookings()
        {
            //refactored
            //return await _context.Bookings.ToListAsync();
            var Bookings = await _unitOfWork.Bookings.GetAll();
            return Ok(Bookings);
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        //refactored
        //public async Task<ActionResult<Make>> GetMake(int id)
        public async Task<IActionResult> GetMake(int id)
        {
            //refactored
            //var make = await _context.Bookings.FindAsync(id);
            var make = await _unitOfWork.Bookings.Get(Queryable => Queryable.Id == id);

            if (make == null)
            {
                return NotFound();
            }

            //refactored
            return Ok(make);
        }

        // PUT: api/Bookings/5
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
            _unitOfWork.Bookings.Update(make);

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

        // POST: api/Bookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Make>> PostMake(Make make)
        {
            //Refactored
            //_context.Bookings.Add(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Bookings.Insert(make);
            await _unitOfWork.Save(HttpContext);


            return CreatedAtAction("GetMake", new { id = make.Id }, make);
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMake(int id)
        {
            //refactored
            //var make = await _context.Bookings.FindAsync(id);
            var make = await _unitOfWork.Bookings.Get(q => q.Id == id);
            if (make == null)
            {
                return NotFound();
            }

            //refactored
            //_context.Bookings.Remove(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Bookings.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //refactored
        //private bool MakeExists(int id)
        private async Task<bool> MakeExists(int id)
        {
            //refactored
            //return _context.Bookings.Any(e => e.Id == id);
            var make = await _unitOfWork.Bookings.Get(q => q.id == id);
            return make != null;
        }
    }
}
