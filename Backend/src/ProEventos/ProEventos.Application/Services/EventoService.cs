using AutoMapper;
using ProEventos.Application.Dtos;
using ProEventos.Application.Interfaces;
using ProEventos.Domain.Models;
using ProEventos.Infra.Interfaces;

namespace ProEventos.Application.Services;

public class EventoService : IEventoService
{
    private readonly IGeralInfra _geralInfra;
    private readonly IEventoInfra _eventoInfra;
    private readonly IMapper _mapper;

    public EventoService(
        IGeralInfra geralInfra,
        IEventoInfra eventoInfra,
        IMapper mapper
        )
    {
        _geralInfra = geralInfra;
        _eventoInfra = eventoInfra;
        _mapper = mapper;
    }

    public async Task<EventoDto> AddEvento(EventoDto model)
    {
        try
        {

            var evento = _mapper.Map<Evento>(model);
            _geralInfra.Add<Evento>(evento);
            if (await _geralInfra.SaveChangesAsync())
            {
                var retorno = await _eventoInfra.GetEventoByIdAsync(evento.Id, false);
                return _mapper.Map<EventoDto>(retorno);
            }
            return null;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<EventoDto> UpdateEvento(int eventoId, EventoDto model)
    {
        try
        {
            var evento = await _eventoInfra.GetEventoByIdAsync(eventoId, false);
            if (evento == null) return null;

            model.Id = evento.Id;

            _mapper.Map(model, evento);

            _geralInfra.Update<Evento>(evento);
            if (await _geralInfra.SaveChangesAsync())
            {
                var retorno = await _eventoInfra.GetEventoByIdAsync(evento.Id, false);
                return _mapper.Map<EventoDto>(retorno);
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

    public async Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes = false)
    {
        try
        {
            var eventos = await _eventoInfra.GetAllEventosAsync(includePalestrantes);
            if (eventos == null) return null;

            var resultado = _mapper.Map<EventoDto[]>(eventos);

            return resultado;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<EventoDto> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
    {
        try
        {
            var evento = await _eventoInfra.GetEventoByIdAsync(eventoId, includePalestrantes);
            if (evento == null) return null;

            var resultado = _mapper.Map<EventoDto>(evento);

            return resultado;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
    {
        try
        {
            var eventos = await _eventoInfra.GetAllEventosByTemaAsync(tema, includePalestrantes);
            if (eventos == null) return null;

            var resultado = _mapper.Map<EventoDto[]>(eventos);

            return resultado;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}