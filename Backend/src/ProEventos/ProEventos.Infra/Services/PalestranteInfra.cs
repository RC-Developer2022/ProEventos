using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using ProEventos.Infra.Context;
using ProEventos.Infra.Interfaces;

namespace ProEventos.Infra.Services;

public class PalestranteInfra : IPalestranteInfra
{
    private readonly ProEventosContext _context;
    public PalestranteInfra(ProEventosContext context)
    {
        _context = context;
        _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;// colocando para todos os métodos
    }

    public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
    {
        IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p => p.RedesSociais);

        if (includeEventos)
        {
            query = query
                .Include(p => p.PalestrantesEventos).ThenInclude(pe => pe.Evento);
        }

        query = query.OrderBy(p => p.Nome)
                    .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

        return await query.ToArrayAsync();
    }

    public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
    {
        IQueryable<Palestrante> query = _context.Palestrantes
           .Include(p => p.RedesSociais);

        if (includeEventos)
        {
            query = query
                .Include(p => p.PalestrantesEventos).ThenInclude(pe => pe.Palestrante);
        }

        query = query.OrderBy(e => e.Id);

        return await query.ToArrayAsync();
    }

    public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
    {
        IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p => p.RedesSociais);

        if (includeEventos)
        {
            query = query
                .Include(p => p.PalestrantesEventos).ThenInclude(pe => pe.Evento);
        }

        query = query.OrderBy(e => e.Id).Where(e => e.Id == palestranteId);

        return await query.FirstOrDefaultAsync();
    }

}