using API_LES.Models.Cargo;
using API_LES.Services.Cargo;
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
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _service;
        private readonly IMapper _mapper;

        public CargoController(ICargoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Traz um Cargo pelo Codigo Cargo.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCargoById(int id)
        {
            try
            {
                var cargo = await _service.GetCargoById(id);

                return Ok(new { Success = true, Message = "", Body = cargo });
            }
            catch (Exception ex)
            {
                return NotFound(new { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Traz todos os Cargos
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllCargos()
        {
            try
            {
                var cargos = await _service.GetAllCargos();

                return Ok(new { Success = true, Message = "", Body = cargos });
            }
            catch (Exception ex)
            {
                return NotFound(new { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Cria um Cargo.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCargo([FromBody] CreateCargo createCargo)
        {
            try
            {
                bool isCargoCreated = await _service.CreateCargo(createCargo);

                return Ok(new { Success = isCargoCreated, Message = "Cargo criado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }

        }

        /// <summary>
        /// Faz o update do Cargo pelo Codigo Cargo.
        /// </summary>
        /// <returns></returns>
        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCargoById([FromBody] UpdateCargo updateCargo, int codCargo)
        {
            try
            {
                var cargoUpdated = await _service.UpdateCargoById(updateCargo, codCargo);

                return Ok(new { Success = cargoUpdated, Message = "Cargo atualizado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }

        }

        /// <summary>
        /// Deleta um Cargo pelo Codigo Cargo.
        /// </summary>
        /// <returns> </returns>
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCargoById(int codCargo)
        {
            try
            {
                bool isCargoDeleted = await _service.DeleteCargoById(codCargo);

                return Ok(new { Success = isCargoDeleted, Message = "Cargo deletado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }
    }
}
