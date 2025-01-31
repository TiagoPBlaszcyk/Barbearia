﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MS.Domain.IPerson;
using MS.Entities.Login;
using MS.Entities.Person;

namespace API.Controllers
{
    // TODO: Documentacao Swagger
    // Table Login Name/Password/Token/ExpireToken
    
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LoginController : ControllerBase
    {
        private IPersonRepository _repository;
        public LoginController(IPersonRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> AuthenticateAsync([FromBody] LoginVO model)
        {
            Person person = await _repository.FindByName(model.Name);
            if (person == null || model.Senha != person.Senha) return BadRequest(new
            {
                error = $"Senha incorreta! :) {person.Senha}"
            });

            var token = TokenService.GenerateToken(person);

            return Ok(new
            {
                statusCode = 200,
                user = model,
                token = token
            });
        }

        [HttpPost]
        [Route("Cadastro")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> RegisterAsync([FromBody] PersonVO vo)
        {
            if (vo == null) return BadRequest();
            
            var exist = await _repository.FindByName(vo.Name);

            if (exist == null)
            {
                PersonVO person = await _repository.Create(vo);
                return Ok(person);
            }
            else
            {
                if (vo.Senha == exist.Senha)
                {
                    return  Problem(detail:"Você já possui cadastro", statusCode: 201);
                }
                else
                {
                    return  Problem(detail:"Usuário já existe!", statusCode: 201);
                }
            }
        }
    }
}
