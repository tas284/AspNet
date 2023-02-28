using API.Data.DTO;
using API.Data.Interfaces;
using API.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMongoRepository<Order> _orderRepository;
    private readonly IMapper _mapper;

    public OrderController(IMongoRepository<Order> orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    [HttpPost("")]
    public async Task<ActionResult> AddOrder([FromBody] OrderDTO entity)
    {
        var order = _mapper.Map<Order>(entity);
        await _orderRepository.InsertOneAsync(order);
        return Ok(order);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateOrder([FromBody] OrderDTO entity, string id)
    {
        try{
            if(!_orderRepository.Exists(x => x.Id == id))
                return NotFound();
            
            var order = _mapper.Map<Order>(entity);
            order.Id = id;
            await _orderRepository.UpdateOneAsync(id, order);
            return Ok($"Order updated successfully! Id: {id}");
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(string id)
    {
        var order = await _orderRepository.FindByIdAsync(id);

        return order == null ? NotFound() : Ok(order);
    }

    [HttpGet("code/{code}")]
    public async Task<ActionResult> FindOne(int code)
    {
        var order = await _orderRepository.FindOneAsync(x => x.Code == code);

        return order == null ? NotFound() : Ok(order);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> DeleteOrder(string id)
    {
        if(!_orderRepository.Exists(x => x.Id == id))
            return NotFound($"Order not found! Id: {id}");
        
        try
        {
            await _orderRepository.DeleteByIdAsync(id);
            return Ok($"Successfully deleted order! Id: {id}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("")]
    public ActionResult GetPeople() => Ok(_orderRepository.FilterBy(_ => true));
}