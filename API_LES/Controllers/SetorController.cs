using API_LES.Models.Setor;
using API_LES.Services.Setor;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API_LES.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SetorController : ControllerBase
    {
        private readonly ISetorService _service;
        private readonly IMapper _mapper;

        public SetorController(ISetorService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Traz um Setor pelo Codigo Cargo.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSetorById(int id)
        {
            try
            {
                var setor = await _service.GetSetorById(id);

                return Ok(new { Success = true, Message = "", Body = setor });
            }
            catch (Exception ex)
            {
                return NotFound(new { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Cria um Setor.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSetor([FromBody] CreateSetor createSetor)
        {
            try
            {
                bool isSetorCreated = await _service.CreateSetor(createSetor);

                return Ok(new { Success = isSetorCreated, Message = "Setor criado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }

        }

        /// <summary>
        /// Faz o update do Setor pelo Codigo Setor.
        /// </summary>
        /// <returns></returns>
        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateSetorById([FromBody] UpdateSetor updateSetor, int codSetor)
        {
            try
            {
                var setorUpdated = await _service.UpdateSetorById(updateSetor, codSetor);

                return Ok(new { Success = setorUpdated, Message = "Setor atualizado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }

        }

        /// <summary>
        /// Deleta um Setor pelo Codigo Setor.
        /// </summary>
        /// <returns> </returns>
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteSetorById(int codSetor)
        {
            try
            {
                bool isSetorDeleted = await _service.DeleteSetorById(codSetor);

                return Ok(new { Success = isSetorDeleted, Message = "Setor deletado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }
    }
}
