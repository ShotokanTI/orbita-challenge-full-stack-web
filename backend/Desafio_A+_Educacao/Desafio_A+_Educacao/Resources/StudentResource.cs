using Application.Interfaces;
using Application.Services;
using Application.DTos;
using Desafio_A__Educacao.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application.ViewModels;

namespace Desafio_A__Educacao.Resources
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentResource : ControllerBase
    {
        private readonly IStudentService _StudentService;

        public StudentResource(IStudentService StudentService)
        {
            _StudentService = StudentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentsPaginatedAsync([FromQuery] PageRequest pageRequest)
        {
            var Students = await _StudentService.GetStudentsPaginatedAsync(pageRequest);
            return Ok(Students);
        }

        [HttpGet("{ra}")]
        public async Task<IActionResult> GetById(string ra)
        {
            var Student = await _StudentService.GetStudentByRaAsync(ra);
            return Student != null ? Ok(Student) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentDTO Student)
        {
            await _StudentService.AddStudentAsync(Student);
            return CreatedAtAction(nameof(GetById), new { id = Student.RA }, Student);
        }

        [HttpPut("{ra}")]
        public async Task<IActionResult> Update(string ra, StudentDTO Student)
        {
            await _StudentService.UpdateStudentAsync(ra,Student);
            return NoContent();
        }

        [HttpDelete("{ra}")]
        public async Task<IActionResult> Delete(string ra)
        {
            await _StudentService.DeleteStudentAsync(ra);
            return NoContent();
        }
    }

}
