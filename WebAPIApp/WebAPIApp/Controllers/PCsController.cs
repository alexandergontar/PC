using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPIApp.Models;
using System.Collections;

namespace WebAPIApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PCsController : ControllerBase
    {
        UsersContext db;
        public PCsController(UsersContext context)
        {
            db = context;
            if (!db.PCs.Any())
            {
                db.PCs.Add(new PC { PcItems = "Default", Disks = null });                
                db.SaveChanges();
            }
            
        }

        //[Produces("application/json")]
        [FormatFilter]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PC>>> Get()
        {
            List<Disk> disks = await db.Disks.ToListAsync();
            List<PC> pcs = await db.PCs.ToListAsync();            
            return pcs;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PC>> Get(int id)
        {
            List<Disk> disks = await db.Disks.ToListAsync();
            PC pc = await db.PCs.FirstOrDefaultAsync(x => x.Id == id);
            if (pc == null)
                return NotFound();
            Console.WriteLine(pc.Disks);
            return new ObjectResult(pc);

        }

        [HttpPost]
        public async Task<ActionResult<PC>> Post(PC pc)
        {
            if (pc == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            // ---- Delete if exists
            PC existingPc = db.PCs.Where(s => s.PcItems == pc.PcItems)
                  .FirstOrDefault<PC>();
            if (existingPc != null)
            {
                await Delete(existingPc.Id);
            }
            // --- End of Delete
            // если ошибок нет, сохраняем в базу данных
            //db.PCs. pc.Disks
            db.PCs.Add(pc);
            await db.SaveChangesAsync();
            return Ok(pc);
        }

        // PUT api/PCs/
        [HttpPut]
        public async Task<ActionResult<PC>> Put(PC pc)
        {
            if (pc == null)
            {
                return BadRequest();
            }            

            PC existingPc = db.PCs.Where(s => s.PcItems == pc.PcItems)
                  .FirstOrDefault<PC>();
            if (existingPc != null)
            {                
                existingPc.Disks = pc.Disks;
                await db.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }            
            return Ok(pc);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PC>> Delete(int id)
        {
            PC pc = db.PCs
             .Where(f => f.Id == id)
             .Include(f => f.Disks)
             .FirstOrDefault();            
            List<Disk> disks = pc.Disks;
            foreach (Disk disk in disks)
            {                
                db.Disks.Remove(disk);
            }            
            db.PCs.Remove(pc);
            await db.SaveChangesAsync();
            return Ok(pc);
        }
    }
}
