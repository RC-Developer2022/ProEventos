using AutoMapper;
using ProEventos.Application.Dtos;
using ProEventos.Domain.Models;

namespace ProEventos.Api.Helpers;

public class ProEventosProfile : Profile
{
    public ProEventosProfile()
    {
        CreateMap<Evento, EventoDto>().ReverseMap();
        CreateMap<Lote, LoteDto>().ReverseMap();
        CreateMap<Palestrante, PalestranteDto>().ReverseMap();
        CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
    }
}