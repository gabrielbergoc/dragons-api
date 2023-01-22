using DragonsApp.Models;
using DragonsApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DragonsApp.WebAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DragonsController : ControllerBase
{
    private readonly IDragonRepository _repository;

    public DragonsController(IDragonRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var dragons = _repository.GetAll();
        return Ok(dragons);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var dragon = _repository.Get(id);
        return Ok(dragon);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Dragon dragon)
    {
        var added = _repository.Add(dragon);
        return Ok(added);
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromBody] Dragon dragon, int id)
    {
        if (dragon.Id != 0 && dragon.Id != id)
        {
            return BadRequest("Argument 'id' differed from body property.");
        }

        dragon.Id = id;

        var updated = _repository.Update(dragon);
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _repository.Delete(id);
        return deleted ? NoContent() : NotFound();
    }
}
