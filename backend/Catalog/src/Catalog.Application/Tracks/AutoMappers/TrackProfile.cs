using AutoMapper;
using Catalog.Application.Tracks.Dtos;
using Catalog.Domain.Entities;

namespace Catalog.Application.Tracks.AutoMappers;

internal class TrackProfile : Profile
{
    public TrackProfile()
    {
        CreateMap<Track, TrackDto>()
            .ForCtorParam("HasFile", opt =>
                opt.MapFrom(src => !string.IsNullOrEmpty(src.FileKey)));

        CreateMap<PlaylistTrack, PlaylistTrackDto>();
    }
}
