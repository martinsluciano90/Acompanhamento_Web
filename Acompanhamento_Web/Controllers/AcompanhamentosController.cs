using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Acompanhamento_Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Acompanhamento_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AcompanhamentosController : ControllerBase
    {
        private readonly AppDBContext _context;

        public AcompanhamentosController(AppDBContext context)
        {
            _context = context;
        }
        // GET: api/Acompanhamentos        
        [HttpGet]           
        public async Task<ActionResult<IEnumerable<Acompanhamento>>> GetACOMPANHAMENTO(string CNPJ)
        {
            var Acompanhamento = from s in _context.ACOMPANHAMENTO
                                 select s;

            if (!String.IsNullOrEmpty(CNPJ))
            {
                Acompanhamento = from s in _context.ACOMPANHAMENTO
                                 where s.CNPJ == CNPJ
                                 select s;
            }

            return await Acompanhamento.ToListAsync();
        }

        // GET: api/Acompanhamentos/5        
        [HttpGet("{id}")]        
        public async Task<ActionResult<Acompanhamento>> GetAcompanhamento(int id)
        {
            var acompanhamento = await _context.ACOMPANHAMENTO.FindAsync(id);

            if (acompanhamento == null)
            {
                return NotFound();
            }

            return acompanhamento;
        }

        // PUT: api/Acompanhamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcompanhamento(int id, Acompanhamento acompanhamento)
        {
            if (id != acompanhamento.ID)
            {
                return BadRequest();
            }

            _context.Entry(acompanhamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcompanhamentoExists(id))
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

        // POST: api/Acompanhamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Acompanhamento>> PostAcompanhamento(Acompanhamento acompanhamento)
        {
            _context.ACOMPANHAMENTO.Add(acompanhamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcompanhamento", new { id = acompanhamento.ID }, acompanhamento);
        }

        // DELETE: api/Acompanhamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcompanhamento(int id)
        {
            var acompanhamento = await _context.ACOMPANHAMENTO.FindAsync(id);
            if (acompanhamento == null)
            {
                return NotFound();
            }

            _context.ACOMPANHAMENTO.Remove(acompanhamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AcompanhamentoExists(int id)
        {
            return _context.ACOMPANHAMENTO.Any(e => e.ID == id);
        }
    }
}
