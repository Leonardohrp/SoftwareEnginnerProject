using API_LES.Models.Beneficio;
using API_LES.Services.Beneficio;
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
    [Route("api/[controller]/[action]")]
    public class BeneficioController : ControllerBase
    {
        private readonly IBeneficioService _service;
        public BeneficioController(IBeneficioService service)
        {
            _service = service;
        }

        /// <summary>
        /// Traz um beneficio pelo Id.
        /// </summary>
        /// <param name="Código Beneficio"></param>
        /// <returns>Retorna usuário cadastrado pelo Id</returns>
        [HttpGet("{codBeneficio}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBenenficioById(int codBeneficio)
        {
            try
            {
                var beneficio = await _service.GetBeneficioById(codBeneficio);

                return Ok(new { Success = true, Message = "", Body = beneficio });
            }
            catch (Exception ex)
            {
                return NotFound(new { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Traz todos beneficios.
        /// </summary>
        /// <returns>Retorna beneficios</returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllBeneficios()
        {
            try
            {
                var beneficio = await _service.GetAllBeneficios();

                return Ok(new { Success = true, Message = "", Body = beneficio });
            }
            catch (Exception ex)
            {
                return NotFound(new { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Cria um beneficio.
        /// </summary>
        /// <returns>Retorna um boolean para a criação do usuário, true = sucesso || false = falha</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBeneficio([FromBody] CreateBeneficio createBeneficio)
        {
            try
            {
                bool isBeneficioCreated = await _service.CreateBeneficio(createBeneficio);

                return Ok(new { Success = isBeneficioCreated, Message = "Beneficio criado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }

        }

        /// <summary>
        /// Faz o update do beneficio pelo Id.
        /// </summary>
        /// <returns></returns>
        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBeneficioById([FromBody] UpdateBeneficio updateBenenficio, int id)
        {
            try
            {
                bool beneficioUpdated = await _service.UpdateBeneficioById(updateBenenficio, id);

                return Ok(new { Success = beneficioUpdated, Message = "Beneficio atualizado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }

        }

        ///// <summary>
        ///// Deleta um beneficio pelo Id.
        ///// </summary>
        ///// <returns> </returns>
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBeneficioById(int id)
        {
            try
            {
                bool isBenenficioDeleted = await _service.DeleteBeneficioById(id);

                return Ok(new { Success = isBenenficioDeleted, Message = "Beneficio deletado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }

    }
}
