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
    public class ModelsController : ControllerBase
    {
        //refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //refactored
        //public ModelsController(ApplicationDbContext context)
        public ModelsController(IUnitOfWork unitOfWork)
        {
            //refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Models
        [HttpGet]
        //refactored
        //public async Task<ActionResult<IEnumerable<Make>>> GetModels()
        public async Task<IActionResult> GetModels()
        {
            //refactored
            //return await _context.Models.ToListAsync();
            var Models = await _unitOfWork.Models.GetAll();
            return Ok(Models);
        }

        // GET: api/Models/5
        [HttpGet("{id}")]
        //refactored
        //public async Task<ActionResult<Make>> GetMake(int id)
        public async Task<IActionResult> GetMake(int id)
        {
            //refactored
            //var make = await _context.Models.FindAsync(id);
            var make = await _unitOfWork.Models.Get(Queryable => Queryable.Id == id);

            if (make == null)
            {
                return NotFound();
            }

            //refactored
            return Ok(make);
        }

        // PUT: api/Models/5
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
            _unitOfWork.Models.Update(make);

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

        // POST: api/Models
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Make>> PostMake(Make make)
        {
            //Refactored
            //_context.Models.Add(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Models.Insert(make);
            await _unitOfWork.Save(HttpContext);


            return CreatedAtAction("GetMake", new { id = make.Id }, make);
        }

        // DELETE: api/Models/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMake(int id)
        {
            //refactored
            //var make = await _context.Models.FindAsync(id);
            var make = await _unitOfWork.Models.Get(q => q.Id == id);
            if (make == null)
            {
                return NotFound();
            }

            //refactored
            //_context.Models.Remove(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Models.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //refactored
        //private bool MakeExists(int id)
        private async Task<bool> MakeExists(int id)
        {
            //refactored
            //return _context.Models.Any(e => e.Id == id);
            var make = await _unitOfWork.Models.Get(q => q.id == id);
            return make != null;
        }
    }
}
