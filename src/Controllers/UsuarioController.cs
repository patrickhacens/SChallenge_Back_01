using Dot6.API.Crud.Data;
using Dot6.API.Crud.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dot6.API.Crud.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly MyWorldDbContext _myWorldDbContext;
    public UsuarioController(MyWorldDbContext myWorldDbContext)
    {
        _myWorldDbContext = myWorldDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var usuario = await _myWorldDbContext.Usuario.ToListAsync();
        return Ok(usuario);
    }

    [HttpGet]
    [Route("get-usuario-by-id")]
    public async Task<IActionResult> GetUsuarioByIdAsync(int id)
    {
        var usuario = await _myWorldDbContext.Usuario.FindAsync(id);
        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Usuario usuario)
    {
        _myWorldDbContext.Usuario.Add(usuario);
        await _myWorldDbContext.SaveChangesAsync();
        return Created($"/get-usuario-by-id?id={usuario.Id}", usuario);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(Usuario usuarioToUpdate)
    {
        _myWorldDbContext.Usuario.Update(usuarioToUpdate);
        await _myWorldDbContext.SaveChangesAsync();
        return NoContent();
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var usuarioToDelete = await _myWorldDbContext.Usuario.FindAsync(id);
        if (usuarioToDelete == null)
        {
            return NotFound();
        }
        _myWorldDbContext.Usuario.Remove(usuarioToDelete);
        await _myWorldDbContext.SaveChangesAsync();
        return NoContent();
    }
}