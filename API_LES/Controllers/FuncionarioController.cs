using API_LES.Models.Funcionario;
using API_LES.Services.Funcionario;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_LES.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _service;
        private readonly IMapper _mapper;
        public FuncionarioController(IFuncionarioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Traz um funcionario pelo Codigo Cargo.
        /// </summary>
        /// <param name="codFunc"></param>
        /// <returns></returns>
        [HttpGet("codFunc")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFuncionarioById(int codFunc)
        {
            try
            {
                var funcionario = await _service.GetFuncionarioById(codFunc);

                return Ok(new { Success = true, Message = "", Body = funcionario });
            }
            catch (Exception ex)
            {
                return NotFound(new { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Cria um funcionario.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Createfuncionario([FromBody] CreateFuncionario createFuncionario)
        {
            try
            {
                bool isFuncionarioCreated = await _service.CreateFuncionario(createFuncionario);

                return Ok(new { Success = isFuncionarioCreated, Message = "Funcionario criado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }

        }

        /// <summary>
        /// Faz o update do funcionario pelo Codigo Funcionario.
        /// </summary>
        /// <returns></returns>
        [HttpPut("codFunc")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatefuncionarioById([FromBody] UpdateFuncionario updatefuncionario, int codFunc)
        {
            try
            {
                var funcionarioUpdated = await _service.UpdateFuncionarioById(updatefuncionario, codFunc);

                return Ok(new { Success = funcionarioUpdated, Message = "Funcionario atualizado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }

        }

        /// <summary>
        /// Deleta um funcionario pelo Codigo funcionario.
        /// </summary>
        /// <returns> </returns>
        [HttpDelete("codFunc")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletefuncionarioById(int codFunc)
        {
            try
            {
                bool isFuncionarioDeleted = await _service.DeleteFuncionarioById(codFunc);

                return Ok(new { Success = isFuncionarioDeleted, Message = "Funcionario deletado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }
    
    }
}
