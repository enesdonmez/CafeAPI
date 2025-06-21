using CafeAPI.Application.Dtos.CafeInfoDtos;
using CafeAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeAPI.Api.Controllers
{
    [Route("api/cafeInfos")]
    [ApiController]
    public class CafeInfosController(ICafeInfoService cafeInfoService) : BaseController
    {
        [Authorize("admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllCafeInfos()
        {
            var cafeInfos = await cafeInfoService.GetAllCafeInfos();
            return CreateResponse(cafeInfos);
        }

        [Authorize("admin")]
        [HttpPost]
        public async Task<IActionResult> CreateCafeInfo(CreateCafeInfoDto createCafeInfoDto)
        {
            var result = await cafeInfoService.CreateCafeInfo(createCafeInfoDto);
            return CreateResponse(result);
        }

        [Authorize("admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCafeInfoById(int id)
        {
            var cafeInfo = await cafeInfoService.GetByIdCafeInfo(id);
            return CreateResponse(cafeInfo);
        }

        [Authorize(Roles = "admin,user")]
        [HttpPut]
        public async Task<IActionResult> UpdateCafeInfo(UpdateCafeInfoDto updateCafeInfoDto)
        {
            var result = await cafeInfoService.UpdateCafeInfo(updateCafeInfoDto);
            return CreateResponse(result);
        }

        [Authorize("admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCafeInfo(int id)
        {
            var result = await cafeInfoService.DeleteCafeInfo(id);
            return CreateResponse(result);

        }
    }
}
