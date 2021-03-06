using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using admin_cms.Infraestrutura.Database;
using admin_cms.Models.Dominio.Entidades;
using admin_cms.Models.Infraestrutura.Autenticacao;

namespace admin_cms.Controllers.API
{
    
    public class ApiPaginasController : ControllerBase
    {
        private readonly ContextoCms _context;

        public ApiPaginasController(ContextoCms context)
        {
            _context = context;
        }

        // GET: Paginas
        [HttpGet]
        [Route("/api/paginas.json")]
        public async Task<IActionResult> Index()
        {
              return StatusCode(200,await _context.Paginas.ToListAsync());
        } 

         [HttpPost]
         [Route("/api/paginas.json")]

        public async Task<IActionResult> Create([FromBody] Pagina pagina)
        {
                _context.Add(pagina);
                await _context.SaveChangesAsync();
                return StatusCode(201);
         
        }

         [HttpPut]
         [Route("/api/paginas/{id}.json")]

        public async Task<IActionResult> Update(int id, [FromBody] Pagina pagina)
        {
                pagina.Id = id;
                _context.Update(pagina);
                await _context.SaveChangesAsync();
                return StatusCode(200);
         
        }
        [HttpDelete]
        [Route("/api/paginas/{id}.json")]

         public async Task<IActionResult> Delete(int id)
        {
           // if (id == null || _context.Paginas == null)
            if (id == 0 || _context.Paginas == null)
            {
                return StatusCode(400, new {Message =" O Id é Obrigatório"});
            }

            var pagina = await _context.Paginas.FirstOrDefaultAsync(m => m.Id == id);
            if (pagina == null)
            {
              return StatusCode(404, new {Message =" A Página não foi encontrada!"});
            }

             _context.Paginas.Remove(pagina);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

    }
}

