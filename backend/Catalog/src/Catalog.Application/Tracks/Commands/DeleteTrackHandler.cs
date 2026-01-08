using Catalog.Application.Exceptions;
using Catalog.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application.Tracks.Commands;

public record DeleteTrackCommand(Guid Id) : IRequest;
internal class DeleteTrackHandler : IRequestHandler<DeleteTrackCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeleteTrackHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteTrackCommand request, CancellationToken cancellationToken)
    {
        var track = await _unitOfWork.Tracks
            .Query()
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (track == null) 
            throw new NotFoundException($"Track with id: {request.Id} doesn't exist.");

        using var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);

        _unitOfWork.Tracks.Remove(track);

        await _unitOfWork.SaveAsync(cancellationToken);

        await transaction.CommitAsync(cancellationToken);
    }
}
