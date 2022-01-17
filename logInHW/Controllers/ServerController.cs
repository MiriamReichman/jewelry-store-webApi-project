using Microsoft.AspNetCore.Mvc;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using logInHW;
using BL;
using AutoMapper;
using DTOEntity;
//using ClassMyLibrary;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ex1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerController : ControllerBase
    {

        IUserBL IUserBL;
        IMapper mapper;
        public ServerController(IUserBL IUserBL,IMapper mapper)
        {
            this.IUserBL = IUserBL;
            this.mapper = mapper;
        }

        // GET: api/<ValuesController>
        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<User>> Get(string email, string password) {

            User user = await IUserBL.GetUserAsync(email, password);
            UserDTO UserDTO = mapper.Map<UserDTO>(user);
            if (user == null)
                return NoContent();
            return Ok(UserDTO);
        }




        // POST api/<ValuesController>
        [HttpPost]
        public async Task<UserDTO> Post([FromBody] UserDTO user)
        {

           
            User user1 = await IUserBL.postUserAsync(mapper.Map<User>(user));
            UserDTO UserDTO = mapper.Map<UserDTO>(user1);
            return UserDTO;
        }

        //PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task Put( [FromBody] UserDTO userToUpdate,int id)
        {
           

          await IUserBL.putUserAsync(mapper.Map<User>(userToUpdate), id);

        }

    }
}
