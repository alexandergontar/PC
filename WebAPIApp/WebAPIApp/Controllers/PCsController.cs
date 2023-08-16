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
        PCsContext db;
        public PCsController(PCsContext context)
        {
            db = context;
            if (!db.PCs.Any())
            {
                //db.PCs.Add(new PC { PcItems = "Default", Disks = null, Id =1 });
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
    }
}
