using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.dtb;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class FoodsController : ControllerBase
        {
            private readonly Context _context;
            public FoodsController(Context context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Food>>> GetValues()
            {
                var values = await _context.Foods.ToListAsync();
                if (values != null)
                {
                    return values;
                }
                else
                {
                    return NotFound();
                }
            }

            [HttpPost]
            public async Task<ActionResult<Food>> Post_Values(Food Food)
            {
                _context.Foods.Add(Food);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetValues", new { barcode = Food.barcode }, Food);
            }

            [HttpDelete("{barcode}")]
            public async Task<ActionResult<Food>> Delete_values(int barcode)
            {
                var values = await _context.Foods.FindAsync(barcode);
                if (values == null)
                {
                    return NotFound();
                }
                _context.Foods.Remove(values);
                await _context.SaveChangesAsync();
                return values;
            }


            [HttpPut("{barcode}")]
            public async Task<IActionResult> Put_Values(int barcode, Food Food)
            {
                if (barcode != Food.barcode)
                {
                    return BadRequest();
                }

                _context.Entry(Food).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ValuesExists(barcode))
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

            private bool ValuesExists(int barcode)
            {
                return _context.Foods.Any(x => x.barcode == barcode);
            }
        }
    }

