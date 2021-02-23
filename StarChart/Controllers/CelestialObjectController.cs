using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarChart.Data;
using StarChart.Models;

namespace StarChart.Controllers
{
    [Route("")]
    [ApiController]
    public class CelestialObjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CelestialObjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            var celestialObject = _context.CelestialObjects.SingleOrDefault(cb => cb.Id == id);
            if (celestialObject == null)
            {
                return NotFound();
            }

            celestialObject.Satellites = new List<CelestialObject>()
            {
                new CelestialObject()
                {
                    Id = 1,
                    Name = "Earth"
                },
                new CelestialObject()
                {
                    Id = 2,
                    Name = "Moon",
                    OrbitedObjectId = 1
                }
            };
            return Ok(celestialObject);
        }

    }
}
