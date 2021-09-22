using Domain.Models;
using Domain.Services.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tp3MVC_API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GuitarraApiController : ControllerBase
    {
        private readonly IGuitarraService _guitarraService;
        public GuitarraApiController(IGuitarraService guitarraService)
        {
            _guitarraService = guitarraService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guitarras>>> Get(string orderAscendant, string search)
        {
            var guitarra = await _guitarraService.GetAll(orderAscendant = "true");
            return Ok(guitarra);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Guitarras>> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var guitarra = await _guitarraService.GetById(id);
            if (guitarra == null)
            {
                return NotFound();
            }
            return Ok(guitarra);
        }


        [HttpPost]
        public async Task<ActionResult<Guitarras>> Post([FromBody] Guitarras guitarra)
        {
            if (ModelState.IsValid)
            {
                var created = await _guitarraService.Create(guitarra);
                return Ok(created);
            }
            return BadRequest(guitarra);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Guitarras>> Put(int id, [FromBody] Guitarras guitarra)
        {
            if (id != guitarra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var edited = await _guitarraService.Edit(guitarra);
                    return Ok(edited);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return StatusCode(409);
                }

            }
            return BadRequest(guitarra);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _guitarraService.Delete(id);
            return Ok();
        }
    }


}
