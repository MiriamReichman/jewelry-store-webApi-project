using AutoMapper;
using BL;
using Microsoft.AspNetCore.Mvc;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOEntity;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace logInHW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrdersBl iOrdersBl;
        IMapper mapper;
        public OrdersController(IOrdersBl iOrdersBl,IMapper mapper)
        {
            this.iOrdersBl = iOrdersBl;
            this.mapper = mapper;
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<OrderDTO> Post([FromBody] OrderDTO order)
        {
            Order orders = await iOrdersBl.PostOrderAsync(mapper.Map<Order>(order));
            return mapper.Map<OrderDTO>(orders);
        }

        
    }
}
