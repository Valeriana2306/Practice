using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RESTpr.Models;

namespace RESTpr.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsContext _context;
        public ProductsController(ProductsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProds()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProdsbyId(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost("{name}/{id}/{quant}")]
        public IActionResult PostProd(string name, int id, int quant)
        {
            var product = new Products()
            {
                p_Name = name,
                v_Id = id,
                p_Quant = quant
            };
            _context.Add(product);
            _context.SaveChanges();
            return Ok("Created");
        }

        [HttpPut("{id}/{rename}/{id2}/{requant}")]
        public IActionResult PutProd(int id, string rename, int id2, int requant)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            product.p_Name = rename;
            product.v_Id = id2;
            product.p_Quant = requant;
            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok("Update");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProd(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}