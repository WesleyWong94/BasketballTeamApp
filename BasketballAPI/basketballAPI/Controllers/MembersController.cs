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
        private readonly BASKETBALLDBContext _context;

        public MembersController(BASKETBALLDBContext context)
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

        [HttpGet, Route("pastfixture")]
        public IActionResult GetPastfixture()
        {
            var fixture = _context.Fixtures.Where(b => b.Fixturedate < DateTime.Now).ToList();
            if (fixture != null)
            {
                return Ok(fixture);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost, Route("updatefixture")]
        public IActionResult UpdateFutureFixture(Fixture fixture)
        {
            _context.Fixtures.Update(fixture);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete, Route("deletefixture")]
        public IActionResult DeleteFutureFixture(int fixtureid)
        {
            var fixture = _context.Fixtures.Where(fix => fix.Fixtureid == fixtureid).FirstOrDefault();

            _context.Fixtures.Remove(fixture);
            _context.SaveChanges();
            return Ok();
        }

        


    }
}
