using ProEventos.Infra.Context;
using ProEventos.Infra.Interfaces;

namespace ProEventos.Infra.Services;

public class GeralInfra : IGeralInfra
{
    private readonly ProEventosContext _context;
    public GeralInfra(ProEventosContext context)
    {
        _context = context;
    }

    public void Add<T>(T entity) where T : class
    {
        _context.Add(entity);
    }

    public void Update<T>(T entity) where T : class
    {
        _context.Update(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
        _context.Remove(entity);
    }

    public void DeleteRange<T>(T[] entityArray) where T : class
    {
        _context.RemoveRange(entityArray);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync()) > 0;
    }

}