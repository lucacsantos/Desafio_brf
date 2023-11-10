using FluentValidation;
using GestaoPessoa.Models;
using GestaoPessoa.Models.Validators;
using GestaoPessoa.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPessoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestaoPessoaController : ControllerBase
    {
        private readonly PessoaService _pessoaService;

        public GestaoPessoaController(PessoaService pessoaService) =>
            _pessoaService = pessoaService;

        [HttpGet]
        public async Task<List<Pessoa>> GetAll() =>
            await _pessoaService.GetAll();

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetById(string id)
        {
            var pessoa = await _pessoaService.GetById(id);
            if (pessoa is null)
            {
                return NotFound();
            }
            return pessoa;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pessoa newPessoa)
        {
            PessoaValidation validator = new PessoaValidation();

            validator.ValidateAndThrow(newPessoa);

            await _pessoaService.Create(newPessoa);


            return CreatedAtAction(nameof(GetAll), new { id = newPessoa.Id }, newPessoa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Pessoa updatePessoa)
        {
            var pessoa = await _pessoaService.GetById(id);
            PessoaValidation validator = new PessoaValidation();

            validator.ValidateAndThrow(updatePessoa);
            if (pessoa is null)
            {
                return NotFound();
            }

            updatePessoa.Id = pessoa.Id;

            await _pessoaService.Update(id, updatePessoa);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var pessoa = await _pessoaService.GetById(id);

            if (pessoa is null)
            {
                return NotFound();
            }

            await _pessoaService.Delete(id);

            return NoContent();
        }
    }
}
