using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OllivandersShopAPI.Data.DataAccess.Repositories;
using OllivandersShopAPI.Data.DataAccess.Repositories.Abstractions;
using OllivandersShopAPI.Errors;
using OllivandersShopAPI.Mapper.Abstractions;
using OllivandersShopAPI.Models.DTO;
using System.Net;

namespace OllivandersShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WandsController : ControllerBase
    {
        private readonly IWandRepository _wandRepository;

        public WandsController(IWandRepository wandRepository)
        {
            _wandRepository = wandRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<GetWandDto>>> GetAllWands()
        {
            var getAllResult = await _wandRepository.GetAllWandsAsync();

            return getAllResult.MatchFirst<ActionResult>(
                received => Ok(received),
                error => Problem(
                    title: error.Code,
                    detail: error.Description,
                    statusCode: error.NumericType,
                    instance: Request.Path.Value
                    ));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<GetWandDto>> GetWandById(int id)
        {
            var getByIdResult = await _wandRepository.GetWandByIdAsync(id);

            return getByIdResult.MatchFirst<ActionResult>(
                received => Ok(received),
                error => Problem(
                    title: error.Code,
                    detail: error.Description,
                    statusCode: error.NumericType,
                    instance: Request.Path.Value
                    ));
        }

        [HttpPost]
        public async Task<ActionResult> PostWand([FromBody] PostWandDto dto)
        {
            var postResult = await _wandRepository.AddWandAsync(dto);

            return postResult.MatchFirst<ActionResult>(
                posted => CreatedAtAction(nameof(GetWandById), new { id = posted.Id }, dto),
                error => Problem(
                    title: error.Code,
                    detail: error.Description,
                    statusCode: error.NumericType,
                    instance: Request.Path.Value
                    ));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> PutWand(int id, [FromBody] PutWandDto dto)
        {
            var updateResult = await _wandRepository.UpdateWandAsync(id, dto);

            return updateResult.MatchFirst<ActionResult>(
                deleted => NoContent(),
                error => Problem(
                    title: error.Code,
                    detail: error.Description,
                    statusCode: error.NumericType,
                    instance: Request.Path.Value
                    ));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteWand(int id)
        {
            var deleteResult = await _wandRepository.DeleteWandAsync(id);

            return deleteResult.MatchFirst<ActionResult>(
                deleted => NoContent(),
                error => Problem(
                    title: error.Code,
                    detail: error.Description,
                    statusCode: error.NumericType,
                    instance: Request.Path.Value
                    ));
        }
    }
}
