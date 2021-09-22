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
    public class GuitarristaApiController :ControllerBase
    {
        private readonly IGuitarristaService _guitarristaService;
        public GuitarristaApiController(IGuitarristaService guitarristaService)
        {
            _guitarristaService = guitarristaService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guitarrista>>> Get(string orderAscendant, string search = null)
        {
           var guitarrista = await _guitarristaService.GetAll(orderAscendant,search);
            return Ok(guitarrista);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Guitarrista>> Get(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            var guitarrista = await _guitarristaService.GetById(id);
            if(guitarrista == null)
            {
                return NotFound();
            }
            return Ok(guitarrista);
        }

        
        [HttpPost]
        public async Task<ActionResult<Guitarrista>> Post([FromBody] Guitarrista guitarrista)
        {
            if (ModelState.IsValid)
            {
                var created = await _guitarristaService.Create(guitarrista);
                return Ok(created);
            }
            return BadRequest(guitarrista);
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult<Guitarrista>> Put(int id, [FromBody] Guitarrista guitarrista)
        {
            if (id != guitarrista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var edited = await _guitarristaService.Edit(guitarrista);
                    return Ok(edited);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return StatusCode(409);
                }
                
            }
            return BadRequest(guitarrista);
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _guitarristaService.Delete(id);
            return Ok();
        }
        
        [HttpGet("IsNameValid/{nome}")]
        public async Task<ActionResult<bool>> IsNameValid(string nome)
        {
           var accepted =  await _guitarristaService.IsNameValid(nome);
            return Ok(accepted);
        }
    }
}
