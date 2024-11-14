using Infra.Context;
using Desafio_A__Educacao.Domain.Entities;
using Desafio_A__Educacao.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Student entity)
    {
        await _context.Students.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string ra)
    {
        var entity = await _context.Students.FindAsync(ra);
        if (entity != null)
        {
            _context.Students.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<(int totalItems, IEnumerable<Student> items)> GetAllPaginetedAsync(int skip, int take)
    {
        var totalItems = _context.Students.Count();
        var items = await _context.Students.Skip((skip - 1) * take).Take(take).ToListAsync();
        return (totalItems, items);
    }

    public async Task<Student> GetByRaAsync(string ra)
    {
        return await _context.Students.FindAsync(ra);
    }

    public async Task UpdateAsync(Student entity)
    {
        _context.Students.Update(entity);
        await _context.SaveChangesAsync();
    }
}
