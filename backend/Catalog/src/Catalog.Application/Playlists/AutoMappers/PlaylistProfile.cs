using AutoMapper;
using Catalog.Application.Playlists.Dtos;
using Catalog.Domain.Entities;

namespace Catalog.Application.Playlists.AutoMappers;

internal class PlaylistProfile : Profile
{
    public PlaylistProfile()
    {
        CreateMap<Playlist, PlaylistDto>()
            .ForCtorParam(
                "Tracks",
                opt => opt.MapFrom(src => src.PlaylistTracks!.OrderByDescending(pt => pt.AddedAt))
            );

    }
}
