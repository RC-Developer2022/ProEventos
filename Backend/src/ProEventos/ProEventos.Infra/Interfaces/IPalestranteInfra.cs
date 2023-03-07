using ProEventos.Domain.Models;

namespace ProEventos.Infra.Interfaces;

public interface IPalestranteInfra
{
    Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false);
    Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false);
    Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false);
}