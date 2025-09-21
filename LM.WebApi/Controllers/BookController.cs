using LM.Business.Abstract;
using LM.Entity.Concrete;
using LM.Entity.DTOs.Book;
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
        if (dto == null)
        {
            return BadRequest("Geçersiz Veri...");
        }

        var result = await _bookServ.AddAsync(dto); 

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }
    

    [HttpGet]

    public async Task<IActionResult> GetAll()
    {
        var result = await _bookServ.GetAllAsync();
        if (!result.Success)
        {
            return NotFound(result.Message);
        }
        return Ok(result.Data);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _bookServ.RemoveAsync(id);
        if (result.Success)
        {
            return Ok(result.Message);
        }
        return BadRequest(result.Message);
    }
    [HttpPut]
    public async Task<IActionResult> Update(BookUpdateRequestDto dto)
    {
        if (dto == null)
        {
            return BadRequest("Geçersiz Veri...");
        }
        var result = await _bookServ.UpdateAsync(dto);
        if (result.Success)
        {
            return Ok(result.Message);
        }
        return BadRequest(result.Message);
    }
    [HttpGet("id")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _bookServ.GetByIdAsync(id);
        if (result.Success)
        {
            return Ok(result.Data);
        }
        return NotFound(result.Message);
    }
    [HttpGet("available")]
    public async Task<IActionResult> GetAvailableBooks(bool stockStatus)
    {
        var result = await _bookServ.GetAvailableBooksAsync(stockStatus);
        if (result.Success)
        {
            return Ok(result.Data);
        }
        return NotFound(result.Message);
    }
}
