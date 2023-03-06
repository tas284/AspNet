using API.Data.DTO;
using API.Data.Interfaces;
using API.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMongoRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public ProductController(IMongoRepository<Product> productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    [HttpPost("")]
    public async Task<ActionResult> AddProduct([FromBody] ProductDTO entity)
    {
        var product = _mapper.Map<Product>(entity);
        await _productRepository.InsertOneAsync(product);
        return Ok(product);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Updateproduct([FromBody] ProductDTO entity, string id)
    {
        try
        {
            if (!_productRepository.Exists(x => x.Id == id))
                return NotFound();

            var product = _mapper.Map<Product>(entity);
            product.Id = id;

            await _productRepository.UpdateOneAsync(id, product);
            return Ok($"Product updated successfully! Id: {id}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(string id)
    {
        var product = await _productRepository.FindByIdAsync(id);

        return product == null ? NotFound() : Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(string id)
    {
        if (!_productRepository.Exists(x => x.Id == id))
            return NotFound($"Product not found! Id: {id}");

        try
        {
            await _productRepository.DeleteByIdAsync(id);
            return Ok($"Successfully deleted product! Id: {id}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{name?}")]
    public ActionResult GetProducts(string? name = null)
    {
        if (!string.IsNullOrEmpty(name))
            return Ok(_productRepository.FilterBy(x => x.Name!.Contains(name)));

        return Ok(_productRepository.FilterBy(_ => true));
    }
}