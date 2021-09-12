using Microsoft.AspNetCore.Mvc;
using MongoDBDEMO.Business.DTO;
using MongoDBDEMO.Business.Entities;
using MongoDBDEMO.Data.Respositories;
using System;
using System.Threading.Tasks;

namespace MongoDBDEMO.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaRepository _repository;

        public PessoaController(PessoaRepository repository = null)
        {
            _repository = repository;
        }
        [HttpPost("Adcionar")]
        public async Task<IActionResult> AdicionaPessoa(PessoaViewModel pessoa)
        {
            Pessoa p = new Pessoa 
            { 
                Nome = pessoa.Nome,
                DataNascimento = pessoa.DataNascimento
            };

            try
            {
                await _repository.AdicionaPessoa(p);
            }
            catch (Exception)
            {
                return StatusCode(500); 
            }
           

            return Created("Adcionar", p);
        }
        [HttpGet("RecuperarLista")]
        public async Task<IActionResult> RecuperaListaPessoas()
        {
            return Ok(await _repository.RecuperaPessoas());
        }

    }
}
