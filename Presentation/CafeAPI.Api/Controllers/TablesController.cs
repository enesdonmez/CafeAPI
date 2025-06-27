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
        [EndpointDescription("Tüm masaları getirir.")]
        public async Task<IActionResult> GetAllTables()
        {
            var tables = await _tableService.GetAllTables();
            return CreateResponse(tables);
        }

        [HttpPost]
        [EndpointDescription("Yeni masa oluşturur.")]
        public async Task<IActionResult> CreateTable(CreateTableDto createTableDto)
        {
            var result = await _tableService.CreateTable(createTableDto);
            return CreateResponse(result);
        }

        [HttpPut]
        [EndpointDescription("Mevcut masayı günceller.")]
        public async Task<IActionResult> UpdateTable(UpdateTableDto updateTableDto)
        {
            var result = await _tableService.UpdateTable(updateTableDto);
            return CreateResponse(result);
        }

        [HttpDelete("{id}")]
        [EndpointDescription("Belirtilen ID'ye sahip masayı siler.")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            var result = await _tableService.DeleteTable(id);
            return CreateResponse(result);
        }

        [HttpGet("{id}")]
        [EndpointDescription("Belirtilen ID'ye sahip masayı getirir.")]
        public async Task<IActionResult> GetTableById(int id)
        {
            var table = await _tableService.GetTableById(id);
            return CreateResponse(table);
        }

        [HttpGet("by-table-number/{number}")]
        [EndpointDescription("Belirtilen masa numarasına göre masayı getirir.")]
        public async Task<IActionResult> GetTableByTableNumber(int number)
        {
            var table = await _tableService.GetTableByTableNumber(number);
            return CreateResponse(table);
        }

        [HttpGet("active-tables")]
        [EndpointDescription("Aktif olan tüm masaları getirir.")]
        public async Task<IActionResult> GetAllActiveTables()
        {
            var tables = await _tableService.GetAllActiveTables();
            return CreateResponse(tables);
        }

        [HttpGet("active-tables-generic")]
        [EndpointDescription("Aktif olan tüm masaları getirir.")]
        public async Task<IActionResult> GetAllActiveTablesGeneric()
        {
            var tables = await _tableService.GetAllActiveTablesGeneric();
            return CreateResponse(tables);
        }

        [HttpPatch("{id}/status")]
        [EndpointDescription("Belirtilen ID'ye sahip masanın durumunu günceller.")]
        public async Task<IActionResult> UpdateTableStatusById(int id)
        {
            var result = await _tableService.UpdateTableStatusById(id);
            return CreateResponse(result);
        }

        [HttpPatch("by-table-number/{tableNumber}/status")]
        [EndpointDescription("Belirtilen masa numarasına göre masanın durumunu günceller.")]
        public async Task<IActionResult> UpdateTableStatusByTableNumber(int tableNumber)
        {
            var result = await _tableService.UpdateTableStatusByTableNumber(tableNumber);
            return CreateResponse(result);
        }
    }
}
