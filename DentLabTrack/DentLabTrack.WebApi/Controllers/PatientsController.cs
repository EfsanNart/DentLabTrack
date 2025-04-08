using DentLabTrack.Business.Operations.Patient.Dtos;
using DentLabTrack.Business.Operations.Patient;
using DentLabTrack.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentLabTrack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> AddPatient(AddPatientRequest request)
        {
            var dto = new AddPatientDto
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address
            };

            var result = await _patientService.AddPatient(dto);
            if (result.IsSucceed) return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Doctor,LabTechnician")]
        public async Task<IActionResult> GetAllPatients()
        {
            var result = await _patientService.GetAllPatients();
            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] UpdatePatientRequest request)
        {
            var dto = new UpdatePatientDto
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address
            };

            var result = await _patientService.UpdatePatient(dto);
            if (result.IsSucceed) return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var result = await _patientService.DeletePatient(id);
            if (result.IsSucceed) return Ok(result);
            return BadRequest(result.Message);
        }
    }
}
