using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Room.Application.Commands;
using Room.Domain.Repositories;
using Room.Application.Mappers;

namespace Room.Application.Handlers;

public class CreateChatCommandHandler(IRoomRepository chatRepository) : IRequestHandler<CreateRoomCommand, bool>
{
    private readonly IRoomRepository _roomRepository = chatRepository;

    public async Task<bool> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var newRoom = request.MapToRoomEntity();
        return await _roomRepository.AddAsync(newRoom);
    }
}