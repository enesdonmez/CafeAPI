using CafeAPI.Application.Dtos.ResponseDtos;
using CafeAPI.Application.Dtos.TableDtos;
using CafeAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CafeAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController(ITableService _tableService) : ControllerBase
    {
        [HttpGet("GetAllTables")]
        public async Task<IActionResult> GetAllTables()
        {
            var tables = await _tableService.GetAllTables();
            if (!tables.IsSuccess)
            {
                if (tables.ErrorCodes == ErrorCodes.NotFound)
                    return NotFound(tables);
                return BadRequest(tables);
            }
            return Ok(tables);
        }

        [HttpPost("CreateTable")]
        public async Task<IActionResult> CreateTable(CreateTableDto createTableDto)
        {
            var result = await _tableService.CreateTable(createTableDto);
            if (!result.IsSuccess)
            {
                if (result.ErrorCodes is ErrorCodes.NotFound)
                    return NotFound(result);
                else if (result.ErrorCodes is ErrorCodes.DuplicateError)
                    return Conflict(result);

                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("UpdateTable")]
        public async Task<IActionResult> UpdateTable(UpdateTableDto updateTableDto)
        {
            var result = await _tableService.UpdateTable(updateTableDto);
            if (!result.IsSuccess)
            {
                if (result.ErrorCodes == ErrorCodes.NotFound)
                    return NotFound(result);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            var result = await _tableService.DeleteTable(id);
            if (!result.IsSuccess)
            {
                if (result.ErrorCodes == ErrorCodes.NotFound)
                    return NotFound(result);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetByIdTable/{id}")]
        public async Task<IActionResult> GetTableById(int id)
        {
            var table = await _tableService.GetTableById(id);
            if (!table.IsSuccess)
            {
                if (table.ErrorCodes == ErrorCodes.NotFound)
                    return NotFound(table);
                return BadRequest(table);
            }
            return Ok(table);
        }

        [HttpGet("GetTableByTableNumber/{number}")]
        public async Task<IActionResult> GetTableByTableNumber(int number)
        {
            var table = await _tableService.GetTableByTableNumber(number);
            if (!table.IsSuccess)
            {
                if (table.ErrorCodes == ErrorCodes.NotFound)
                    return NotFound(table);
                return BadRequest(table);
            }
            return Ok(table);
        }


    }
}
