using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiregister.Model;
using WebApiregister.Models;
using WebApiregister.utils;

namespace WebApiregister.Controllers
{






    [Route("api/[controller]")]
    [ApiController]
    public class registrationsController : ControllerBase
    {
        private readonly registerContextClass _context;

        public registrationsController(registerContextClass context)
        {
            _context = context;
        }

        // GET: api/registrations
        [HttpGet]
        [Route("Geturegister")]
        public async Task<ActionResult<IEnumerable<registration>>> Geturegister()
        {
            return await _context.uregister.ToListAsync();
        }

        // GET: api/registrations/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<registration>> Getregistration(int Id)
        {
            var registration = await _context.uregister.FindAsync(Id);

            if (registration == null)
            {
                return NotFound();
            }

            return registration;
        }

        // PUT: api/registrations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putregistration(int id, registration registration)
        {
            if (id != registration.Id)
            {
                return BadRequest();
            }

            _context.Entry(registration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!registrationExists(id))
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

        // POST: api/registrations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("Postregistration")]
        public async Task<ActionResult<registration>> Postregistration(registration registration)
        {
            EmailSend em = new EmailSend();
            Random rn = new Random();
            int Pswd = rn.Next(1000);
            string PSW = Pswd.ToString();
            registration.Password = Pswd;
            em.SendEmail(registration.Email,PSW,"Your password");
            _context.uregister.Add(registration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getregistration", new { id = registration.Id }, registration);
        }

        // DELETE: api/registrations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<registration>> Deleteregistration(int id)
        {
            var registration = await _context.uregister.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }

            _context.uregister.Remove(registration);
            await _context.SaveChangesAsync();

            return registration;
        }

        private bool registrationExists(int id)
        {
            return _context.uregister.Any(e => e.Id == id);
        }
    }
}
