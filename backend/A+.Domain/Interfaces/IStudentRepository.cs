using Desafio_A__Educacao.Domain.Entities;

namespace Desafio_A__Educacao.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<(int totalItems, IEnumerable<Student> items)> GetAllPaginetedAsync(int skip,int take);
        Task<Student> GetByRaAsync(string id);
        Task CreateAsync(Student entity);
        Task UpdateAsync(Student entity);
        Task DeleteAsync(string ra);
    }
}
