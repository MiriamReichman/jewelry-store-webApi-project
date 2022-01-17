using AutoMapper;
using BL;
using DTOEntity;
using Microsoft.AspNetCore.Mvc;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace logInHW.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductBl IProductBl;
        IMapper mapper;
        public ProductController(IProductBl IProductBl,IMapper mapper)
        {
            this.IProductBl = IProductBl;
            this.mapper = mapper;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<List<ProductDTO>> Get()
        {
            List<Game> Product = await IProductBl.GetGames();
            return mapper.Map < List<ProductDTO>>(Product);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<List<ProductDTO>> Get(int id)
        {
            List<Game> Product =await IProductBl.GetGamesByCategorie(id);
                return mapper.Map<List<ProductDTO>>(Product);
        }







        //// POST api/<ProductController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
