using DentLabTrack.Business.Operations.Doctor;
using DentLabTrack.Business.Operations.Doctor.Dtos;
using DentLabTrack.Business.Operations.Patient;
using DentLabTrack.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentLabTrack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> AddDoctor(AddDoctorRequest request)
        {
            var addDoctorDto = new AddDoctorDto
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                ClinicName = request.ClinicName

            };
            var result = await _doctorService.AddDoctor(addDoctorDto);
            if (result.IsSucceed)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }


        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> UpdateDoctor(int id, UpdateDoctorRequest request)
        {
            var updateDto = new UpdateDoctorDto
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                ClinicName = request.ClinicName
            };

            var result = await _doctorService.UpdateDoctor(updateDto);
            if (result.IsSucceed)
                return Ok(result);

            return BadRequest(result.Message);
        }

    
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var result = await _doctorService.DeleteDoctor(id);
            if (result.IsSucceed) return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Doctor,LabTechnician")]
        public async Task<IActionResult> GetAllDoctor()
        {
            var doctors = await _doctorService.GetAllDoctors();
            return Ok(doctors);
        }
    }
}
