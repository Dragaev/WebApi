using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonItemsController : ControllerBase
    {
        private readonly PersonItemContext _context;

        public PersonItemsController(PersonItemContext context)
        {
            _context = context;
        }

        // GET: api/PersonItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonItem>>> GetPersonItems()
        {
            return await _context.PersonItems.ToListAsync();
        }

        // GET: api/PersonItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonItem>> GetPersonItem(long id)
        {
            var personItem = await _context.PersonItems.FindAsync(id);

            if (personItem == null)
            {
                return NotFound();
            }

            return personItem;
        }

        // PUT: api/PersonItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonItem(long id, PersonItem personItem)
        {
            if (id != personItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(personItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonItemExists(id))
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

        // POST: api/PersonItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonItem>> PostPersonItem(PersonItem personItem)
        {
            _context.PersonItems.Add(personItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetPersonItem), new { id = personItem.Id }, personItem);
        }

        // DELETE: api/PersonItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonItem(long id)
        {
            var todoItem = await _context.PersonItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.PersonItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonItemExists(long id)
        {
            return _context.PersonItems.Any(e => e.Id == id);
        }
    }
}
