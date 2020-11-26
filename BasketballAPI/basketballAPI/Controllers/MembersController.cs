using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using basketballAPI.Models;

namespace basketballAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly basketballDBContext _context;

        public MembersController(basketballDBContext context)
        {
            _context = context;
        }

        // GET: api/Members
        [HttpGet, Route("login")]
        public IActionResult Login(string username, string password)
        {
            var member = _context.Members.Where(m => m.Memberid == username && m.Memberpassword == password).FirstOrDefault();
            if (member != null)
            {
                return Ok(member);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost, Route("registered")]
        public IActionResult Register(Member member)
        {
            _context.Add(member);
            _context.SaveChanges();
            return Ok(member);
        }
        [HttpPost, Route("fixture")]
        public IActionResult Fixture(Fixture fixture)
        {
            _context.Add(fixture);
            _context.SaveChanges();
            return Ok(fixture);
        }

        [HttpGet, Route("futurefixture")]
        public IActionResult GetFuturefixture()
        {
            var fixture = _context.Fixtures.Where(b => b.Fixturedate >= DateTime.Now).ToList();
            if (fixture != null)
            {
                return Ok(fixture);
            }
            else
            {
                return NotFound();
            }
        }

        //[HttpPut] ("{fixture}")]
        //public async IActionResult UpdatefutureFixture(Fixture fixtureRemove)
        //{
        //    if (fixture = fixtureRemove)
        //    {
        //        _context.Remove(Fixture);
        //        _context.SaveChanges();
        //        return Ok(Fixture);
        //    }
        //}



        // DELETE: api/Members/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMember(string id)
        //{
        //    var member = await _context.Members.FindAsync(id);
        //    if (member == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Members.Remove(member);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}


    }
}
