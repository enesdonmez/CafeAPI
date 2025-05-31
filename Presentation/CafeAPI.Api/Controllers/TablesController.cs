using CafeAPI.Application.Dtos.TableDtos;
using CafeAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeAPI.Api.Controllers
{
    [Authorize(Roles = "admin,employee")]
    [Route("api/tables")]
    [ApiController]
    public class TablesController(ITableService _tableService) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllTables()
        {
            var tables = await _tableService.GetAllTables();
            return CreateResponse(tables);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTable(CreateTableDto createTableDto)
        {
            var result = await _tableService.CreateTable(createTableDto);
            return CreateResponse(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTable(UpdateTableDto updateTableDto)
        {
            var result = await _tableService.UpdateTable(updateTableDto);
            return CreateResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            var result = await _tableService.DeleteTable(id);
            return CreateResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTableById(int id)
        {
            var table = await _tableService.GetTableById(id);
            return CreateResponse(table);
        }

        [HttpGet("by-table-number/{number}")]
        public async Task<IActionResult> GetTableByTableNumber(int number)
        {
            var table = await _tableService.GetTableByTableNumber(number);
            return CreateResponse(table);
        }

        [HttpGet("active-tables")]
        public async Task<IActionResult> GetAllActiveTables()
        {
            var tables = await _tableService.GetAllActiveTables();
            return CreateResponse(tables);

        }

        [HttpGet("active-tables-generic")]
        public async Task<IActionResult> GetAllActiveTablesGeneric()
        {
            var tables = await _tableService.GetAllActiveTablesGeneric();
            return CreateResponse(tables);

        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateTableStatusById(int id)
        {
            var result = await _tableService.UpdateTableStatusById(id);
            return CreateResponse(result);

        }

        [HttpPatch("by-table-number/{tableNumber}/status")]
        public async Task<IActionResult> UpdateTableStatusByTableNumber(int tableNumber)
        {
            var result = await _tableService.UpdateTableStatusByTableNumber(tableNumber);
            return CreateResponse(result);

        }
    }
}
