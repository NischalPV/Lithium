using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iManage.Data;
using iManage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace iManage.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("api/[controller]")]
        public async Task<IActionResult> Index()
        {
            var clients = await _context.Clients.ToListAsync();
            return Ok(clients.OrderBy(c => c.CreatedDate));
        }

        [HttpPost]
        [Route("api/[controller]/[action]")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody]Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return Ok(client);
        }

        [Route("api/[controller]/[action]/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
                return NotFound();
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost]
        [Route("api/[controller]/[action]/{id}")]
        public async Task<IActionResult> Update(string id, [FromBody]Client client)
        {
            if (id == null)
                return NotFound();
            var dbClient = await _context.Clients.FindAsync(id);
            

            dbClient.Name = client.Name;
            dbClient.Phone = client.Phone;
            dbClient.Occupation = client.Occupation;
            dbClient.ModifiedDate = DateTime.UtcNow;

            try
            {
                _context.Clients.Update(dbClient);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (dbClient == null)
                    return NotFound();
                else
                    throw;
            }

            return Ok(dbClient);
        }
    }
}