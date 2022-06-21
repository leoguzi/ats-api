using atsApi.Models;
using atsApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace atsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PositionController
    {
       

        private static List<Position> positions = new List<Position>();
        private readonly PositionsService _positionsService;

        public PositionController(PositionsService positionsService) =>
        _positionsService = positionsService;

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterPosition([FromBody] Position position)
        {
            await _positionsService.CreateAsync(position);
            return new OkResult();
        
        }
        [HttpGet]
        public async Task<IActionResult> FetchPositions()
        {
            List<Position> positions = await _positionsService.GetAsync();
            return new OkObjectResult(positions);
        }
        
        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> FetchPositionById(string id)
        {
            Position position = await _positionsService.GetAsync(id);
            if(position != null)
            {
                return new OkObjectResult(position);
            }
            return new NotFoundResult();
        } 
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdatePosition(string id, Position updatedPosition)
        {
            Position position = await _positionsService.GetAsync(id);
            if(position == null)
            {
                return new NotFoundResult();
            }
            updatedPosition.Id = position.Id;
            await _positionsService.UpdateAsync(id, updatedPosition);
            return new OkResult();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeletePosition(string id)
        {
            await _positionsService.RemoveAsync(id);

            return new OkResult();
        }
    }

}
