using Microsoft.AspNetCore.Mvc;
using RestApiModeloDDD.Application.Dtos;
using RestApiModeloDDD.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiModeloDDD.Api.Controllers
{
    [Route("cliente")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IApplicationServiceCliente _clienteService;

        public ClienteController(IApplicationServiceCliente clienteService)
        {
            _clienteService = clienteService;
        }


        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> GetById(int id)
        {
            return Ok(_clienteService.GetById(id));
        }


        [HttpPost]
        public ActionResult Post([FromBody] ClienteDto clienteDto)
        {
            try
            {
                if (clienteDto is null)
                {
                    return NotFound();
                }

                _clienteService.Add(clienteDto);
                return Ok("Cliente cadastrado!");
            }
            catch 
            {
                throw;
            }            
        }


        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_clienteService.GetAll());
        }


        [HttpPut]
        public ActionResult<IEnumerable<string>> Update([FromBody] ClienteDto clienteDto)
        {
            try
            {
                if (clienteDto is null)
                {
                    return NotFound();
                }

                _clienteService.Update(clienteDto);
                return Ok("Cliente atualizado!");
            }
            catch
            {
                throw;
            }
        }


        [HttpDelete("{id}")]
        public ActionResult Delete([FromQuery]int id)
        {
            try
            {
                var cliente = _clienteService.GetById(id);
                _clienteService.Remove(cliente);
                return Ok("Cliente removido!");
            }
            catch
            {
                throw;
            }
        }



    }
}
