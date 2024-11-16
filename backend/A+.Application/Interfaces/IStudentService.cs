using Application.DTos;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IStudentService
    {
        Task<PageResult<StudentDTO>> GetStudentsPaginatedAsync(PageRequest pageRequest);
        Task<StudentDTO> GetStudentByRaAsync(string ra);
        Task AddStudentAsync(StudentDTO student);
        Task UpdateStudentAsync(StudentDTO student);
        Task DeleteStudentAsync(string ra);
    }
}
