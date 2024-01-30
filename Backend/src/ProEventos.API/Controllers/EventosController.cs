using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Domain;
using ProEventos.Persistence;
using ProEventos.Persistence.Contexto;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly ProEventosContext context;

        public EventosController(ProEventosContext context)
        {
            this.context = context;

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return context.Eventos;
        }

        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return context.Eventos.FirstOrDefault(evento => evento.Id == id);
        }

        [HttpPost]
        public string Post()
        {
            return "POST";
        }

        [HttpPut("{id}")]
        public string Put()
        {
            return "Put";
        }

        [HttpDelete("{id}")]
        public string Delete()
        {
            return "Delete";
        }
    }
}
