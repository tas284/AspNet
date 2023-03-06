using API.Data.DTO;
using API.Data.Interfaces;
using API.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly IMongoRepository<Person> _peopleRepository;
    private readonly IMapper _mapper;

    public PersonController(IMongoRepository<Person> peopleRepository, IMapper mapper)
    {
        _peopleRepository = peopleRepository;
        _mapper = mapper;
    }

    [HttpPost("")]
    public async Task<ActionResult> AddPerson([FromBody] PersonDTO entity)
    {
        var person = _mapper.Map<Person>(entity);
        await _peopleRepository.InsertOneAsync(person);
        return Ok(person);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePerson([FromBody] PersonDTO entity, string id)
    {
        try
        {
            if (!_peopleRepository.Exists(x => x.Id == id))
                return NotFound();

            var person = _mapper.Map<Person>(entity);
            person.Id = id;
            await _peopleRepository.UpdateOneAsync(id, person);
            return Ok($"Person updated successfully! Id: {id}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(string id)
    {
        var person = await _peopleRepository.FindByIdAsync(id);

        return person == null ? NotFound() : Ok(person);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> DeletePerson(string id)
    {
        if (!_peopleRepository.Exists(x => x.Id == id))
            return NotFound($"Person not found! Id: {id}");

        try
        {
            await _peopleRepository.DeleteByIdAsync(id);
            return Ok($"Successfully deleted person! Id: {id}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("all/{name?}")]
    public ActionResult GetPeople(string? name = null)
    {
        if (!string.IsNullOrEmpty(name))
            return Ok(_peopleRepository.FilterBy(x => x.FirstName!.ToLower().Contains(name.ToLower())));

        return Ok(_peopleRepository.FilterBy(_ => true));
    }

}