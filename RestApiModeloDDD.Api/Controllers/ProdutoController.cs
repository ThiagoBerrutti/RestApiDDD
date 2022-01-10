using Microsoft.AspNetCore.Mvc;
using RestApiModeloDDD.Application.Dtos;
using RestApiModeloDDD.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiModeloDDD.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : Controller
    {
        private readonly IApplicationServiceProduto _produtoService;

        public ProdutosController(IApplicationServiceProduto produtoService)
        {
            _produtoService = produtoService;
        }


        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> GetById(int id)
        {
            return Ok(_produtoService.GetById(id));
        }


        [HttpPost]
        public ActionResult Post([FromBody] ProdutoDto produtoDto)
        {
            try
            {
                if (produtoDto is null)
                {
                    return NotFound();
                }

                _produtoService.Add(produtoDto);
                return Ok("Produto cadastrado!");
            }
            catch
            {
                throw;
            }
        }


        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_produtoService.GetAll());
        }


        [HttpPut]
        public ActionResult<IEnumerable<string>> Update([FromBody] ProdutoDto produtoDto)
        {
            try
            {
                if (produtoDto is null)
                {
                    return NotFound();
                }

                _produtoService.Update(produtoDto);
                return Ok("Produto atualizado!");
            }
            catch
            {
                throw;
            }
        }


        [HttpDelete("{id}")]
        public ActionResult Delete([FromQuery] int id)
        {
            try
            {
                var produto = _produtoService.GetById(id);
                _produtoService.Remove(produto);
                return Ok("Produto removido!");
            }
            catch
            {
                throw;
            }
        }



    }
}
