using API_LES.Dtos;
using API_LES.Models;
using API_LES.Models.User;
using API_LES.Services.User;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Traz um usuário pelo Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna usuário cadastrado pelo Id</returns>
        [HttpGet("id")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _service.GetUserById(id);

                return Ok(new { Success = true, Message = "Usuário criado com sucesso.", Body = user});
            }
            catch (Exception ex)
            {
                return NotFound(new { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Cria um usuário.
        /// </summary>
        /// <returns>Retorna um boolean para a criação do usuário, true = sucesso || false = falha</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUser createUser)
        {
            try
            {
                bool isUserCreated = await _service.CreateUser(createUser);

                return Ok(new { Success = isUserCreated, Message = "Usuário criado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
            
        }

        /// <summary>
        /// Faz o update do usuário pelo Id.
        /// </summary>
        /// <returns></returns>
        [HttpPut("id")]
        public async Task<IActionResult> UpdateUserById([FromBody] UpdateUser updateUser, int id)
        {
            try
            {
                var userUpdated = await _service.UpdateUserById(updateUser, id);

                return Ok(new { Success = userUpdated, Message = "Usuário atualizado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
            
        }

        ///// <summary>
        ///// Deleta um usuário pelo Id.
        ///// </summary>
        ///// <returns> </returns>
        [HttpPost("id")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            try
            {
                bool isUserCreated = await _service.DeleteUserById(id);
      
                return Ok(new { Success = isUserCreated, Message = "Usuário deletado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }
    }
}
