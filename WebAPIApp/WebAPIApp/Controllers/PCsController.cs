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
            return await db.PCs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PC>> Get(int id)
        {
            PC pc = await db.PCs.FirstOrDefaultAsync(x => x.Id == id);
            if (pc == null)
                return NotFound();
            return new ObjectResult(pc);
        }
    }
}
