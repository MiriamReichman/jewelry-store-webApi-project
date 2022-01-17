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
    public class CategoriesController : ControllerBase
    {
        ICategoriesBl ICategoriesBL;
        IMapper mapper;
        public CategoriesController(ICategoriesBl iCategoriesBL,IMapper mapper)
        {
            ICategoriesBL = iCategoriesBL;
            this.mapper = mapper;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<List<ProductCategorieDTO>> Get()
        {
        
              List<GameCategorie> v= await ICategoriesBL.GetCategoriesAsync();
            return mapper.Map<List<ProductCategorieDTO>>(v);
        }






    }
}
