using Core.Utilities.Results;
using LM.Business.Abstract;
using LM.Entity.DTOs.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LM.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookServ _bookServ;

    public BookController(IBookServ bookServ)
    {
        _bookServ = bookServ;
    }
    [HttpPost]
    public async Task<IActionResult> Create(BookCreateRequestDto dto)
    {
        
        if (dto==null)
        {
            return BadRequest("Geçersiz Veri...");
        }
        var result = await _bookServ.AddAsync(dto);
        if (result.Success)
        {
            return Ok(result.Data);
        }
        return BadRequest(result.Message);
    }

    [HttpGet]

    public async Task<IActionResult> GetAll()
    {
        var result = await _bookServ.GetAllAsync();
        if (result.Success)
        {
            return Ok(result.Data);
        }
        return NotFound(result.Message);
    }
}
