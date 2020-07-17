using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RESTpr.Models;

namespace RESTpr.Controllers
{
    [Route("api/Venders")]
    [ApiController]
    public class VendersController : ControllerBase
    {
        private readonly VendersContext _context;
        public VendersController(VendersContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetVens()
        {
            var venders = _context.Venders.ToList();
            return Ok(venders);
        }

        [HttpGet("{id}")]
        public IActionResult GetVensbyId(int id)
        {
            var vender = _context.Venders.Find(id);
            if (vender == null)
            {
                return NotFound();
            }
            return Ok(vender);
        }

        [HttpPost("{name}")]
        public IActionResult PostVen(string name)
        {
            var vender = new Venders()
            {
                v_Name = name
            };
            _context.Add(vender);
            _context.SaveChanges();
            return Ok("Created");
        }

        [HttpPut("{id}/{rename}")]
        public IActionResult PutVens(int id, string rename)
        {
            var vender = _context.Venders.Find(id);
            if (vender == null)
            {
                return NotFound();
            }
            vender.v_Name = rename;
            _context.Venders.Update(vender);
            _context.SaveChanges();
            return Ok("Update");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVen(int id)
        {
            var vender = _context.Venders.Find(id);
            if (vender == null)
            {
                return NotFound();
            }
            _context.Venders.Remove(vender);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}
