using ProEventos.Domain.Models;

namespace ProEventos.Infra.Interfaces;

public interface IEventoInfra
{
    Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
    Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
    Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
}