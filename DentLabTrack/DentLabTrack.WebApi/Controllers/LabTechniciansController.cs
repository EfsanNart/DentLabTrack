using DentLabTrack.Business.Operations.LabTechnician;
using DentLabTrack.Business.Operations.LabTechnician.Dtos;
using DentLabTrack.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentLabTrack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabTechniciansController : ControllerBase
    {
        private readonly ILabTechnicianService _labTechnicianService;

        public LabTechniciansController(ILabTechnicianService labTechnicianService)
        {
            _labTechnicianService = labTechnicianService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,LabTechnician")]
        public async Task<IActionResult> AddTechnician(AddLabTechnicianRequest request)
        {
            var dto = new AddLabTechnicianDto
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };

            var result = await _labTechnicianService.AddLabTechnician(dto);

            if (result.IsSucceed)
                return Ok(result);

            return BadRequest(result.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTechnicians()
        {
            var result = await _labTechnicianService.GetAllTechnicians();
            return Ok(result);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateTechnician(int id, [FromBody] UpdateLabTechnicianRequest request)
        {
            var dto = new UpdateLabTechnicianDto
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };

            var result = await _labTechnicianService.UpdateTechnician(dto);

            if (result.IsSucceed)
                return Ok(result);

            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTechnician(int id)
        {
            var result = await _labTechnicianService.DeleteTechnician(id);

            if (result.IsSucceed)
                return Ok(result);

            return BadRequest(result.Message);
        }
    }
}