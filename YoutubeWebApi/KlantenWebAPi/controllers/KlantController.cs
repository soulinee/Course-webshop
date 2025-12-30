using KlantenWebAPi.contracten;
using KlantenWebAPi.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KlantenWebAPi.controllers
{[ApiController]
[Route("api/klanten")]
public class KlantController : ControllerBase
{
    private readonly IKlantService _service;

    public KlantController(IKlantService service)
    {
        _service = service;
    }

    // CREATE
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] KlantRequestContract klant)
    {
        var created = await _service.CreateAsync(klant);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // GET by id
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var klant = await _service.GetByIdAsync(id);
        return klant is null ? NotFound() : Ok(klant);
    }

    // GET all
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var klanten = await _service.GetAllAsync();
        return Ok(klanten);
    }

    // UPDATE
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] KlantRequestContract klant)
    {
        var success = await _service.UpdateAsync(id, klant);
        return success ? NoContent() : NotFound();
    }

    // DELETE
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _service.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }
}
}
