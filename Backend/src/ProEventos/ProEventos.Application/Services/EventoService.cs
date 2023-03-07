using ProEventos.Application.Interfaces;
using ProEventos.Domain.Models;
using ProEventos.Infra.Interfaces;

namespace ProEventos.Application.Services;

public class EventoService : IEventoService
{
    private readonly IGeralInfra _geralInfra;
    private readonly IEventoInfra _eventoInfra;

    public EventoService(IGeralInfra geralInfra, IEventoInfra eventoInfra)
    {
        _geralInfra = geralInfra;
        _eventoInfra = eventoInfra;
    }

    public async Task<Evento> AddEvento(Evento model)
    {
        try
        {
            _geralInfra.Add<Evento>(model);
            if (await _geralInfra.SaveChangesAsync())
            {
                return await _eventoInfra.GetEventoByIdAsync(model.Id, false);
            }
            return null;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<Evento> UpdateEvento(int eventoId, Evento model)
    {
        try
        {
            var evento = await _eventoInfra.GetEventoByIdAsync(eventoId, false);
            if (evento == null) return null;

            model.Id = evento.Id;

            _geralInfra.Update(model);
            if (await _geralInfra.SaveChangesAsync())
            {
                return await _eventoInfra.GetEventoByIdAsync(model.Id, false);
            }
            return null;

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> DeleteEvento(int eventoId)
    {
        try
        {
            var evento = await _eventoInfra.GetEventoByIdAsync(eventoId, false);
            if (evento == null) throw new Exception("Evento para delete não foi encontrado.");

            _geralInfra.Delete<Evento>(evento);
            return await _geralInfra.SaveChangesAsync();


        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
    {
        try
        {
            var eventos = await _eventoInfra.GetAllEventosAsync(includePalestrantes);
            if (eventos == null) return null;

            return eventos;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
    {
        try
        {
            var eventos = await _eventoInfra.GetEventoByIdAsync(eventoId, includePalestrantes);
            if (eventos == null) return null;

            return eventos;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
    {
        try
        {
            var eventos = await _eventoInfra.GetAllEventosByTemaAsync(tema, includePalestrantes);
            if (eventos == null) return null;

            return eventos;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}