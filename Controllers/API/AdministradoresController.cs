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
   
    public class AdministradoresController : ControllerBase
    {
        private readonly ContextoCms _context;

        public AdministradoresController(ContextoCms context)
        {
            _context = context;
        }
        
        // GET: Administradores
        [HttpGet]
        [Route("/api/administradores.json")]       
        public async Task<IActionResult> Index()
        {
              return StatusCode(200, await _context.Administradores.ToListAsync());
        }   

     

       
        [HttpPost]      
        [Route("/api/administradores.json")]     
        public async Task<IActionResult> Create([FromBody] Administrador administrador)
        {           
                _context.Add(administrador);
                await _context.SaveChangesAsync();
                 return StatusCode(201);   
        }

         [HttpPut]
         [Route("/api/administradores/{id}.json")]

        public async Task<IActionResult> Update(int id, [FromBody] Administrador administrador)
        {
                administrador.Id = id;
                _context.Update(administrador);
                await _context.SaveChangesAsync();
                return StatusCode(200);      
        }

        [HttpDelete]
        [Route("/api/administradores/{id}.json")]

         public async Task<IActionResult> Delete(int id)
        {
           // if (id == null || _context.Paginas == null)
            if (id == 0 || _context.Administradores == null)
            {
                return StatusCode(400, new {Message =" O Id é Obrigatório"});
            }

            var administradores = await _context.Administradores.FirstOrDefaultAsync(m => m.Id == id);
            if (administradores == null)
            {
              return StatusCode(404, new {Message =" A Página não foi encontrada!"});
            }

             _context.Administradores.Remove(administradores);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }


    }
}
