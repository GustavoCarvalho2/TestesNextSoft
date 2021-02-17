using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestesNextSoft.Data;
using TestesNextSoft.Models;
using System.Data; 
using System.Linq;
using System;

namespace TestesNextSoft.Controllers

{

    [ApiController]
    [Route("/v1/clientes")]
    public class ClienteController : ControllerBase
    
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Clientes>>> Get([FromServices] DataContext context)
        {
            
            try
            {
                var clientes = await context.Clientes.Include(x => x.Endereco).ToListAsync();
                if (clientes.Count==0) {

                    return StatusCode(200, "Nenhum cliente encontrado.");

                }else{

                    return clientes;
                }
            }
            catch(Exception ex )
            {
                return StatusCode(200, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Clientes>> GetById([FromServices] DataContext context, int id)
        {
            try
            {
                var clientes = await context.Clientes.Include(x => x.Endereco).FirstOrDefaultAsync(x => x.ClienteId == id);
                return clientes;
            }
            catch(Exception ex )
            {
                return StatusCode(200, ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Clientes>> Post(
            [FromServices] DataContext context , 
            [FromBody] Clientes model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Clientes.Add(model);
                    await context.SaveChangesAsync();
                    return StatusCode(200,"Cliente cadastrado  com sucesso.");
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch(Exception ex )
            {
                return StatusCode(200, ex.Message);
            }

        }

       [HttpPost]
       [Route("Update")]
       public ActionResult<Clientes> Update( 
                [FromServices] DataContext context,
                [FromBody] Clientes clientes)
        {
             try
            {
                var endereco = clientes.Endereco;
                clientes.Endereco = null;
                context.Entry(clientes).State = EntityState.Modified;
                clientes.Endereco = endereco;
                context.SaveChangesAsync();
                
                return StatusCode(200,"Cliente atualizado com sucesso.");

            }
            catch(Exception ex )
            {
                return StatusCode(200, ex.Message);
            }
            
           
        }

        [HttpGet]
        [Route("/v1/clientes/delete/{id:int}")]
        public ActionResult Delete( 
                [FromServices] DataContext context,
                int id)
        {
            try
            {
               var clientEdit = context.Clientes.FirstOrDefault(x => x.ClienteId == id);
               context.Remove(clientEdit);
               context.SaveChangesAsync();
             
               return StatusCode(200, "Cliente removido com sucesso.");

            }
            catch(Exception ex)
            {
                 return StatusCode(200, ex.Message);
            }
            
        }


    }


}