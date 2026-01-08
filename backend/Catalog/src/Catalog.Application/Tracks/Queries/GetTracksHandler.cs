using AutoMapper;
using Catalog.Application.Interfaces;
using Catalog.Application.Tracks.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application.Tracks.Queries;

public record GetTraksQuery : IRequest<ICollection<TrackDto>>;

internal class GetTracksHandler : IRequestHandler<GetTraksQuery, ICollection<TrackDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetTracksHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ICollection<TrackDto>> Handle(GetTraksQuery request, CancellationToken cancellationToken)
    {
        var tracks = await _unitOfWork.Tracks.Query().ToListAsync(cancellationToken);

        if (!tracks.Any())
            return new List<TrackDto>();

        return _mapper.Map<ICollection<TrackDto>>(tracks);
    }
}
