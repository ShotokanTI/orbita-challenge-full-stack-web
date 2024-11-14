using Application.Interfaces;
using Application.DTos;
using Desafio_A__Educacao.Domain.Entities;
using Desafio_A__Educacao.Domain.Interfaces;
using System.Data;
using AutoMapper;
using Application.ViewModels;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _StudentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository StudentRepository,IMapper mapper)
        {
            _StudentRepository = StudentRepository;
            _mapper = mapper;
        }
        public async Task<PageResult<StudentDTO>> GetStudentsPaginatedAsync(PageRequest page)
        {
            int skip = (page.PageNumber - 1) * page.PageSize;
            int take = page.PageSize;

            var (totalItems,items) = await _StudentRepository.GetAllPaginetedAsync(page.PageNumber,page.PageSize);

            var entityMapped = _mapper.Map<IEnumerable<StudentDTO>>(items);

            return new PageResult<StudentDTO>(entityMapped.ToList(), totalItems, page.PageNumber, page.PageSize);
        }

        public async Task<StudentDTO> GetStudentByRaAsync(string ra)
        {
            var entity = await _StudentRepository.GetByRaAsync(ra);
            return _mapper.Map<StudentDTO>(entity);
        }

        public Task AddStudentAsync(StudentDTO studentVM)
        {
            var entity = _mapper.Map<Student>(studentVM);

            return _StudentRepository.CreateAsync(entity);
        }

        public async Task UpdateStudentAsync(string ra,StudentDTO studentVM)
        {

            var entity = await _StudentRepository.GetByRaAsync(ra);

            var result = _mapper.Map<Student>(studentVM);

            await _StudentRepository.UpdateAsync(result);
        }

        public Task DeleteStudentAsync(string ra)
        {
            return _StudentRepository.DeleteAsync(ra);
        }

    }

}
