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
    public class ColoursController : ControllerBase
    {
        //refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //refactored
        //public ColoursController(ApplicationDbContext context)
        public ColoursController(IUnitOfWork unitOfWork)
        {
            //refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Colours
        [HttpGet]
        //refactored
        //public async Task<ActionResult<IEnumerable<Make>>> GetColours()
        public async Task<IActionResult> GetColours()
        {
            //refactored
            //return await _context.Colours.ToListAsync();
            var Colours = await _unitOfWork.Colours.GetAll();
            return Ok(Colours);
        }

        // GET: api/Colours/5
        [HttpGet("{id}")]
        //refactored
        //public async Task<ActionResult<Make>> GetMake(int id)
        public async Task<IActionResult> GetMake(int id)
        {
            //refactored
            //var make = await _context.Colours.FindAsync(id);
            var make = await _unitOfWork.Colours.Get(Queryable => Queryable.Id == id);

            if (make == null)
            {
                return NotFound();
            }

            //refactored
            return Ok(make);
        }

        // PUT: api/Colours/5
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
            _unitOfWork.Colours.Update(make);

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

        // POST: api/Colours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Make>> PostMake(Make make)
        {
            //Refactored
            //_context.Colours.Add(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Colours.Insert(make);
            await _unitOfWork.Save(HttpContext);


            return CreatedAtAction("GetMake", new { id = make.Id }, make);
        }

        // DELETE: api/Colours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMake(int id)
        {
            //refactored
            //var make = await _context.Colours.FindAsync(id);
            var make = await _unitOfWork.Colours.Get(q => q.Id == id);
            if (make == null)
            {
                return NotFound();
            }

            //refactored
            //_context.Colours.Remove(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Colours.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //refactored
        //private bool MakeExists(int id)
        private async Task<bool> MakeExists(int id)
        {
            //refactored
            //return _context.Colours.Any(e => e.Id == id);
            var make = await _unitOfWork.Colours.Get(q => q.id == id);
            return make != null;
        }
    }
}
