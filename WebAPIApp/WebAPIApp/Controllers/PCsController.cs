using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPIApp.Models;


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
                //db.Users.Add(new User { Name = "Alice", Age = 31 });
                db.SaveChanges();
            }
            //db.SaveChanges();
        }

        //[Produces("application/json")]
        [FormatFilter]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PC>>> Get()
        {
           List<Disk> disks = await db.Disks.ToListAsync();
           List<PC> pcs = await db.PCs.ToListAsync();
            //return await db.PCs.ToListAsync();
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
            // если ошибок нет, сохраняем в базу данных
           //db.PCs. pc.Disks
            db.PCs.Add(pc);
            await db.SaveChangesAsync();
            return Ok(pc);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PC>> Delete(int id)
        {
            PC pc = db.PCs.FirstOrDefault(x => x.Id == id);
            if (pc == null)
            {
                return NotFound();
            }
            db.PCs.Remove(pc);
            await db.SaveChangesAsync();
            return Ok(pc);
        }
    }
}
