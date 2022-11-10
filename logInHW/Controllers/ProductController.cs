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
        public async Task<List<Product>> Get()
        {
            List<Product> Product = await IProductBl.GetGames();
            return Product;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        /*ProductגTO TO ה*/
        public async Task<List<Product>> Get(int id)
        {
            List<Product> Product =await IProductBl.GetGamesByCategorie(id);
            //return mapper.Map<List<ProductDTO>>(Product);
            return Product;
        }

    }
}
