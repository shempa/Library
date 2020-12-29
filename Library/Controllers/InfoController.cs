using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfoController : ControllerBase
    {
        LibraryContext db;
        public InfoController(LibraryContext context)
        {
            db = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetInfo(int id)
        {
            return await db.Books.Where(x => x.UserId == id).ToListAsync();
        }
    }
}
